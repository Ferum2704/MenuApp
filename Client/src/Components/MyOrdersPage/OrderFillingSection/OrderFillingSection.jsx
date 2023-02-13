import React from "react";
import "./OrderFillingSection.css";
import { Container } from "@mui/system";
import { useSelector, useDispatch } from "react-redux";
import { Button } from "@mui/material";
import {
  selectCurrentOrder,
  selectCurrentOrderError,
  selectCurrentOrderStatus,
  getCurrentOrder,
  cancelCurrentOrder,
} from "../../../slices/orderSlices/currentOrderSlice";
import MenuItemToOrder from "./MenuItemToOrder/MenuItemToOrder";
import { renderResultByStatus } from "../../../helpers/renderHelper";
import { useEffect } from "react";
import { getUserId, setUserId } from "../../../helpers/sessionHelper";

export default function OrderFillingSection() {
  var _ = require("lodash");
  const dispatch = useDispatch();

  // useEffect(() => {
  //   if (getUserId()) {
  //     dispatch(getCurrentOrder());
  //   }
  // }, []);

  const currentOrder = useSelector(selectCurrentOrder);
  const currentOrderStatus = useSelector(selectCurrentOrderStatus);
  const currentOrderError = useSelector(selectCurrentOrderError);

  const handleClickCancelOrder = (orderId) =>
    dispatch(cancelCurrentOrder(orderId));

  const successContentResult = (
    <div>
      <div className="currentOrderId">
        Order #
        {currentOrder.id &&
          currentOrder.id.slice(0, currentOrder.id.indexOf("-"))}
      </div>
      {currentOrder.orderedMenuItems &&
        currentOrder.orderedMenuItems.map((item) => (
          <MenuItemToOrder
            key={item.id}
            id={item.id}
            menuItemId={item.menuItemId}
            name={item.name}
            number={item.number}
            price={item.price}
          />
        ))}
      <div className="totalOrderPrice">
        Total order price:
        <span className="totalOrderPriceValue">{currentOrder.price}</span>
      </div>
      <div className="controlOrderButtons">
        <div>
          <Button
            className="controlOrderButton"
            variant="contained"
            color="error"
            onClick={() => handleClickCancelOrder(currentOrder.id)}
          >
            Cancel Order
          </Button>
        </div>
        <div>
          <Button
            className="controlOrderButton"
            variant="contained"
            color="success"
          >
            Confirm Order
          </Button>
        </div>
      </div>
    </div>
  );
  return (
    <Container
      sx={_.isEmpty(currentOrder) && { display: "none" }}
      maxWidth="lg"
      className="orderFillingSection"
    >
      {renderResultByStatus(
        currentOrderStatus,
        currentOrderError,
        successContentResult
      )}
    </Container>
  );
}
