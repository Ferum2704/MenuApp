import React from "react";
import { Alert, Snackbar } from "@mui/material";
export default function MySnackbar(props) {
  const { vertical, horizontal, open, severity, message, handleClose } =
    props.state;

  return (
    <Snackbar
      open={open}
      autoHideDuration={3000}
      anchorOrigin={{ vertical, horizontal }}
      key={vertical + horizontal}
      onClose={handleClose}
    >
      <Alert severity={severity} sx={{ width: "100%" }} onClose={handleClose}>
        {message}
      </Alert>
    </Snackbar>
  );
}
