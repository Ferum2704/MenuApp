import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import { ORDER_SERVICE_URL } from "../constants/servicesURLs";
import { REQUEST_STATUSES } from "../constants/apiRequestStatus";
import { getUserId } from "../helpers/sessionHelper";

const initialState = {
  orderHistory: [],
  currentOrder: {},
  status: "idle",
  error: null,
};

export const createNewOrder = createAsyncThunk(
  "orders/createNewOrder",
  async (menuItemId, menuItemPrice) => {
    const endpoint = "/newOrder";
    const newOrder = {
      status: "Created",
      date: new Date(),
      visitorId: getUserId(),
      price: menuItemPrice,
      orderedMenuItems: [
        {
          menuItemId: menuItemId,
          number: 1,
        },
      ],
    };
    const response = await axios.post(ORDER_SERVICE_URL + endpoint, newOrder);
    return response.data;
  }
);
export const addMenuItem = createAsyncThunk(
  "orders/addmenuItem",
  async (menuItem) => {
    const endpoint = "/menuItem";
    const response = await axios.post(ORDER_SERVICE_URL + endpoint, menuItem);
    return response.data;
  }
);
export const addMenuItemToOrder =
  (menuItemId, menuItemPrice) => (dispatch, getState) => {
    const currentOrderId = !selectCurrentOrderId(getState());
    if (!currentOrderId) {
      dispatch(createNewOrder(menuItemId, menuItemPrice));
    } else {
      dispatch(
        addMenuItem({
          menuItemId: menuItemId,
          orderId: currentOrderId,
          price: menuItemPrice,
        })
      );
    }
  };

const ordersSlice = createSlice({
  name: "orders",
  initialState,
  reducers: {},
  extraReducers(builder) {
    builder
      .addCase(createNewOrder.pending, (state, action) => {
        state.status = REQUEST_STATUSES.loading;
      })
      .addCase(createNewOrder.fulfilled, (state, action) => {
        state.status = REQUEST_STATUSES.succeeded;
        state.items = action.payload;
      })
      .addCase(createNewOrder.rejected, (state, action) => {
        state.status = REQUEST_STATUSES.failed;
        state.error = action.error.message;
      });
  },
});
export default ordersSlice.reducer;

export const selectCurrentOrderId = (state) => state.orders.currentOrder.id;
