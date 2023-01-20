import { CardContent, CardMedia, Card, Button } from "@mui/material";
import React from "react";
import "./MostPopularItem.css";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import { useSelector, useDispatch } from "react-redux";
import Login from "../../Login/Login";
import { REQUEST_STATUSES } from "../../../constants/apiRequestStatus";
import {
  selectLoginStatus,
  selectIsOpenDialog,
  loginFormVisibilityChanged,
} from "../../../slices/loginSlice";
export default function MostPopularItem({ name, photoName, price }) {
  const dispatch = useDispatch();
  const loginStatus = useSelector(selectLoginStatus);

  const handleClickAddToOrder = () => {
    if (!sessionStorage.getItem("userId")) {
      dispatch(loginFormVisibilityChanged(true));
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
          onClick={handleClickAddToOrder}
        >
          Add to Order
        </Button>
      </CardContent>
    </Card>
  );
}
