import React from "react";
import MostPopularItem from "../MostPopularItem/MostPopularItem";
import { ArrowBackIosNew, ArrowForwardIos } from "@mui/icons-material";
import { Swiper, SwiperSlide } from "swiper/react";
import { Navigation, Pagination } from "swiper";
import { MENUITEM_SERVICE_URL } from "../../../servicesURLs";
import { useState, useEffect } from "react";
import axios from "axios";
import { Container } from "@mui/system";
import "./MostPopularItems.css";
import "swiper/css/bundle";

export default function MostPopularItems() {
  const [mostPopularItems, setMostPopularItems] = useState([]);
  const url = "/GetMostPopularMenuItems";

  useEffect(() => {
    axios.get(MENUITEM_SERVICE_URL + url).then((response) => {
      const received = response.data;
      setMostPopularItems(received);
    });
  }, []);
  return (
    <Container maxWidth="lg" className="mostPopularItems">
      <p className="mostPopularItemsTitle">Most Popular Menu Items</p>
      <div class="swiper-button-prev swiper-button-prev-unique"></div>
      <div class="swiper-button-next swiper-button-next-unique"></div>
      <Swiper
        className="mostPopularItemsSwiper"
        modules={[Navigation, Pagination]}
        spaceBetween={20}
        navigation={{
          nextEl: ".swiper-button-next-unique",
          prevEl: ".swiper-button-prev-unique",
        }}
        slidesPerView={2}
        pagination={{ clickable: true }}
        breakpoints={{
          500: {
            slidesPerView: 3,
            spaceBetween: 20,
          },
        }}
      >
        {Array.isArray(mostPopularItems) ? (
          mostPopularItems.map((mostPopularItem) => (
            <SwiperSlide key={mostPopularItem.id}>
              <MostPopularItem item={mostPopularItem} />
            </SwiperSlide>
          ))
        ) : (
          <div></div>
        )}
        {Array.isArray(mostPopularItems) ? (
          mostPopularItems.map((mostPopularItem) => (
            <SwiperSlide key={mostPopularItem.id}>
              <MostPopularItem item={mostPopularItem} />
            </SwiperSlide>
          ))
        ) : (
          <div></div>
        )}
      </Swiper>
    </Container>
  );
}
