import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import { MENUITEM_SERVICE_URL } from "../constants/servicesURLs";
import { requestStatuses } from "../constants/apiRequestStatus";
const initialState = {
  items: [],
  status: "idle",
  error: null,
};

export const fetchCategorizedItems = createAsyncThunk(
  "posts/fetchCategorizedItems",
  async () => {
    const endpoint = "/categorizedItems";
    const response = await axios.get(MENUITEM_SERVICE_URL + endpoint);
    return response.data;
  }
);

const menuItemsSlice = createSlice({
  name: "menuItems",
  initialState,
  reducers: {},
  extraReducers(builder) {
    builder
      .addCase(fetchCategorizedItems.pending, (state, action) => {
        state.status = requestStatuses.loading;
      })
      .addCase(fetchCategorizedItems.fulfilled, (state, action) => {
        state.status = requestStatuses.succeeded;
        state.items = action.payload;
      })
      .addCase(fetchCategorizedItems.rejected, (state, action) => {
        state.status = requestStatuses.failed;
        state.error = action.error.message;
      });
  },
});
export default menuItemsSlice.reducer;

export const selectAllMenuItems = (state) => state.menuItems.items;
export const selectMenuItemsStatus = (state) => state.menuItems.status;
export const selectMenuItemsError = (state) => state.menuItems.error;
