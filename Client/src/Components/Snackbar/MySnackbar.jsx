import React from "react";
import { Alert, Snackbar } from "@mui/material";
export default function MySnackbar({ state, handleClose }) {
  const vertical = "top";
  const horizontal = "center";
  const { message, severity, open } = state;

  return (
    <Snackbar
      open={open}
      autoHideDuration={3000}
      anchorOrigin={{ vertical, horizontal }}
      onClose={handleClose}
    >
      <Alert severity={severity} sx={{ width: "100%" }} onClose={handleClose}>
        {message}
      </Alert>
    </Snackbar>
  );
}
