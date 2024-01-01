import { Order } from "../../models/Order";
import OrderItemCard from "./OrderItemCard";

interface ShoppingCartContainerProps {
  order: Order;
}

export default function ShoppingCartContainer(
  props: ShoppingCartContainerProps
) {
  const { order } = props;
  return (
    <div className="border-solid border-4 border-blue-gray-800 bg-gray-50 h-full w-full rounded-md p-4">
      <div className="text-lg font-semibold text-center">Shopping cart</div>
      <div>
        {order.items.map((orderItem, index) => (
          <OrderItemCard
            key={orderItem.wine.id}
            orderItem={orderItem}
            index={index}
          />
        ))}
      </div>
    </div>
  );
}
