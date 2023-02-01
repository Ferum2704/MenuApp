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
  loginUser,
  selectLoginError,
  selectLoginStatus,
} from "../../slices/loginSlice";
import "./Login.css";

export default function Login({ isLoginDialogOpen = true }) {
  const [snackbarState, setSnackbarState] = React.useState({
    isSnackbarOpen: false,
    resultSeverity: "success",
    resultMessage: "",
  });
  const [inputName, setInputName] = useState("");
  const [inputPhoneNumber, setInputPhoneNumber] = useState("");

  const dispatch = useDispatch();
  const error = useSelector(selectLoginError);
  const status = useSelector(selectLoginStatus);

  useEffect(() => {
    switch (status) {
      case REQUEST_STATUSES.failed:
        setSnackbarState((previous) => ({
          ...previous,
          resultMessage: error,
          resultSeverity: "error",
          isSnackbarOpen: true,
        }));
        break;
      case REQUEST_STATUSES.succeeded:
        setSnackbarState((previous) => ({
          ...previous,
          resultMessage: "Login is successful",
          isSnackbarOpen: true,
        }));
        dispatch(loginFormVisibilityChanged(false));
        break;
      default:
        break;
    }
  }, [status]);

  const handleCloseSnackBar = () =>
    setSnackbarState((previous) => ({ ...previous, isSnackbarOpen: false }));
  const handleInputNameChange = (e) => setInputName(e.target.value);
  const handleInputPhoneNumber = (e) => setInputPhoneNumber(e.target.value);
  const handleCloseForm = () => dispatch(loginFormVisibilityChanged(false));
  const handleSubmit = () => dispatch(loginUser(inputName, inputPhoneNumber));
  return (
    <div>
      <MySnackbar
        handleClose={handleCloseSnackBar}
        isOpen={snackbarState.isSnackbarOpen}
        message={snackbarState.resultMessage}
        severity={snackbarState.resultSeverity}
      />
      <Dialog
        open={isLoginDialogOpen}
        BackdropProps={{ style: { backgroundColor: "transparent" } }}
        className="loginForm"
      >
        <DialogTitle className="loginFormTitle">Please login</DialogTitle>
        <DialogContent>
          <TextField
            id="name"
            label="Name"
            name="name"
            variant="outlined"
            className="loginFormField"
            onChange={handleInputNameChange}
          />
          <br />
          <TextField
            id="phone number"
            name="phone number"
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
          <Button
            variant="contained"
            onClick={handleSubmit}
            disabled={!(inputName && inputPhoneNumber)}
          >
            Login
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}
