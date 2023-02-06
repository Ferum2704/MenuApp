import { configureStore } from "@reduxjs/toolkit";
import menuItemsReducer from "./slices/menuItemsSlice";
import loginReducer from "./slices/loginSlice";
import ordersReducer from "./slices/ordersSlice";
export default configureStore({
  reducer: {
    menuItems: menuItemsReducer,
    login: loginReducer,
    orders: ordersReducer,
  },
});
