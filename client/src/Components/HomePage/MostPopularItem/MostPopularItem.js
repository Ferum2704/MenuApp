import { CardContent, CardMedia } from "@mui/material";
import React from "react";
import { Card } from "@mui/material";
import "./MostPopularItem.css";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import { Button } from "@mui/material";
export default function MostPopularItem() {
  return (
    <Card className="mostPopularItemCard">
      <CardContent className="mostPopularItemTitle">
        <a>Menu Item name</a>
      </CardContent>
      <CardMedia component="img" image="images/menuItems/salads/salad2.jpg" />
      <CardContent className="mostPopularItemInfo">
        <div className="mostPopularItemPrice">
          Price: <span>232</span>
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
