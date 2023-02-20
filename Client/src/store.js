import { configureStore } from "@reduxjs/toolkit";
import menuItemsReducer from "./slices/menuItemsSlice";
import loginReducer from "./slices/loginSlice";
import currentOrderReducer from "./slices/orderSlices/currentOrderSlice";
export default configureStore({
  reducer: {
    menuItems: menuItemsReducer,
    login: loginReducer,
    currentOrder: currentOrderReducer,
  },
});
