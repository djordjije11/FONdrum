import {
  Card,
  CardBody,
  CardFooter,
  Input,
  Typography,
} from "@material-tailwind/react";
import { OrderBuyer, OrderModel } from "../../models/Order";
import { MutableRefObject, useEffect, useRef, useState } from "react";
import PayPalPayment from "./payment/PayPalPayment";
import failAlert from "../alert/failAlert";
import successAlert from "../alert/successAlert";

interface OrderFormProps {
  order: OrderModel;
  setOrder: React.Dispatch<React.SetStateAction<OrderModel>>;
  closeOrderForm: () => void;
}

export type OrderBuyerRefs = {
  name: MutableRefObject<HTMLInputElement | null>;
  phoneNumber: MutableRefObject<HTMLInputElement | null>;
  address: MutableRefObject<HTMLInputElement | null>;
};

export default function OrderForm(props: OrderFormProps) {
  const { order, setOrder, closeOrderForm } = props;
  const [orderBuyer, setOrderBuyer] = useState({
    name: "",
    phoneNumber: "",
    address: "",
  } as OrderBuyer);

  const orderBuyerRefs: OrderBuyerRefs = {
    name: useRef(null),
    phoneNumber: useRef(null),
    address: useRef(null),
  };

  const isFormValid: boolean =
    orderBuyer.name !== "" &&
    orderBuyer.address !== "" &&
    orderBuyer.phoneNumber !== "";

  return (
    <div>
      <Card className="mx-auto w-full max-w-[24rem]" placeholder={<></>}>
        <CardBody className="flex flex-col gap-4" placeholder={<></>}>
          <Typography variant="h4" color="blue-gray" placeholder={<></>}>
            {"Izvršite svoju porudžbinu"}
          </Typography>
          <Typography
            className="mb-3 font-normal"
            variant="paragraph"
            color="gray"
            placeholder={<></>}
          >
            {"Porudžbina će biti evidentirana ubrzo nakon plaćanja."}
          </Typography>
          <Typography className="-mb-2" variant="h6" placeholder={""}>
            {"Unesite svoje lične podatke."}
          </Typography>
          <Input
            inputRef={orderBuyerRefs.name}
            label="Ime i prezime"
            size="lg"
            crossOrigin={""}
            value={orderBuyer.name}
            onChange={(e) =>
              setOrderBuyer((prev) => ({
                ...prev,
                name: e.target.value,
              }))
            }
          />
          <Input
            inputRef={orderBuyerRefs.phoneNumber}
            label="Broj telefona"
            size="lg"
            crossOrigin={""}
            value={orderBuyer.phoneNumber}
            onChange={(e) =>
              setOrderBuyer((prev) => ({
                ...prev,
                phoneNumber: e.target.value,
              }))
            }
          />
          <Input
            inputRef={orderBuyerRefs.address}
            label="Adresa"
            size="lg"
            crossOrigin={""}
            value={orderBuyer.address}
            onChange={(e) =>
              setOrderBuyer((prev) => ({
                ...prev,
                address: e.target.value,
              }))
            }
          />
        </CardBody>
        <CardFooter className="pt-0" placeholder={<></>}>
          <PayPalPayment
            order={order}
            orderBuyerRefs={orderBuyerRefs}
            onError={() => {
              closeOrderForm();
              setOrder(new OrderModel());
              failAlert("Neuspešna porudžbina", "Pokušajte ponovo.");
            }}
            onSuccess={() => {
              closeOrderForm();
              setOrder(new OrderModel());
              successAlert("Uspešna porudžbina!");
            }}
            disabled={!isFormValid}
          />
        </CardFooter>
      </Card>
    </div>
  );
}
