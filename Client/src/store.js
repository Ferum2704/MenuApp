import { configureStore } from "@reduxjs/toolkit";
import menuItemsReducer from "./slices/menuItemsSlice";
export default configureStore({
  reducer: {
    menuItems: menuItemsReducer,
  },
});
