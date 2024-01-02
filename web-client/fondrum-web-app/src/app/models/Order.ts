import { OrderItem, OrderItemDto, mapOrderItem } from "./OrderItem";
import { Wine } from "./Wine";

export type Order = {
  items: OrderItem[];
};

export class OrderModel {
  items: OrderItem[];

  constructor(items?: OrderItem[]) {
    this.items = items ?? [];
  }

  findOrderItemByWine(
    wine: Wine
  ): { orderItem: OrderItem; index: number } | null {
    const orderedWineItemIndex = this.items.findIndex(
      (i) => i.wine.id === wine.id
    );

    if (orderedWineItemIndex === -1) {
      return null;
    }

    const orderedWineItem = this.items.at(orderedWineItemIndex);
    if (orderedWineItem === undefined) {
      throw new Error(
        "WinePage - findOrderItemByWine - orderedWineItem === undefined"
      );
    }

    return { orderItem: orderedWineItem, index: orderedWineItemIndex };
  }

  getOrderItemAmountByWine(wine: Wine) {
    const orderedWineItemResult = this.findOrderItemByWine(wine);
    return orderedWineItemResult === null
      ? 0
      : orderedWineItemResult.orderItem.amount;
  }
}

export const _defaultOrder: Order = {
  items: [] as OrderItem[],
};

export type OrderDto = {
  items: OrderItemDto[];
};

export function mapOrder(order: Order): OrderDto {
  return {
    items: order.items.map(mapOrderItem),
  };
}
