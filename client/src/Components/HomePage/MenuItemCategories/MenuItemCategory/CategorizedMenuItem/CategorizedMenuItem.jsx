import React from "react";
import "./CategorizedMenuItem.css";
import AccordionDetails from "@mui/material/AccordionDetails";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import { Button } from "@mui/material";
import { useLoginUserId } from "../../../../../helpers/sessionHelper";

export default function CategorizedMenuItem({ name, price }) {
  const checkUserId = useLoginUserId();
  const handleClickAddToOrder = () => checkUserId();

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
    </div>
  );
}
