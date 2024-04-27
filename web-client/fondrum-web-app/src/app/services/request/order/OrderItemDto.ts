import { OrderItem } from "../../../models/OrderItem";

export type OrderItemDto = {
  wineId: {
    rowVersion: number;
    id: string;
  };
  amount: number;
};

export function mapOrderItem(orderItem: OrderItem): OrderItemDto {
  return {
    wineId: {
      rowVersion: orderItem.wine.rowVersion,
      id: orderItem.wine.id,
    },
    amount: orderItem.amount,
  };
}
