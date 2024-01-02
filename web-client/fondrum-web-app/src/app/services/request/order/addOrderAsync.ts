import { Order, mapOrder } from "../../../models/Order";
import { API_BASE_URL } from "../apiUrl";

const POST_ORDER_URL = `${API_BASE_URL}/order`;

export default async function addOrderAsync(order: Order): Promise<boolean> {
  const orderDto = mapOrder(order);
  const response = await fetch(POST_ORDER_URL, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(orderDto),
  });
  return response.ok;
}
