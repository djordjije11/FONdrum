import { BrowserRouter } from "react-router-dom";
import AppRouter from "./components/router/AppRouter";
import HeaderNav from "./components/header/HeaderNav";

function App() {
  return (
    <BrowserRouter>
      <div className="flex flex-col min-h-screen h-fit bg-blue-gray-900">
        <HeaderNav />
        <div className="">
          <AppRouter />
        </div>
      </div>
    </BrowserRouter>
  );
}

export default App;
