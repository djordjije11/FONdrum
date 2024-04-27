import { OrderModel } from "../../models/Order";
import { OrderItem } from "../../models/OrderItem";
import ShopIcon from "../shared/icons/header/ShopIcon";
import OrderItemCard from "./OrderItemCard";

interface ShoppingCartContainerProps {
  order: OrderModel;
  setOrder: React.Dispatch<React.SetStateAction<OrderModel>>;
  onClick: () => void;
}

export default function ShoppingCartContainer(
  props: ShoppingCartContainerProps
) {
  const { order, setOrder, onClick } = props;

  function removeOrderItem(orderItem: OrderItem) {
    setOrder(
      (prev) =>
        new OrderModel(
          prev.items.filter((item) => item.wine.id !== orderItem.wine.id)
        )
    );
  }

  return (
    <div className="border-solid border-4 border-blue-gray-800 bg-blue-gray-800 h-full w-full rounded-md p-4">
      <div className="h-full w-full grid grid-flow-row grid-rows-12">
        <div className="row-span-1 flex justify-center items-center gap-2">
          <span className="text-lg font-semibold text-center my-2 text-white">
            Moja korpa
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
          Ukupno: {order.getTotalPrice().toFixed(2)} €
        </div>
        <div className="row-span-1 flex justify-center items-end">
          <button
            onClick={onClick}
            disabled={order.items.length === 0}
            className={`w-20 h-4/5 text-center bg-blue-gray-800 text-white border-2 border-blue-gray-600 rounded shadow ${
              order.items.length === 0 ? "" : "hover:bg-blue-gray-600"
            }`}
          >
            KUPI
          </button>
        </div>
      </div>
    </div>
  );
}
