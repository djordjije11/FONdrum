import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./app/App";
import { ThemeProvider } from "@material-tailwind/react";

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);

const strictMode: boolean = false;

function renderApp() {
  if (strictMode) {
    root.render(
      <React.StrictMode>
        <ThemeProvider>
          <App />
        </ThemeProvider>
      </React.StrictMode>
    );
  } else {
    root.render(
      <ThemeProvider>
        <App />
      </ThemeProvider>
    );
  }
}

renderApp();
