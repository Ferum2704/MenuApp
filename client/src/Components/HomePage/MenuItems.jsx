import React from "react";
import { Container } from "@mui/system";
import MostPopularItems from "./MostPopularItems/MostPopularItems";
import MenuItemCategories from "./MenuItemCategories/MenuItemCategories";
export default function MenuItems() {
  return (
    <Container sx={{ minHeight: "70vh" }}>
      <MostPopularItems />
      <MenuItemCategories />
    </Container>
  );
}
