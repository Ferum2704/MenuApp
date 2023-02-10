import { createSlice, createAsyncThunk, isAnyOf } from "@reduxjs/toolkit";
import axios from "axios";
import { ORDER_SERVICE_URL } from "../../constants/servicesURLs";
import { REQUEST_STATUSES } from "../../constants/apiRequestStatus";
import { getUserId } from "../../helpers/sessionHelper";

const initialState = {
  value: {},
  status: "idle",
  error: null,
};

export const createNewOrder = createAsyncThunk(
  "currentOrder/createNewOrder",
  async (menuItemId) => {
    const endpoint = "/newOrder";
    const newOrderInfo = {
      visitorId: getUserId(),
      menuItemId: menuItemId,
    };
    const response = await axios.post(
      ORDER_SERVICE_URL + endpoint,
      newOrderInfo
    );
    return response.data;
  }
);
export const addMenuItem = createAsyncThunk(
  "currentOrder/addmenuItem",
  async (menuItem) => {
    const endpoint = "/menuItem";
    const response = await axios.post(ORDER_SERVICE_URL + endpoint, menuItem);
    return response.data;
  }
);
export const addMenuItemToOrder = (menuItemId) => (dispatch, getState) => {
  const currentOrderId = selectCurrentOrderId(getState());
  if (!currentOrderId) {
    dispatch(createNewOrder(menuItemId));
  } else {
    dispatch(
      addMenuItem({
        menuItemId: menuItemId,
        orderId: currentOrderId,
      })
    );
  }
};

export const getCurrentOrder = createAsyncThunk(
  "currentOrder/getCurrentOrder/",
  async () => {
    const endpoint = "/currentOrder/" + getUserId();
    const response = await axios.get(ORDER_SERVICE_URL + endpoint);
    return response.data;
  }
);

const currentOrderSlice = createSlice({
  name: "currentOrder",
  initialState,
  reducers: {},
  extraReducers(builder) {
    builder
      .addMatcher(
        isAnyOf(createNewOrder.pending, getCurrentOrder.pending),
        (state, action) => {
          state.status = REQUEST_STATUSES.loading;
        }
      )
      .addMatcher(
        isAnyOf(createNewOrder.fulfilled, getCurrentOrder.fulfilled),
        (state, action) => {
          state.status = REQUEST_STATUSES.succeeded;
          state.value = action.payload;
        }
      )
      .addMatcher(
        isAnyOf(createNewOrder.rejected, getCurrentOrder.rejected),
        (state, action) => {
          state.status = REQUEST_STATUSES.failed;
          state.error = action.error.message;
        }
      );
  },
});
export default currentOrderSlice.reducer;

export const selectCurrentOrderId = (state) => state.currentOrder.value.id;
export const selectCurrentOrder = (state) => state.currentOrder.value;
export const selectCurrentOrderError = (state) => state.currentOrder.error;
export const selectCurrentOrderStatus = (state) => state.currentOrder.status;
