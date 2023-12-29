import { Fragment } from "react";
import { Route, Routes } from "react-router-dom";
import HomePage from "../home/HomePage";
import WinePage from "../wine/WinePage";

export const HOME_PAGE = "/";
export const WINE_PAGE = "/wine";
export const UNSPECIFIED_LINK = "/*";

export default function AppRouter() {
  return (
    <Routes>
      <Fragment>
        <Route path={HOME_PAGE} element={<HomePage />} />
        <Route path={WINE_PAGE} element={<WinePage />} />
        <Route path={UNSPECIFIED_LINK} element={<HomePage />} />
      </Fragment>
    </Routes>
  );
}
