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

export default function CategorizedMenuItem({ name, price }) {
  const dispatch = useDispatch();
  const loginStatus = useSelector(selectLoginStatus);
  const isOpenDialog = useSelector(selectIsOpenDialog);

  const handleClickAddToOrder = () => {
    if (!sessionStorage.getItem("userId")) {
      dispatch(loginFormVisibilityChanged(true));
    }
  };
  return (
    <div>
      <AccordionDetails className="categorizedMenuItem">
        <div className="categorizedMenuItemDetails">
          <div className="categorizedMenuItemNameRating">
            <span className="categorizedMenuItemName">{name}</span>
          </div>
          <div className="categorizedMenuItemPrice">
            <span>{Math.round(price)}$</span>
          </div>
        </div>
        <div className="categorizedMenuItemButton">
          <Button
            variant="contained"
            endIcon={<AddShoppingCartIcon />}
            onClick={handleClickAddToOrder}
          >
            Add to Order
          </Button>
        </div>
      </AccordionDetails>
      <Login isLoginDialogOpen={isOpenDialog} />
    </div>
  );
}
