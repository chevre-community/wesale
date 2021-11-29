import { A11y, Navigation, Pagination } from "swiper";
import { Swiper, SwiperSlide } from "swiper/react";

import React, { memo } from "react";
import { FiHeart } from "react-icons/fi";

import Link from "next/link";

import { ContractIcon, CustomImage, PercentageIcon } from "@/components";

import classNames from "classnames";

const ProductCard = ({
	images,
	price,
	currency,
	rooms,
	area,
	floor,
	address,
	isFavourite,
}) => {
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
			<button
				className={classNames("product-card--like-btn", {
					filled: isFavourite,
				})}
			>
				<FiHeart strokeWidth={3} />
			</button>
			<div className="product-card__swiper">
				<Swiper {...params} navigation>
					{images?.map((image, idx) => (
						<SwiperSlide key={`slide_${idx}`}>
							<CustomImage
								src={image}
								key={image}
								width={750}
								height={400}
								className="product-card__img"
								alt="Wesale Product"
							/>
						</SwiperSlide>
					))}
					<div className="swiper-pagination"></div>
				</Swiper>
			</div>
			<div className="product-card__body">
				<Link href={`/announcement/details/${address}`} passHref>
					<a className="stretched-link" />
				</Link>
				<div className="d-flex justify-content-between flex-wrap">
					<p className="product-card__title mb-xxs">
						<span className="g-text__sm--bold">{price}</span>
						<span className="g-text__lg--regular">{currency}/мес</span>
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
					<span className="with-dot">{floor} этаж</span>
				</div>
				<span className="g-caption__lg--regular text-ntr-light-06">
					{address}
				</span>
			</div>
		</div>
	);
};

export default memo(ProductCard);
