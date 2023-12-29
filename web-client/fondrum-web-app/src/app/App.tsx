import { BrowserRouter } from "react-router-dom";
import AppRouter from "./components/router/AppRouter";
import HeaderNav from "./components/header/HeaderNav";

function App() {
  return (
    <BrowserRouter>
      <div className="flex flex-col">
        <HeaderNav />
        <AppRouter />
      </div>
    </BrowserRouter>
  );
}

export default App;
