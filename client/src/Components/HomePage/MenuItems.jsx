import React from "react";
import { Container } from "@mui/system";
import { Swiper, SwiperSlide } from "swiper/react";
import "swiper/css";
import "swiper/css/pagination";
import MostPopularItems from "./MostPopularItems/MostPopularItems";
import MenuItemCategories from "./MenuItemCategories/MenuItemCategories";
import { Pagination } from "swiper";
export default function MenuItems() {
  return (
    <Container sx={{ minHeight: "70vh" }}>
      <MostPopularItems />
      <MenuItemCategories />
    </Container>
  );
}
