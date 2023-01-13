import React from "react";
import { Alert, Snackbar } from "@mui/material";
export default function MySnackbar({ handleClose, isOpen, message, severity }) {
  return (
    <Snackbar
      open={isOpen}
      autoHideDuration={3000}
      anchorOrigin={{ vertical: "top", horizontal: "center" }}
      onClose={handleClose}
    >
      <Alert severity={severity} sx={{ width: "100%" }} onClose={handleClose}>
        {message}
      </Alert>
    </Snackbar>
  );
}
