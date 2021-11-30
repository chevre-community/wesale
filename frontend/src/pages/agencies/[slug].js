import { rem } from "@/lib";

import React, { useEffect, useRef, useState } from "react";
import { Pagination } from "react-bootstrap";

import {
	Breadcrumb,
	CallIcon,
	CustomImage,
	EyeOpenIcon,
	GSelect,
	LocationIcon,
	ProductCard,
	TimeCircleIcon,
} from "@/components";

import { useMain } from "@/context/providers/main-context";

import classNames from "classnames";

const options = [
	{
		label: "Все",
		value: "Все",
	},
	{
		label: "По популярности",
		value: "По популярности",
	},
	{
		label: "По цене",
		value: "By PrПо цене",
	},
];

const AgencyDetails = ({ agency }) => {
	const { mainState, mainDispatch } = useMain();

	const descriptionRef = useRef();
	const [hasMore, setHasMore] = useState(false);

	const showMore = ({ target }) => {
		descriptionRef.current.classList.remove("has-more");
		target.style.display = "none";
		setHasMore(false);
	};

	useEffect(() => {
		if (!descriptionRef?.current?.clientHeight >= 150) {
			setHasMore(false);
		} else {
			setHasMore(true);
		}
	}, []);

	return (
		<div className="page-wrapper">
			<Breadcrumb
				links={[
					{
						title: "Главная",
						href: "/home",
					},
					{
						title: "Агентства",
						href: "/home",
					},
					{
						title: "Abşeron",
						href: "/home",
					},
				]}
			/>
			<div className="agency-page">
				<div className="agency-page-wrapper">
					<div className="agency-page-logo">
						<CustomImage
							container_width={455}
							container_height={307}
							src={"/static/svgs/agencies/absheron.svg"}
							layout="fill"
							alt={`Wesale | ${agency}`}
							title={agency}
							priority
						/>
					</div>
					<div className="agency-page-info">
						<p className="g-title__sm--medium">{agency}</p>
						<span className="_flex-center w-content">
							<div className="agency-page-eye-icon">
								<EyeOpenIcon />
							</div>
							<span className="g-caption__lg--regular">65</span>
						</span>
						<div
							ref={descriptionRef}
							className={classNames("details-page__description mt-sm", {
								"has-more": hasMore,
							})}
							style={{
								height: hasMore ? rem(150) : "auto",
							}}
						>
							<p>
								Abşeron Əmlak agentliyi – международная сеть агентств
								недвижимости, международные стандарты риэлторских услуг и
								современные технологии ведения бизнеса. Каждые 45 секунд в мире
								агентами CENTURY 21 совершается новая сделка. CENTURY 21
								Столичная недвижимость предоставляет следующие услуги: -
								покупка/продажа любых видов жилой недвижимости на вторичном
								рынке; - покупка/продажа новостроек (обширная CENTURY 21
								Столичная недвижимость предоставляет следующие услуги: -
								покупка/продажа любых видов жилой недвижимости на вторичном
								рынке; - покупка/продажа новостроек
							</p>
						</div>
						<div className="mt-sm">
							<button className="g-btn-secondary" onClick={showMore}>
								Показать все
							</button>
						</div>
						<ul className="agency-page-list">
							<li className="d-flex gap-2">
								<span className="agency-page-list__icon">
									<TimeCircleIcon width={20} height={21} />
								</span>
								<span className="g-caption__lg--regular">
									9:00 - 18:00, Каждый день
								</span>
							</li>
							<li className="d-flex gap-2">
								<span className="agency-page-list__icon">
									<CallIcon width={22} height={21} />
								</span>
								<ul>
									<li className="g-caption__lg--regular">+994 50 500 50 50</li>
									<li className="g-caption__lg--regular">+994 50 500 50 50</li>
								</ul>
							</li>
							<li className="d-flex gap-2">
								<span className="agency-page-list__icon">
									<LocationIcon width={18} height={21} />
								</span>
								<span className="g-caption__lg--regular text-primary-blue">
									Bakı şəhəri, Nərimanov r., F. Xoyski küç. 114
								</span>
							</li>
						</ul>
						<a
							href="tel:+994 50 500 50 50"
							className="agency-page-wp-btn g-btn-mint g-btn--block"
						>
							Написать в WhatsApp
						</a>
					</div>
				</div>
				<div className="flex-center-between">
					<div>
						<h2 className="mb-0 g-title__lg--bold">Объявления агентства</h2>
						<p className="g-caption__lg--medium text-ntr-light-08">
							2224 объявления
						</p>
					</div>
					<div className="d-flex gap-3">
						<GSelect
							options={options}
							radius={8}
							instanceId={"agencies-filter-1"}
							padding_control={12}
							padding_option={[8, 12]}
							height={48}
							width={180}
						/>
						<GSelect
							options={options}
							radius={8}
							instanceId={"agencies-filter-2"}
							padding_control={12}
							padding_option={[8, 12]}
							height={48}
							width={180}
						/>
					</div>
				</div>
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
				<div className="_flex-center">
					<Pagination className="g-pagination">
						<Pagination.Item className="g-pagination__item active">
							1
						</Pagination.Item>
						<Pagination.Item className="g-pagination__item">2</Pagination.Item>
						<Pagination.Item className="g-pagination__item">3</Pagination.Item>
						<Pagination.Next className="g-pagination__item g-pagination__controller">
							Следующая
						</Pagination.Next>
					</Pagination>
				</div>
			</div>
		</div>
	);
};

export const getStaticPaths = (ctx) => {
	return {
		paths: [],
		fallback: "blocking",
	};
};

export const getStaticProps = (ctx) => {
	return {
		props: {
			agency: ctx.params.slug,
		},
		revalidate: 20,
	};
};

export default AgencyDetails;
