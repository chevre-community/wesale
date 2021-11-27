import React, { useEffect, useState } from "react";

import { Controller, Keyboard, Mousewheel, Navigation, Thumbs } from "swiper";
import { Swiper, SwiperSlide } from "swiper/react";

import {
	Breadcrumb,
	CameraIcon,
	ChevronLeft,
	ChevronRight,
	CustomImage,
	DangerIcon,
	EyeOpenIcon,
	HeartIcon,
	InfoCard,
	ProductCard,
	ShareIcon,
} from "@/components";

import { useMain } from "@/context/providers/main-context";

const DetailsBySlug = ({ slug }) => {
	const [controlledSwiper, setControlledSwiper] = useState(null);
	const [controlledSwiperMain, setControlledSwiperMain] = useState(null);
	const [showPhone, setShowPhone] = useState(false);
	const { mainState } = useMain();

	useEffect(() => {}, []);
	return (
		<div className="page-wrapper">
			<Breadcrumb
				links={[
					{
						title: "Главная",
						href: "/",
					},
					{
						title: "Объявления",
						href: "/",
					},
				]}
			/>

			<div className="d-flex justify-content-between">
				<div>
					<h3 className="g-title__sm--bold text-primary-grey">{slug}</h3>
					<div className="d-flex align-items-center">
						<p className="g-caption__lg--regular with-dot details-page__with-dot">
							Квартира, метро Н.Нариманов
						</p>
						<p className="g-caption__lg--regular with-dot details-page__with-dot">
							<EyeOpenIcon />
							65
						</p>
						<p className="g-caption__lg--regular with-dot details-page__with-dot">
							Опубликовано: 18.02.2021
						</p>
					</div>
				</div>
				<div className="_flex-center">
					<a className="g-btn g-btn__icon with-gap-16" href="">
						<HeartIcon />
					</a>
					<a className="g-btn g-btn__icon with-gap-16" href="">
						<ShareIcon />
					</a>
					<a className="g-btn g-btn__icon with-gap-16" href="">
						<DangerIcon />
					</a>
				</div>
			</div>
			<div className="details-page-grid">
				<div className="details-page__swipers">
					<div className="details-page__swipers--main">
						<div className="details-page__swipers--widgets">
							<div className="widget widget--mint">Проверенно</div>
							<div className="widget widget--white with-icon">
								<CameraIcon />
								<span>+ 11 фото</span>
							</div>
						</div>
						<button className="g-btn-arrow details-page__swipers--next">
							<ChevronRight />
						</button>
						<button className="g-btn-arrow details-page__swipers--prev">
							<ChevronLeft />
						</button>
						<Swiper
							modules={[Navigation, Controller, Thumbs]}
							controller={{
								control: controlledSwiperMain,
							}}
							spaceBetween={16}
							slidesPerView={1}
							onSwiper={setControlledSwiper}
							onSlideChange={(e) => console.log(e)}
							direction="vertical"
							navigation={{
								prevEl: ".details-page__swipers--prev",
								nextEl: ".details-page__swipers--next",
							}}
						>
							{mainState.images.map(({ src }) => (
								<SwiperSlide key={src}>
									<CustomImage
										src={src}
										container_width={"100%"}
										container_height={"100%"}
										layout="fill"
										alt={"Wesale Announcement Details"}
									/>
								</SwiperSlide>
							))}
						</Swiper>
					</div>
					<div className="details-page__swipers--side">
						<Swiper
							modules={[Controller, Thumbs, Mousewheel, Keyboard]}
							controller={{
								control: controlledSwiper,
							}}
							spaceBetween={16}
							slidesPerView="auto"
							onSwiper={setControlledSwiperMain}
							direction="vertical"
							centeredSlides={true}
							touchRatio={0.2}
							slideToClickedSlide={true}
							onActiveIndexChange={(e) => console.log(e)}
							keyboard
							mousewheel
						>
							{mainState.images.map(({ src }) => (
								<SwiperSlide key={src}>
									<CustomImage
										src={src}
										layout="fill"
										container_width={"100%"}
										container_height={105}
										alt={"Wesale Announcement Details"}
									/>
								</SwiperSlide>
							))}
						</Swiper>
					</div>
				</div>
				<InfoCard
					showPhone={showPhone}
					setShowPhone={setShowPhone}
					currency={"$"}
					mortgage_price={1500}
					price={200000}
					phone_numbers={["+994 50 599 12 67", "+994 70 478 65 85"]}
					wp_phone={"+994 50 599 12 67"}
				/>
			</div>
			<div className="g-section">
				<p className="g-title__sm--bold">Похожие объявления</p>
				<div className="g-section-wrapper">
					<div className="g-section-cards">
						<ProductCard
							area={220}
							price={1200}
							rooms={3}
							images={mainState.images}
						/>
						<ProductCard
							area={220}
							price={1200}
							rooms={3}
							images={mainState.images}
						/>
						<ProductCard
							area={220}
							price={1200}
							rooms={3}
							images={mainState.images}
						/>
						<ProductCard
							area={220}
							price={1200}
							rooms={3}
							images={mainState.images}
						/>
					</div>
				</div>
			</div>
		</div>
	);
};

export const getStaticPaths = (ctx) => {
	console.log(ctx);

	return {
		paths: [
			{
				params: {
					slug: "23",
				},
			},
		],
		fallback: "blocking",
	};
};

export const getStaticProps = (ctx) => {
	const { slug } = ctx.params;

	return {
		props: {
			slug,
		},
		revalidate: 20,
	};
};

export default DetailsBySlug;
