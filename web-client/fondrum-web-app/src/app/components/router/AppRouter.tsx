import { Fragment } from "react";
import { Route, Routes } from "react-router-dom";
import HomePage from "../home/HomePage";

export const HOME_PAGE = "/";
export const UNSPECIFIED_LINK = "/*";

export default function AppRouter() {
  return (
    <Routes>
      <Fragment>
        <Route path={HOME_PAGE} element={<HomePage />} />
        <Route path={UNSPECIFIED_LINK} element={<HomePage />} />
      </Fragment>
    </Routes>
  );
}
