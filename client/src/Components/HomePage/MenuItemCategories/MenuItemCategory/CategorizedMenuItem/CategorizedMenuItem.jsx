import React from "react";
import "./CategorizedMenuItem.css";
import AccordionDetails from "@mui/material/AccordionDetails";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import { Button } from "@mui/material";
import { useSelector, useDispatch } from "react-redux";
import Login from "../../../../Login/Login";
import { REQUEST_STATUSES } from "../../../../../constants/apiRequestStatus";
import {
  selectLoginStatus,
  selectIsOpenDialog,
  loginFormVisibilityChanged,
} from "../../../../../slices/loginSlice";

export default function CategorizedMenuItem({ details }) {
  const dispatch = useDispatch();
  const loginStatus = useSelector(selectLoginStatus);
  const isOpenDialog = useSelector(selectIsOpenDialog);

  const handleClickOpen = () => {
    if (loginStatus !== REQUEST_STATUSES.succeeded) {
      dispatch(loginFormVisibilityChanged(true));
    }
  };
  return (
    <div>
      <AccordionDetails className="categorizedMenuItem">
        <div className="categorizedMenuItemDetails">
          <div className="categorizedMenuItemNameRating">
            <span className="categorizedMenuItemName">{details.name}</span>
          </div>
          <div className="categorizedMenuItemPrice">
            <span>{Math.round(details.price)}$</span>
          </div>
        </div>
        <div className="categorizedMenuItemButton">
          <Button
            variant="contained"
            endIcon={<AddShoppingCartIcon />}
            onClick={handleClickOpen}
          >
            Add to Order
          </Button>
        </div>
      </AccordionDetails>
      <Login open={isOpenDialog} />
    </div>
  );
}
