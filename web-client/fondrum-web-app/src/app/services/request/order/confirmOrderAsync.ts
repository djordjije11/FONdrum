import { API_BASE_URL } from "../apiUrl";
import { OrderPaymentDataDto } from "./OrderPaymentDataDto";

const CONFIRM_ORDER_URL = (id: string) => `${API_BASE_URL}/order/${id}/confirm`;

export default async function confirmOrderAsync(
  id: string,
  paymentData: OrderPaymentDataDto
): Promise<boolean> {
  const response = await fetch(CONFIRM_ORDER_URL(id), {
    method: "PATCH",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(paymentData),
  });

  return response.ok;
}
