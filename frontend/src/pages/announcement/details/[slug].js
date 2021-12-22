import { wrapper } from "@/app/store";

import React, { useEffect, useRef, useState } from "react";
import { BsFillExclamationCircleFill } from "react-icons/bs";

import Link from "next/link";

import { Controller, Keyboard, Mousewheel, Navigation, Thumbs } from "swiper";
import { Swiper, SwiperSlide } from "swiper/react";

import {
	Breadcrumb,
	Button,
	CameraIcon,
	ChevronLeft,
	ChevronRight,
	CustomImage,
	DangerIcon,
	EyeOpenIcon,
	FloorIcon,
	HeartIcon,
	HomeIcon,
	HouseplanIcon,
	InfoCard,
	ProductCard,
	ShareIcon,
	SquareIcon,
} from "@/components";

import { useMain } from "@/context/providers/main-context";

import classNames from "classnames";

import colors from "@/styles/modules/colors.module.scss";

const widgets = [
	"Интернет",
	"Холодильник",
	"Стиральная машина",
	"Кухонная мебель",
	"Кондиционер",
	"Телевизор",
	"Ванна",
	"Телефон",
	"Душевая кабина",
];

const DetailsBySlug = ({ slug }) => {
	const descriptionRef = useRef();
	const [controlledSwiper, setControlledSwiper] = useState(null);
	const [controlledSwiperMain, setControlledSwiperMain] = useState(null);
	const [showPhone, setShowPhone] = useState(false);
	const { mainState } = useMain();

	useEffect(() => {}, []);

	const showMore = ({ target }) => {
		descriptionRef.current.classList.remove("has-more");
		target.style.display = "none";
	};

	return (
		<div className="page-wrapper">
			<Breadcrumb
				links={[
					{
						title: "Главная",
						href: "/home",
					},
					{
						title: "Объявления",
						href: "/home",
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
				<div>
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
								direction="vertical"
								navigation={{
									prevEl: ".details-page__swipers--prev",
									nextEl: ".details-page__swipers--next",
								}}
							>
								{mainState.images.map((src) => (
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
								keyboard
								mousewheel
							>
								{mainState.images.map((src) => (
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
					<div className="details-page__info">
						<div className="details-page__info--item">
							<div className="details-page__info--item-icon">
								<HomeIcon fill="none" pathStroke="#8D90B9" />
							</div>
							<div className="details-page__info--item-body">
								<p className="g-caption__lg--regular text-ntr-light-08">
									Категория
								</p>
								<p className="g-text__sm--semibold text-primary-grey">
									Новостройка
								</p>
							</div>
						</div>
						<div className="details-page__info--item">
							<div className="details-page__info--item-icon">
								<FloorIcon />
							</div>
							<div className="details-page__info--item-body">
								<p className="g-caption__lg--regular text-ntr-light-08">Этаж</p>
								<p className="g-text__sm--semibold text-primary-grey">
									14 / 17
								</p>
							</div>
						</div>
						<div className="details-page__info--item">
							<div className="details-page__info--item-icon">
								<SquareIcon />
							</div>
							<div className="details-page__info--item-body">
								<p className="g-caption__lg--regular text-ntr-light-08">
									Площадь
								</p>
								<p className="g-text__sm--semibold text-primary-grey">220 м2</p>
							</div>
						</div>
						<div className="details-page__info--item">
							<div className="details-page__info--item-icon">
								<HouseplanIcon />
							</div>
							<div className="details-page__info--item-body">
								<p className="g-caption__lg--regular text-ntr-light-08">
									Количество комнат
								</p>
								<p className="g-text__sm--semibold text-primary-grey">4</p>
							</div>
						</div>
					</div>
					<div className="details-page__section-wrapper">
						<div className="section-tabs">
							<button className="section-tab active">О квартире</button>
							<button className="section-tab">Описание</button>
							<button className="section-tab">О сделке</button>
							<button className="section-tab">Видео</button>
							<button className="section-tab">На карте</button>
							<button className="section-tab">Ипотека</button>
						</div>
						<div className="details-page__section">
							<p className="details-page__section-title">О квартире</p>
							<div className="details-table">
								<div className="details-table__cell">
									<p className="details-table__cell--title">Жилая площадь:</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">110 м2</p>
								</div>
								<div className="details-table__cell">
									<p className="details-table__cell--title">
										Комунальные расходы:
									</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">Включены частично</p>
								</div>
								<div className="details-table__cell">
									<p className="details-table__cell--title">Год постройки:</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">2004 год</p>
								</div>
								<div className="details-table__cell">
									<p className="details-table__cell--title">Мебель:</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">Есть</p>
								</div>
								<div className="details-table__cell">
									<p className="details-table__cell--title">Ремонт:</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">Косметический</p>
								</div>
								<div className="details-table__cell">
									<p className="details-table__cell--title">
										Количество спален:
									</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">3</p>
								</div>
								<div className="details-table__cell">
									<p className="details-table__cell--title">Материал дома:</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">Каменный</p>
								</div>
								<div className="details-table__cell">
									<p className="details-table__cell--title">
										Количество балконов:
									</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">
										2, закрытый, открытый
									</p>
								</div>
								<div className="details-table__cell">
									<p className="details-table__cell--title">Отопление:</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">Есть</p>
								</div>
								<div className="details-table__cell">
									<p className="details-table__cell--title">Парковка</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">Закрытая</p>
								</div>
								<div className="details-table__cell">
									<p className="details-table__cell--title">Лифт:</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">Есть</p>
								</div>
								<div className="details-table__cell">
									<p className="details-table__cell--title">Санузел:</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">Раздельный</p>
								</div>
							</div>
							<div className="details-page__widgets">
								<p className="details-page__widgets-title">В доме есть:</p>
								<div className="widget-grid">
									{widgets?.map((widget) => (
										<div className="widget widget--grey" key={widget}>
											{widget}
										</div>
									))}
								</div>
							</div>
						</div>
						<div className="details-page__section">
							<p className="details-page__section-title">Описание</p>
							<div
								ref={descriptionRef}
								className={classNames("details-page__description", {
									"has-more": descriptionRef?.current?.clientHeight >= 180,
								})}
							>
								<p>Квартира сдаётся с Wesale, а значит все для вас:</p>
								<ul>
									<li>без залога </li>
									<li>без единоразовой комиссии</li>
									<li>
										с поддержкой от наших специалистов в процессе проживания
									</li>
								</ul>
								<p>
									Мы можем показать вам квартиру онлайн - благодаря уникальному
									3Д туру - это также детально, как вживую, только вы не тратите
									время на дорогу и запись возможна на ближайшее время 🙂
								</p>
								<p>
									Стильная, прекрасно оформленная квартира, в которой всё
									необходимое для комфортной жизни.
								</p>
								<p>
									Мы можем показать вам квартиру онлайн - благодаря уникальному
									3Д туру - это также детально, как вживую, только вы не тратите
									время на дорогу и запись возможна на ближайшее время 🙂
								</p>
								<p>
									Стильная, прекрасно оформленная квартира, в которой всё
									необходимое для комфортной жизни.
								</p>
							</div>
							<div className="mt-sm">
								<button className="g-btn-secondary" onClick={showMore}>
									Показать все
								</button>
							</div>
						</div>
						<div className="details-page__section">
							<div className="rent-card">
								<div className="rent-card__img-wrapper">
									<div className="rent-card__img">
										<img
											src="/static/svgs/illustration-2.svg"
											alt="Rent an apartment"
										/>
									</div>
								</div>
								<div className="rent-card__content">
									<div className="flex-center-between">
										<div>
											<p className="g-title__sm--bold">
												Хотите сдать квартиру?
											</p>
											<p className="g-caption__lg--regular">
												Это займет не больше пяти минут!
											</p>
										</div>
										<Button variant="primary">Выставить объявление</Button>
									</div>
								</div>
							</div>
						</div>
						<div className="details-page__section">
							<p className="details-page__section-title">О сделке</p>
							<div className="details-table">
								<div className="details-table__cell">
									<p className="details-table__cell--title">Тип сделки:</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">Аренда</p>
								</div>
								<div className="details-table__cell">
									<p className="details-table__cell--title">
										Можно с животными
									</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">да</p>
								</div>
								<div className="details-table__cell">
									<p className="details-table__cell--title">Тип аренды:</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">Долгосрочная</p>
								</div>
								<div className="details-table__cell">
									<p className="details-table__cell--title">Можно с детьми</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">нет</p>
								</div>
								<div className="details-table__cell">
									<p className="details-table__cell--title">Залог</p>
									<div className="details-table__cell--divider"></div>
									<p className="details-table__cell--info">есть</p>
								</div>
							</div>
						</div>
						<div className="details-page__section">
							<p className="details-page__section-title">Видео</p>
						</div>
						<div className="details-page__section">
							<p className="details-page__section-title">На карте</p>
						</div>
						<div className="details-page__section">
							<p className="details-page__section-title">Ипотека</p>
							<div className="g-alert-info g-alert-info--grey">
								<div className="g-alert-info__icon">
									<BsFillExclamationCircleFill color={colors["ntr-light-01"]} />
								</div>
								<p className="g-alert-info__text">
									HAZİR İPOTEKA!!!Inqlabda Asan Xidmetle Uzbe-Uzde QAZLI,Kupcali
									Menzil Satilir!Hazir Ipoteka!Oz adimadir menzil.Oz
									menzilimdir.Hazir ipotekadadir:ilkin odenis 178000AZN,Banka
									Borcu 14il Ayliq odenis 1400AZN.(Bu Gune Borcu Banki Baglasag
									135000AZN).Super temirli menzildir.
								</p>
							</div>
							<div className="mt-sm mb-md-24">
								<div className="mortgage-card">
									<div className="mortgage-card__section">
										<div className="mortgage-card__heading">
											<div className="circle-icon mortgage-card__heading--icon">
												<HomeIcon fill="#fff" pathStroke="#fff" />
											</div>
											<p className="g-text__lg--semibold text-white">
												Квартира на метро Н. Нариманова
											</p>
										</div>
									</div>
									<div className="mortgage-card__section">
										<p className="g-caption__lg--regular text-white">
											Ежемесячный платеж
										</p>
										<div className="g-text__lg--semibold text-white">
											7600 ₼
										</div>
									</div>
									<div className="mortgage-card__section">
										<p className="g-caption__lg--regular text-white">
											Первоначальный взнос
										</p>
										<div className="g-text__lg--semibold text-white">
											37 500 ₼
										</div>
									</div>
								</div>
							</div>
							<Link href="/home" passHref>
								<a className="g-btn-secondary">Подать заявку</a>
							</Link>
						</div>
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
			<div className="mt-lg">
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
		</div>
	);
};

export const getServerSideProps = wrapper.getServerSideProps(
	(store) => async (ctx) => {
		return {
			props: {
				slug: ctx?.params?.slug,
			},
		};
	}
);

// export const getStaticPaths = (ctx) => {
// 	return {
// 		paths: [
// 			{
// 				params: {
// 					slug: "23",
// 				},
// 			},
// 		],
// 		fallback: "blocking",
// 	};
// };

// export const getStaticProps = (ctx) => {
// 	const { slug } = ctx.params;

// 	return {
// 		props: {
// 			slug,
// 		},
// 		revalidate: 20,
// 	};
// };

export default DetailsBySlug;
