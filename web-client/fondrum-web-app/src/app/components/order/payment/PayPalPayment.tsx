import { PayPalButtons, PayPalScriptProvider } from "@paypal/react-paypal-js";
import {
  CreateOrderData,
  CreateOrderActions,
  OnApproveData,
  OnApproveActions,
  OnCancelledActions,
} from "@paypal/paypal-js/types/components/buttons";
import addOrderAsync from "../../../services/request/order/addOrderAsync";
import { mapToOrderDto } from "../../../services/request/order/OrderDto";
import { OrderModel } from "../../../models/Order";
import { OrderBuyerRefs } from "../OrderForm";
import cancelOrderAsync from "../../../services/request/order/cancelOrderAsync";
import confirmOrderAsync from "../../../services/request/order/confirmOrderAsync";
import { OrderPaymentDataDto } from "../../../services/request/order/OrderPaymentDataDto";
import { useNavigate } from "react-router-dom";
import { WINE_PAGE } from "../../router/AppRouter";

export interface PayPalPaymentProps {
  order: OrderModel;
  orderBuyerRefs: OrderBuyerRefs;
  onError: () => void;
  onSuccess: () => void;
  disabled: boolean;
}

export default function PayPalPayment(props: PayPalPaymentProps) {
  const { order, orderBuyerRefs, onError, onSuccess, disabled } = props;
  var orderId: string | null = null;
  const navigate = useNavigate();

  async function sendOrderAsync(): Promise<string | null> {
    const orderId = await addOrderAsync(
      mapToOrderDto(order.items, {
        name: orderBuyerRefs?.name?.current?.value ?? "",
        phoneNumber: orderBuyerRefs?.phoneNumber?.current?.value ?? "",
        address: orderBuyerRefs?.address?.current?.value ?? "",
      })
    );
    return orderId?.id ?? null;
  }

  async function createOrderAsync(
    data: CreateOrderData,
    actions: CreateOrderActions
  ): Promise<string> {
    orderId = await sendOrderAsync();
    if (orderId === null) {
      throw new Error("Order not created.");
    }

    return actions.order.create({
      intent: "CAPTURE",
      purchase_units: [
        {
          description: "FONdrum wines",
          amount: {
            currency_code: "EUR",
            value: order.getTotalPrice().toFixed(2),
          },
        },
      ],
    });
  }

  async function handleApprovementAsync(
    data: OnApproveData,
    actions: OnApproveActions
  ): Promise<void> {
    if (orderId === null) {
      throw new Error("OrderId must not be null.");
    }

    const orderResponse = await actions.order?.capture();
    const orderPayment: OrderPaymentDataDto = {
      orderID: data.orderID,
      payerID: data.payerID ?? undefined,
      paymentID: data.paymentID ?? undefined,
      payerEmailAddress: orderResponse?.payer?.email_address,
      payerName:
        orderResponse?.payer?.name?.given_name +
        " " +
        orderResponse?.payer?.name?.surname,
    };

    confirmOrderAsync(orderId, orderPayment);
    navigate(WINE_PAGE);
    onSuccess();
  }

  function handleError(err: Record<string, unknown>) {
    navigate(WINE_PAGE);
    onError();
  }

  async function handleCancel(
    data: Record<string, unknown>,
    actions: OnCancelledActions
  ) {
    if (orderId !== null) {
      await cancelOrderAsync(orderId);
    }
  }

  return (
    <PayPalButtons
      style={{ layout: "horizontal", tagline: false, height: 55 }}
      createOrder={createOrderAsync}
      onError={handleError}
      onApprove={handleApprovementAsync}
      onCancel={handleCancel}
      disabled={disabled}
    />
  );
}
