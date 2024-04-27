import { useContext, useState } from "react";
import { OrderContext } from "../../App";
import ShoppingCartContainer from "./ShoppingCartContainer";
import { Dialog } from "@material-tailwind/react";
import OrderForm from "./OrderForm";

export default function OrderPage() {
  const { order, setOrder } = useContext(OrderContext);
  const [orderFormOpen, setOrderFormOpen] = useState(false);

  return (
    <>
      <div className="h-[640px] w-full flex items-center justify-center mt-2">
        <div className="h-full w-1/3">
          <ShoppingCartContainer
            order={order}
            setOrder={setOrder}
            onClick={() => setOrderFormOpen(true)}
          />
        </div>
      </div>
      <Dialog
        size="xs"
        open={orderFormOpen}
        handler={() => setOrderFormOpen((prev) => !prev)}
        className="bg-transparent shadow-none"
        placeholder={<></>}
      >
        <OrderForm
          order={order}
          setOrder={setOrder}
          closeOrderForm={() => setOrderFormOpen(false)}
        />
      </Dialog>
    </>
  );
}
