import React from "react";
import {
  Button,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  snackbarClasses,
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
  const [isSnackbarOpen, setIsSnackbarOpen] = useState(false);
  const [inputName, setInputName] = useState("");
  const [inputPhoneNumber, setInputPhoneNumber] = useState("");

  let snackbarState = {
    message: "",
    severity: "success",
    open: isSnackbarOpen,
  };

  const dispatch = useDispatch();
  const error = useSelector(selectLoginError);
  const status = useSelector(selectLoginStatus);

  useEffect(() => {
    switch (status) {
      case REQUEST_STATUSES.failed:
        setIsSnackbarOpen(true);
        snackbarState.message = error;
        snackbarState.severity = "error";
        break;
      case REQUEST_STATUSES.succeeded:
        setIsSnackbarOpen(true);
        snackbarState.message = "Login is successful";
        dispatch(loginFormVisibilityChanged(false));
        break;
      default:
        break;
    }
  }, [status]);

  const handleCloseSnackBar = () => setIsSnackbarOpen(true);
  const handleInputNameChange = (e) => setInputName(e.target.value);
  const handleInputPhoneNumber = (e) => setInputPhoneNumber(e.target.value);
  const handleCloseForm = () => dispatch(loginFormVisibilityChanged(false));
  const handleSubmit = () => {
    dispatch(resetStatus());
    dispatch(addNewUser({ inputName, inputPhoneNumber }));
  };
  return (
    <div>
      <MySnackbar handleClose={handleCloseSnackBar} state={snackbarState} />
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
