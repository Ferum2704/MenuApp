import React from "react";
import "./MenuItemToOrder.css";
import { Button } from "@mui/material";
import { Clear } from "@mui/icons-material";
import { Icon } from "@iconify/react";
import { IconButton } from "@mui/material";

export default function MenuItemToOrder({ name, number, price }) {
  return (
    <div className="menuItemToOrder">
      <div className="menuItemToOrderName">{name}</div>
      <div className="menuItemToOrderCounter">
        <IconButton>
          <Icon icon="carbon:subtract-alt" inline={true} color="red" />
        </IconButton>
        <div className="menuItemToOrderCounterValue">{number}</div>
        <IconButton>
          <Icon
            icon="material-symbols:add-circle-outline"
            inline={true}
            color="green"
          />
        </IconButton>
      </div>
      <div className="menuItemToOrderPrice">{price}</div>
      <div className="menuItemToOrderRemoveButtonWithText">
        <Button color="error" variant="contained" endIcon={<Clear />}>
          Remove
        </Button>
      </div>
      <div className="menuItemToOrderRemoveButton">
        <Button color="error" variant="contained">
          <Clear />
        </Button>
      </div>
    </div>
  );
}
