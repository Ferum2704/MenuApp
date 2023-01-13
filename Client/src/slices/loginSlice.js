import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import { USER_SERVICE_URL } from "../constants/servicesURLs";
import { REQUEST_STATUSES } from "../constants/apiRequestStatus";
const initialState = {
  id: 0,
  isOpenDialog: false,
  status: "idle",
  error: null,
};

export const sendLoginData = createAsyncThunk(
  "posts/sendLoginData",
  async (newUser) => {
    const endpoint = "/login";
    const response = await axios.post(USER_SERVICE_URL + endpoint, newUser);
    return response.data;
  }
);
export const loginUser = (inputName, inputPhoneNumber) => (dispatch) => {
  dispatch(resetStatus());
  dispatch(sendLoginData({ inputName, inputPhoneNumber }));
};

const loginSlice = createSlice({
  name: "login",
  initialState,
  reducers: {
    loginFormVisibilityChanged(state, action) {
      state.isOpenDialog = action.payload;
    },
    resetStatus(state, action) {
      state.status = REQUEST_STATUSES.idle;
    },
  },
  extraReducers(builder) {
    builder
      .addCase(sendLoginData.fulfilled, (state, action) => {
        state.status = REQUEST_STATUSES.succeeded;
        state.id = action.payload;
      })
      .addCase(sendLoginData.rejected, (state, action) => {
        state.status = REQUEST_STATUSES.failed;
        state.error = action.error.message;
      });
  },
});

export default loginSlice.reducer;

export const selectLoginState = (state) => state.login;
export const selectIsOpenDialog = (state) => state.login.isOpenDialog;
export const selectLoginError = (state) => state.login.error;
export const selectLoginStatus = (state) => state.login.status;

export const { loginFormVisibilityChanged, resetStatus } = loginSlice.actions;
