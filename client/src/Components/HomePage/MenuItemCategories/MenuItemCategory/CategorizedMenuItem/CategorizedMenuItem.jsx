import React from "react";
import "./CategorizedMenuItem.css";
import AccordionDetails from "@mui/material/AccordionDetails";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import { Button } from "@mui/material";
import { useDispatch } from "react-redux";
import { checkUserIdForLogin } from "../../../../../helpers/sessionHelper";
import { addMenuItemToOrder } from "../../../../../slices/ordersSlice";

export default function CategorizedMenuItem({ id, name, price }) {
  const dispatch = useDispatch();
  const handleClickAddToOrder = (menuItemId, menuItemPrice) => {
    checkUserIdForLogin(dispatch);
    dispatch(addMenuItemToOrder(menuItemId, menuItemPrice));
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
            onClick={() => handleClickAddToOrder(id, price)}
          >
            Add to Order
          </Button>
        </div>
      </AccordionDetails>
    </div>
  );
}
