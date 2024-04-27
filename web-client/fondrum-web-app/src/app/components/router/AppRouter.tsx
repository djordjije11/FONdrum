import { Fragment } from "react";
import { Route, Routes } from "react-router-dom";
import HomePage from "../home/HomePage";
import WinePage from "../wine/WinePage";
import OrderPage from "../order/OrderPage";

export const HOME_PAGE = "/";
export const WINE_PAGE = "/katalog";
export const ORDER_PAGE = "/korpa";
export const UNSPECIFIED_LINK = "/*";

export default function AppRouter() {
  return (
    <Routes>
      <Fragment>
        <Route path={HOME_PAGE} element={<HomePage />} />
        <Route path={WINE_PAGE} element={<WinePage />} />
        <Route path={ORDER_PAGE} element={<OrderPage />} />
        <Route path={UNSPECIFIED_LINK} element={<HomePage />} />
      </Fragment>
    </Routes>
  );
}
