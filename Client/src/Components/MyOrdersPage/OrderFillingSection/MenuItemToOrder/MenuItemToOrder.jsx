import React from "react";
import "./MenuItemToOrder.css";
import { Button } from "@mui/material";
import { Clear } from "@mui/icons-material";
import { Icon } from "@iconify/react";
import { IconButton } from "@mui/material";
import {
  addMenuItemInstance,
  subtractMenuItemInstance,
  removeMenuItemFromOrder,
} from "../../../../slices/orderSlices/currentOrderSlice";
import { useDispatch } from "react-redux";

export default function MenuItemToOrder({
  id,
  menuItemId,
  name,
  number,
  price,
}) {
  const dispatch = useDispatch();

  const handleClickAddToCounter = (menuItemId) =>
    dispatch(addMenuItemInstance({ menuItemId }));
  const handleClickSubractFromCounter = (menuItemId) =>
    dispatch(subtractMenuItemInstance({ menuItemId }));
  const handleClickRemoveFromOrder = (id) =>
    dispatch(removeMenuItemFromOrder(id));

  return (
    <div className="menuItemToOrder">
      <div className="menuItemToOrderName">{name}</div>
      <div className="menuItemToOrderCounter">
        <IconButton onClick={() => handleClickSubractFromCounter(menuItemId)}>
          <Icon icon="carbon:subtract-alt" inline={true} color="red" />
        </IconButton>
        <div className="menuItemToOrderCounterValue">{number}</div>
        <IconButton onClick={() => handleClickAddToCounter(menuItemId)}>
          <Icon
            icon="material-symbols:add-circle-outline"
            inline={true}
            color="green"
          />
        </IconButton>
      </div>
      <div className="menuItemToOrderPrice">{price.toFixed(2)}</div>
      <div className="menuItemToOrderRemoveButtonWithText">
        <Button
          color="error"
          variant="contained"
          endIcon={<Clear />}
          onClick={() => handleClickRemoveFromOrder(id)}
        >
          Remove
        </Button>
      </div>
      <div className="menuItemToOrderRemoveButton">
        <Button
          color="error"
          variant="contained"
          onClick={() => handleClickRemoveFromOrder(id)}
        >
          <Clear />
        </Button>
      </div>
    </div>
  );
}
