import { loginFormVisibilityChanged } from "../slices/loginSlice";

export function checkUserIdForLogin(dispatch) {
  if (!sessionStorage.getItem("userId")) {
    dispatch(loginFormVisibilityChanged(true));
  }
}
export function setUserId(userId) {
  sessionStorage.setItem("userId", userId);
}
export function getUserId() {
  return sessionStorage.getItem("userId");
}
