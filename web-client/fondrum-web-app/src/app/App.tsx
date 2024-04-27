import { BrowserRouter } from "react-router-dom";
import AppRouter from "./components/router/AppRouter";
import HeaderNav from "./components/header/HeaderNav";
import { createContext, useState } from "react";
import { OrderModel } from "./models/Order";

type OrderContext = {
  order: OrderModel;
  setOrder: React.Dispatch<React.SetStateAction<OrderModel>>;
};

export const OrderContext = createContext({} as OrderContext);

function App() {
  const [order, setOrder] = useState(new OrderModel());

  return (
    <BrowserRouter>
      <div className="flex flex-col min-h-screen h-fit bg-blue-gray-900">
        <HeaderNav />
        <OrderContext.Provider value={{ order, setOrder }}>
          <AppRouter />
        </OrderContext.Provider>
      </div>
    </BrowserRouter>
  );
}

export default App;
