import { CardContent, CardMedia } from "@mui/material";
import React from "react";
import { Card } from "@mui/material";
import "./MostPopularItem.css";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import { Button } from "@mui/material";
export default function MostPopularItem({ name, photoName, price }) {
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
        >
          Add to Order
        </Button>
      </CardContent>
    </Card>
  );
}
