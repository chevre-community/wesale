import React from "react";

import Link from "next/link";

import { A11y, Navigation } from "swiper";
import { Swiper, SwiperSlide } from "swiper/react";

import {
	Banner,
	ChevronLeft,
	ChevronRight,
	CustomImage,
	ProductCard,
} from "@/components";

import { useMain } from "@/context/providers/main-context";

const Index = () => {
	const { mainState } = useMain();

	return (
		<>
			<Banner />
			<div className="g-section">
				<div className="flex-center-between">
					<p className="g-title__sm--bold">Последние объявления</p>
					<div className="g-section-tabs">
						<button className="g-section-tab active">Все</button>
						<button className="g-section-tab">Квартиры</button>
						<button className="g-section-tab">Дома</button>
						<button className="g-section-tab">Объекты</button>
					</div>
				</div>
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
					<Link href="/search" passHref>
						<a className="g-btn-secondary">Показать еще</a>
					</Link>
				</div>
			</div>
			<div className="g-section">
				<div className="custom-cards">
					<div className="custom-card">
						<p className="custom-card__title">Аренда без рисков</p>
						<div className="custom-card__img">
							<img src="/static/svgs/home/illustration-1.svg" alt="WeSale" />
						</div>
					</div>
					<div className="custom-card">
						<p className="custom-card__title">Всё честно и прозрачно</p>
						<div className="custom-card__img">
							<img src="/static/svgs/home/illustration-2.svg" alt="WeSale" />
						</div>
					</div>
					<div className="custom-card">
						<p className="custom-card__title">Быстрая аренда</p>
						<div className="custom-card__img">
							<img src="/static/svgs/home/illustration-3.svg" alt="WeSale" />
						</div>
					</div>
				</div>
				<div className="quick-links">
					<div className="quick-links-card">
						<p className="quick-links__title">Купить квартиру</p>
						<div className="quick-links__grid">
							<ul className="quick-links__list">
								<li>
									<a href="">1 комнатную</a>
								</li>
								<li>
									<a href="">2 комнатную</a>
								</li>
								<li>
									<a href="">3 комнатную</a>
								</li>
								<li>
									<a href="">4 комнатную</a>
								</li>
							</ul>
							<ul className="quick-links__list">
								<li>
									<a href="">Cтудию</a>
								</li>
								<li>
									<a href="">Квартиры в Баку</a>
								</li>
							</ul>
						</div>
					</div>
					<div className="quick-links-card">
						<p className="quick-links__title">Купить квартиру</p>
						<div className="quick-links__grid">
							<ul className="quick-links__list">
								<li>
									<a href="">1 комнатную</a>
								</li>
								<li>
									<a href="">2 комнатную</a>
								</li>
								<li>
									<a href="">3 комнатную</a>
								</li>
								<li>
									<a href="">4 комнатную</a>
								</li>
							</ul>
							<ul className="quick-links__list">
								<li>
									<a href="">Cтудию</a>
								</li>
								<li>
									<a href="">Квартиры в Баку</a>
								</li>
							</ul>
						</div>
					</div>
					<div className="quick-links-card">
						<p className="quick-links__title">Купить квартиру</p>
						<div className="quick-links__grid">
							<ul className="quick-links__list">
								<li>
									<a href="">1 комнатную</a>
								</li>
								<li>
									<a href="">2 комнатную</a>
								</li>
								<li>
									<a href="">3 комнатную</a>
								</li>
								<li>
									<a href="">4 комнатную</a>
								</li>
							</ul>
							<ul className="quick-links__list">
								<li>
									<a href="">Cтудию</a>
								</li>
								<li>
									<a href="">Квартиры в Баку</a>
								</li>
							</ul>
						</div>
					</div>
				</div>
			</div>
			<div className="g-section">
				<div className="flex-center-between">
					<p className="g-title__sm--bold">Рекомендации для вас</p>
					<div className="g-section-tabs">
						<button className="g-section-tab active">Все</button>
						<button className="g-section-tab">Квартиры</button>
						<button className="g-section-tab">Дома</button>
						<button className="g-section-tab">Объекты</button>
					</div>
				</div>
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
					<Link href="/search" passHref>
						<a className="g-btn-secondary">Показать еще</a>
					</Link>
				</div>
			</div>
			<div className="g-section">
				<div className="advertisement">
					<div className="advertisement-body">
						<div className="advertisement-logo">
							<CustomImage
								src={"/static/svgs/brands/expressbank.svg"}
								width={180}
								height={50}
								alt={"Expressbank"}
							/>
						</div>
						<h4 className="advertisement-title">Ипотека от 8% годовых</h4>
						<p className="advertisement-subtitle">
							Лучшие ипотечные ставки в нашем партнерсом Банке
						</p>
					</div>
					<div className="advertisement-illustration-wrapper">
						<div className="advertisement-illustration">
							<img src="/static/svgs/promo-models.svg" alt="" />
						</div>
					</div>
				</div>
			</div>
			<div className="g-section">
				<div className="agencies">
					<div className="flex-center-between">
						<p className="g-title__sm--bold">Агентства</p>
						<a href="" className="g-btn-secondary">
							Показать все
						</a>
					</div>
					<div className="agencies-swiper">
						<button
							className="g-btn-arrow mr-sm agency-nav agency-nav-prev"
							id="agency-swiper-prev"
						>
							<ChevronLeft />
						</button>
						<button
							className="g-btn-arrow mr-sm agency-nav agency-nav-next"
							id="agency-swiper-next"
						>
							<ChevronRight />
						</button>
						<Swiper
							slidesPerView="auto"
							spaceBetween={20}
							modules={[Navigation, A11y]}
							navigation={{
								prevEl: "#agency-swiper-prev",
								nextEl: "#agency-swiper-next",
							}}
							loop={true}
						>
							<SwiperSlide>
								<div className="agency-card">
									<Link href="/agencies" passHref>
										<a className="stretched-link"></a>
									</Link>
									<div className="agency-card__img">
										<CustomImage
											container_width={"100%"}
											container_height={175}
											layout="fill"
											src={"/static/svgs/brands/real-emlak.svg"}
											alt={"Ekskluziv Emlak | WESALE"}
										/>
									</div>
									<div className="agency-card__body">
										<p className="agency-card__title">
											Real Əmlak Həzi Aslanov daşınmaz əmlak agentliyi
										</p>
										<p className="agency-card__ads">444 объявлений</p>
									</div>
								</div>
							</SwiperSlide>
							<SwiperSlide>
								<div className="agency-card">
									<Link href="/agencies" passHref>
										<a className="stretched-link"></a>
									</Link>
									<div className="agency-card__img">
										<CustomImage
											container_width={"100%"}
											container_height={175}
											layout="fill"
											src={"/static/svgs/brands/ekskluziv-emlak.svg"}
											alt={
												"Ekskluziv Əmlak 28 may daşınmaz əmlak agentliyi | WESALE"
											}
										/>
									</div>
									<div className="agency-card__body">
										<p className="agency-card__title">
											Ekskluziv Əmlak 28 may daşınmaz əmlak agentliyi
										</p>
										<p className="agency-card__ads">444 объявлений</p>
									</div>
								</div>
							</SwiperSlide>
							<SwiperSlide>
								<div className="agency-card">
									<Link href="/agencies" passHref>
										<a className="stretched-link"></a>
									</Link>
									<div className="agency-card__img">
										<CustomImage
											container_width={"100%"}
											container_height={175}
											layout="fill"
											src={"/static/svgs/brands/rahat-ev.svg"}
											alt={"Rahat Ev | WESALE"}
										/>
									</div>
									<div className="agency-card__body">
										<p className="agency-card__title">Rahat Ev</p>
										<p className="agency-card__ads">444 объявлений</p>
									</div>
								</div>
							</SwiperSlide>
							<SwiperSlide>
								<div className="agency-card">
									<Link href="/agencies" passHref>
										<a className="stretched-link"></a>
									</Link>
									<div className="agency-card__img">
										<CustomImage
											container_width={"100%"}
											container_height={175}
											layout="fill"
											src={"/static/svgs/brands/new-house.svg"}
											alt={
												"New House Mətbuat daşınmaz əmlak agentliyi | WESALE"
											}
										/>
									</div>
									<div className="agency-card__body">
										<p className="agency-card__title">
											New House Mətbuat daşınmaz əmlak agentliyi
										</p>
										<p className="agency-card__ads">444 объявлений</p>
									</div>
								</div>
							</SwiperSlide>
							<SwiperSlide>
								<div className="agency-card">
									<Link href="/agencies" passHref>
										<a className="stretched-link"></a>
									</Link>
									<div className="agency-card__img">
										<CustomImage
											container_width={"100%"}
											container_height={175}
											layout="fill"
											src={"/static/svgs/brands/inci-emlak.svg"}
											alt={"İnci Əmlak daşınmaz əmlak agentliyi | WESALE"}
										/>
									</div>
									<div className="agency-card__body">
										<p className="agency-card__title">
											İnci Əmlak daşınmaz əmlak agentliyi
										</p>
										<p className="agency-card__ads">444 объявлений</p>
									</div>
								</div>
							</SwiperSlide>
						</Swiper>
					</div>
				</div>
			</div>
		</>
	);
};

export default Index;
