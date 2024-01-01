import { OrderItem } from "../../models/OrderItem";

interface OrderItemCardProps {
  index: number;
  orderItem: OrderItem;
}

export default function OrderItemCard(props: OrderItemCardProps) {
  const { index, orderItem } = props;

  return (
    <div className="border-solid border border-blue-gray-800 flex flex-col">
      <div className="flex justify-between">
        <span>
          {index + 1}. {orderItem.wine.name}
        </span>
        <button>X</button>
      </div>
      <div className="flex justify-between">
        <span>Amount: {orderItem.amount}</span>
        <span>{orderItem.wine.price} din</span>
      </div>
    </div>
  );
}
