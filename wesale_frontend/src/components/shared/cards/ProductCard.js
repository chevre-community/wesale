import React from "react";

import Link from "next/link";

import { ContractIcon, PercentageIcon } from "@/components";

import { Navigation, A11y, Pagination } from "swiper";
import { Swiper, SwiperSlide } from "swiper/react";

import { FiHeart } from "react-icons/fi";

const ProductCard = ({ images, price, rooms, area }) => {
  const params = {
    modules: [A11y, Navigation, Pagination],
    preloadImages: false,
    slidesPerView: 1,
    spaceBetween: 20,
    loop: true,
    spaceBetween: 30,
    pagination: {
      el: ".swiper-pagination",
      type: "bullets",
      clickable: true,
    },
  };

  return (
    <div className="product-card">
      <button className="product-card--like-btn">
        <FiHeart strokeWidth={3} />
      </button>
      <div className="product-card__swiper">
        <Swiper {...params} navigation>
          {images?.map((image, idx) => (
            <SwiperSlide key={`slide_${idx}`}>
              <img
                src={image.src}
                key={image.src}
                className="product-card__img"
                alt="Wesale Product"
              />
            </SwiperSlide>
          ))}
          <div className="swiper-pagination"></div>
        </Swiper>
      </div>
      <div className="product-card__body">
        <Link href="/" passHref>
          <a className="stretched-link" />
        </Link>
        <div className="d-flex justify-content-between flex-wrap">
          <p className="product-card__title mb-xxs">
            <span className="g-text__sm--bold">{price}</span>
            <span className="g-text__lg--regular">₼/мес</span>
          </p>
          <div className="product-card__icons">
            <span>
              <ContractIcon />
            </span>
            <span>
              <PercentageIcon />
            </span>
          </div>
        </div>
        <div className="d-flex align-items-center flex-wrap mb-xxs">
          <span className="with-dot">{rooms} комн.</span>
          <span className="with-dot">
            {area} м <sup>2</sup>
          </span>
          <span className="with-dot">14/17 этаж</span>
        </div>
        <span className="g-caption__lg--regular text-ntr-light-06">
          Квартира, метро Н.Нариманов
        </span>
      </div>
    </div>
  );
};

export default ProductCard;
