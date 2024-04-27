import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./app/App";
import { ThemeProvider } from "@material-tailwind/react";
import { PayPalScriptProvider } from "@paypal/react-paypal-js";
import { paypalClientId } from "./config.secrets";

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);

const strictMode: boolean = false;

function renderApp() {
  if (strictMode) {
    root.render(
      <React.StrictMode>
        <FONdrumApp />
      </React.StrictMode>
    );
  } else {
    root.render(<FONdrumApp />);
  }
}

function FONdrumApp() {
  return (
    <ThemeProvider>
      <PayPalScriptProvider
        options={{ clientId: paypalClientId, currency: "EUR" }}
      >
        <App />
      </PayPalScriptProvider>
    </ThemeProvider>
  );
}

renderApp();
