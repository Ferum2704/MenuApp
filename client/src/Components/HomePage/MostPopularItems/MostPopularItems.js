import React from "react";
import MostPopularItem from "../MostPopularItem/MostPopularItem";
import { Swiper, SwiperSlide } from "swiper/react";
import { Navigation, Pagination } from "swiper";
import "./MostPopularItems.css";
import "swiper/css/bundle";
export default function MostPopularItems() {
  return (
    <div>
      <p className="mostPopularItemsTitle">Most Popular Menu Items</p>
      <Swiper
        modules={[Navigation, Pagination]}
        spaceBetween={20}
        slidesPerView={2}
        navigation
        pagination={{ clickable: true }}
        breakpoints={{
          430: {
            slidesPerView: 3,
            spaceBetween: 20,
          },
        }}
      >
        <SwiperSlide>
          <MostPopularItem></MostPopularItem>
        </SwiperSlide>
        <SwiperSlide>
          <MostPopularItem></MostPopularItem>
        </SwiperSlide>
        <SwiperSlide>
          <MostPopularItem></MostPopularItem>
        </SwiperSlide>
        <SwiperSlide>
          <MostPopularItem></MostPopularItem>
        </SwiperSlide>
      </Swiper>
    </div>
  );
}
