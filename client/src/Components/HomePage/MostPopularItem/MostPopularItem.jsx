import { CardContent, CardMedia } from "@mui/material";
import React from "react";
import { Card } from "@mui/material";
import "./MostPopularItem.css";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import { Button } from "@mui/material";
export default function MostPopularItem(props) {
  return (
    <Card className="mostPopularItemCard">
      <CardContent className="mostPopularItemTitle">
        <a>{props.item.name}</a>
      </CardContent>
      <CardMedia
        className="mostPopularItemImg"
        component="img"
        image={"images/menuItems/" + props.item.photoName}
      />
      <CardContent className="mostPopularItemInfo">
        <div className="mostPopularItemPrice">
          Price: <span>{Math.round(props.item.price)}</span>
        </div>
        <Button
          className="addToOrderButton"
          variant="contained"
          endIcon={<AddShoppingCartIcon />}
        >
          Add to Order
        </Button>
      </CardContent>
    </Card>
  );
}
