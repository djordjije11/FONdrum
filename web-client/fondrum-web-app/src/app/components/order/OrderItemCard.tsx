import { OrderItem } from "../../models/OrderItem";

interface OrderItemCardProps {
  index: number;
  orderItem: OrderItem;
  handleRemoveItem: (orderItem: OrderItem) => void;
}

export default function OrderItemCard(props: OrderItemCardProps) {
  const { index, orderItem, handleRemoveItem } = props;

  return (
    <div className="bg-gray-50 border-solid border border-blue-gray-800 flex flex-col p-2 gap-1 rounded-lg">
      <div className="flex justify-between">
        <div className="flex gap-1">
          <span>{index + 1}. </span>
          <span className="font-semibold">{orderItem.wine.name}</span>
        </div>
        <button
          onClick={() => handleRemoveItem(orderItem)}
          className="px-2 text-sm text-start bg-white hover:bg-gray-100 text-blue-gray-800 border-2 border-blue-gray-600 rounded shadow"
        >
          x
        </button>
      </div>
      <div className="flex justify-between items-center">
        <span className="text-sm">Količina: {orderItem.amount}</span>
        <span>{(orderItem.wine.price * orderItem.amount).toFixed(2)} €</span>
      </div>
    </div>
  );
}
