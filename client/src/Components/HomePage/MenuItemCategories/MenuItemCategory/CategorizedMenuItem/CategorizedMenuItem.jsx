import React from "react";
import "./CategorizedMenuItem.css";
import AccordionDetails from "@mui/material/AccordionDetails";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import { Button } from "@mui/material";
export default function CategorizedMenuItem(props) {
  return (
    <AccordionDetails className="categorizedMenuItem">
      <div className="categorizedMenuItemDetails">
        <div className="categorizedMenuItemNameRating">
          <span className="categorizedMenuItemName">{props.details.name}</span>
        </div>
        <div className="categorizedMenuItemPrice">
          <span>{Math.round(props.details.price)}$</span>
        </div>
      </div>
      <div className="categorizedMenuItemButton">
        <Button variant="contained" endIcon={<AddShoppingCartIcon />}>
          Add to Order
        </Button>
      </div>
    </AccordionDetails>
  );
}
