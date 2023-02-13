import {
  createSlice,
  createAsyncThunk,
  isAnyOf,
  current,
} from "@reduxjs/toolkit";
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
export const addMenuItemToOrder = (menuItem) => (dispatch, getState) => {
  const currentOrder = selectCurrentOrder(getState());
  if (!currentOrder.id) {
    dispatch(createNewOrder(menuItem.id));
  } else {
    if (
      currentOrder.orderedMenuItems.find(
        (item) => item.menuItemId == menuItem.id
      )
    ) {
      console.log(menuItem);
      dispatch(addMenuItemInstance({ menuItemId: menuItem.id }));
    } else {
      dispatch(
        addMenuItem({
          menuItemId: menuItem.id,
          orderId: currentOrder.id,
          price: menuItem.price,
          name: menuItem.name,
        })
      );
    }
  }
};

export const getCurrentOrder = createAsyncThunk(
  "currentOrder/get",
  async () => {
    const endpoint = "/currentOrder/" + getUserId();
    const response = await axios.get(ORDER_SERVICE_URL + endpoint);
    return response.data;
  }
);

export const removeMenuItemFromOrder = createAsyncThunk(
  "currentOrder/removeMenuItem",
  async (orderedMenuItemId, thunkApi) => {
    const currentOrder = selectCurrentOrder(thunkApi.getState());
    if (currentOrder.orderedMenuItems.length == 1) {
      thunkApi.dispatch(cancelCurrentOrder(currentOrder.id));
    } else {
      const endpoint = `/menuItem?id=${orderedMenuItemId}&orderId=${currentOrder.id}`;
      const response = await axios.delete(ORDER_SERVICE_URL + endpoint);
      return response.data;
    }
  }
);

export const cancelCurrentOrder = createAsyncThunk(
  "currentOrder/cancel",
  async (orderId) => {
    const endpoint = `/currentOrder/${orderId}`;
    await axios.delete(ORDER_SERVICE_URL + endpoint);
  }
);
const currentOrderSlice = createSlice({
  name: "currentOrder",
  initialState,
  reducers: {
    addMenuItemInstance(state, action) {
      const { menuItemId } = action.payload;
      const item = state.value.orderedMenuItems.find(
        (item) => item.menuItemId == menuItemId
      );
      if (item) {
        item.number += 1;
        item.price += item.initialPrice;
      }
    },
    subtractMenuItemInstance(state, action) {
      const { id } = action.payload;
      const item = state.value.orderedMenuItems.find((item) => item.id === id);
      if (item && item.number > 1) {
        item.number -= 1;
        item.price -= item.initialPrice;
      }
    },
  },
  extraReducers(builder) {
    builder
      .addCase(addMenuItem.fulfilled, (state, action) => {
        state.status = REQUEST_STATUSES.succeeded;
        state.value.orderedMenuItems.push(action.payload);
      })
      .addCase(addMenuItem.rejected, (state, action) => {
        state.status = REQUEST_STATUSES.failed;
        state.error = action.error.message;
      })
      .addCase(removeMenuItemFromOrder.fulfilled, (state, action) => {
        state.status = REQUEST_STATUSES.succeeded;
        const id = action.payload;
        var index = state.value.orderedMenuItems.findIndex(
          (item) => item.id === id
        );
        if (index > -1) {
          state.value.orderedMenuItems.splice(index, 1);
        }
      })
      .addCase(removeMenuItemFromOrder.rejected, (state, action) => {
        state.status = REQUEST_STATUSES.failed;
        state.error = action.error.message;
      })
      .addCase(cancelCurrentOrder.fulfilled, (state, action) => {
        state.value = initialState.value;
        state.error = initialState.error;
        state.status = initialState.status;
      })
      .addCase(cancelCurrentOrder.rejected, (state, action) => {
        state.status = REQUEST_STATUSES.failed;
        state.error = action.error.message;
      })
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
          state.value.orderedMenuItems = state.value.orderedMenuItems.map(
            (item) => ({ ...item, initialPrice: item.price })
          );
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
export const selectMenuItemsNumber = (state) =>
  state.currentOrder.value.orderedMenuItems
    ? state.currentOrder.value.orderedMenuItems.length
    : 0;
export const { addMenuItemInstance, subtractMenuItemInstance } =
  currentOrderSlice.actions;
