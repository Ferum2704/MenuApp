import { configureStore } from "@reduxjs/toolkit";
import menuItemsReducer from "./slices/menuItemsSlice";
import loginReducer from "./slices/loginSlice";
export default configureStore({
  reducer: {
    menuItems: menuItemsReducer,
    login: loginReducer,
  },
});
