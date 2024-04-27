import { API_BASE_URL } from "../apiUrl";
import { OrderDto } from "./OrderDto";

const ADD_ORDER_URL = `${API_BASE_URL}/order`;

export default async function addOrderAsync(
  order: OrderDto
): Promise<OrderIdDto | null> {
  const response = await fetch(ADD_ORDER_URL, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(order),
  });

  if (response.ok === false) {
    return null;
  }

  return await response.json();
}

export type OrderIdDto = {
  id: string;
};
