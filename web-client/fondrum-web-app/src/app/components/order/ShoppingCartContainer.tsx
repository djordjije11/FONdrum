import { OrderModel } from "../../models/Order";
import { OrderItem } from "../../models/OrderItem";
import addOrderAsync from "../../services/request/order/addOrderAsync";
import failAlert from "../alert/failAlert";
import successAlert from "../alert/successAlert";
import ShopIcon from "../shared/icons/home/ShopIcon";
import OrderItemCard from "./OrderItemCard";

interface ShoppingCartContainerProps {
  order: OrderModel;
  setOrder: React.Dispatch<React.SetStateAction<OrderModel>>;
}

export default function ShoppingCartContainer(
  props: ShoppingCartContainerProps
) {
  const { order, setOrder } = props;

  function getTotalSum(): number {
    let totalSum = 0;
    order.items.forEach((item) => (totalSum += item.wine.price * item.amount));
    return totalSum;
  }

  function removeOrderItem(orderItem: OrderItem) {
    setOrder(
      (prev) =>
        new OrderModel(
          prev.items.filter((item) => item.wine.id !== orderItem.wine.id)
        )
    );
  }

  async function sendOrderAsync() {
    const isOrdered = await addOrderAsync(order);
    if (isOrdered === false) {
      failAlert("Order unsuccessful", "Try to refresh the page.");
      return;
    }
    successAlert("Order successful");
    setOrder(new OrderModel());
  }

  return (
    <div className="border-solid border-4 border-blue-gray-800 bg-blue-gray-800 h-full w-full rounded-md p-4">
      <div className="h-full w-full grid grid-flow-row grid-rows-12">
        <div className="row-span-1 flex justify-center items-center gap-2">
          <span className="text-lg font-semibold text-center my-2 text-white">
            Shopping cart
          </span>
          <ShopIcon className="h-6 text-white" />
        </div>
        <div className="row-span-9 flex flex-col gap-2 overflow-y-auto p-1">
          {order.items.map((orderItem, index) => (
            <OrderItemCard
              key={orderItem.wine.id}
              orderItem={orderItem}
              index={index}
              handleRemoveItem={removeOrderItem}
            />
          ))}
        </div>
        <div className="row-span-1 flex justify-end items-end text-white p-1">
          Total: {getTotalSum().toFixed(2)} din
        </div>
        <div className="row-span-1 flex justify-center items-end">
          <button
            onClick={sendOrderAsync}
            disabled={order.items.length === 0}
            className={`w-20 h-4/5 text-center bg-blue-gray-800 text-white border-2 border-blue-gray-600 rounded shadow ${
              order.items.length === 0 ? "" : "hover:bg-blue-gray-600"
            }`}
          >
            BUY
          </button>
        </div>
      </div>
    </div>
  );
}
