import React from "react";
import { render } from "@testing-library/react";
import { Provider } from "react-redux";
import loginReducer from "../slices/loginSlice";
import menuItemsReducer from "../slices/menuItemsSlice";
import { configureStore } from "@reduxjs/toolkit";
export function renderWithProviders(
  ui,
  {
    store = configureStore({
      reducer: {
        menuItems: menuItemsReducer,
        login: loginReducer,
      },
    }),
  } = {}
) {
  function Wrapper({ children }) {
    return <Provider store={store}>{children}</Provider>;
  }
  return { store, ...render(ui, { wrapper: Wrapper }) };
}
