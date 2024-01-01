import { Wine } from "./Wine";

export type OrderItem = {
  wine: Wine;
  amount: number;
};

export type OrderItemDto = {
  wineId: {
    rowVersion: number;
    id: string;
  };
  amount: number;
};
