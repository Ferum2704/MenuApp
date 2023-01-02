import React from "react";
import {
  Button,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
} from "@mui/material";
import MySnackbar from "../Snackbar/MySnackbar";
import { useDispatch, useSelector } from "react-redux";
import { useState, useEffect } from "react";
import { REQUEST_STATUSES } from "../../constants/apiRequestStatus";
import {
  loginFormVisibilityChanged,
  addNewUser,
  selectLoginError,
  selectLoginStatus,
  resetStatus,
} from "../../slices/loginSlice";
import "./Login.css";

export default function Login(props) {
  const handleCloseSnackBar = () =>
    setSnackbarState((previous) => ({ ...previous, open: false }));

  const [snackbarState, setSnackbarState] = React.useState({
    open: false,
    vertical: "top",
    horizontal: "center",
    severity: "success",
    message: "",
    handleClose: handleCloseSnackBar,
  });
  const [inputName, setInputName] = useState("");
  const [inputPhoneNumber, setInputPhoneNumber] = useState("");

  const dispatch = useDispatch();
  const error = useSelector(selectLoginError);
  const status = useSelector(selectLoginStatus);
  const { vertical, horizontal, open, severity } = snackbarState;

  useEffect(() => {
    if (status === REQUEST_STATUSES.failed) {
      setSnackbarState((previous) => ({
        ...previous,
        message: error,
        severity: "error",
        open: true,
      }));
    } else if (status === REQUEST_STATUSES.succeeded) {
      setSnackbarState((previous) => ({
        ...previous,
        message: "Login was successful",
        open: true,
      }));
      dispatch(loginFormVisibilityChanged(false));
    }
  }, [status]);

  const handleInputNameChange = (e) => setInputName(e.target.value);
  const handleInputPhoneNumber = (e) => setInputPhoneNumber(e.target.value);
  const handleCloseForm = () => dispatch(loginFormVisibilityChanged(false));
  const handleSubmit = () => {
    dispatch(resetStatus());
    dispatch(addNewUser({ inputName, inputPhoneNumber }));
  };
  return (
    <div>
      <MySnackbar state={snackbarState} />
      <Dialog
        open={props.open}
        BackdropProps={{ style: { backgroundColor: "transparent" } }}
        className="loginForm"
      >
        <DialogTitle className="loginFormTitle">Please login</DialogTitle>
        <DialogContent>
          <TextField
            id="outlined-basic"
            label="Name"
            variant="outlined"
            className="loginFormField"
            onChange={handleInputNameChange}
          />
          <br />
          <TextField
            id="outlined-basic"
            label="Phone number"
            variant="outlined"
            className="loginFormField"
            onChange={handleInputPhoneNumber}
          />
        </DialogContent>
        <DialogActions className="loginFormSubmitButton">
          <Button color="error" variant="contained" onClick={handleCloseForm}>
            Cancel
          </Button>
          {inputName && inputPhoneNumber ? (
            <Button variant="contained" onClick={handleSubmit}>
              Login
            </Button>
          ) : (
            <Button variant="contained" onClick={handleSubmit} disabled>
              Login
            </Button>
          )}
        </DialogActions>
      </Dialog>
    </div>
  );
}
