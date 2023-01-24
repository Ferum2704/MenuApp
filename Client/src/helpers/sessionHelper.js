import { loginFormVisibilityChanged } from "../slices/loginSlice";
import { useDispatch } from "react-redux";
export function useLoginUserId() {
  const dispatch = useDispatch();
  return function () {
    console.log(sessionStorage.getItem("userId"));
    if (!sessionStorage.getItem("userId")) {
      dispatch(loginFormVisibilityChanged(true));
    }
  };
}
