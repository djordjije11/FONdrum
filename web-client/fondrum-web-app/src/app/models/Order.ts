import { OrderItem, OrderItemDto } from "./OrderItem";

export type Order = {
  items: OrderItem[];
};

export type OrderDto = {
  items: OrderItemDto[];
};
