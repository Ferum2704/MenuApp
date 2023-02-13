import { CardContent, CardMedia, Card, Button } from "@mui/material";
import React from "react";
import "./MostPopularItem.css";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import { useDispatch } from "react-redux";
import { checkUserIdForLogin } from "../../../helpers/sessionHelper";
import { addMenuItemToOrder } from "../../../slices/orderSlices/currentOrderSlice";
import { getUserId } from "../../../helpers/sessionHelper";

export default function MostPopularItem({ id, name, photoName, price }) {
  const dispatch = useDispatch();
  const handleClickAddToOrder = (menuItem) => {
    checkUserIdForLogin(dispatch);
    if (getUserId()) {
      dispatch(addMenuItemToOrder(menuItem));
    }
  };
  return (
    <Card className="mostPopularItemCard">
      <CardContent className="mostPopularItemTitle">
        <a>{name}</a>
      </CardContent>
      <CardMedia
        className="mostPopularItemImg"
        component="img"
        image={"images/menuItems/" + photoName}
      />
      <CardContent className="mostPopularItemInfo">
        <div className="mostPopularItemPrice">
          Price: <span>{Math.round(price)}</span>
        </div>
        <Button
          className="addToOrderButton"
          variant="contained"
          endIcon={<AddShoppingCartIcon />}
          onClick={() => handleClickAddToOrder({ id, name, price })}
        >
          Add to Order
        </Button>
      </CardContent>
    </Card>
  );
}
