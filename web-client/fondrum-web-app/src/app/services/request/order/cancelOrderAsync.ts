import { API_BASE_URL } from "../apiUrl";

const CANCEL_ORDER_URL = (id: string) => `${API_BASE_URL}/order/${id}/cancel`;

export default async function cancelOrderAsync(id: string): Promise<boolean> {
  const response = await fetch(CANCEL_ORDER_URL(id), {
    method: "PATCH",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
  });

  return response.ok;
}
