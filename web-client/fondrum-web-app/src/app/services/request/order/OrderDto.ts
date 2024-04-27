import { OrderBuyer } from "../../../models/Order";
import { OrderItem } from "../../../models/OrderItem";
import { OrderItemDto, mapOrderItem } from "./OrderItemDto";

export type OrderDto = {
  items: OrderItemDto[];
  buyerName: string;
  buyerPhoneNumber: string;
  buyerAddress: string;
};

export function mapToOrderDto(items: OrderItem[], buyer: OrderBuyer): OrderDto {
  return {
    items: items.map(mapOrderItem),
    buyerName: buyer.name,
    buyerPhoneNumber: buyer.phoneNumber,
    buyerAddress: buyer.address,
  };
}
