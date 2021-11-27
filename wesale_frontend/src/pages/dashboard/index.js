import React from "react";
import { FaEllipsisH } from "react-icons/fa";

import Link from "next/link";

import {
	ContractIcon,
	CustomImage,
	DashboardLayout,
	DocumentIcon,
	EyeOpenIcon,
	LockIcon,
	PercentageIcon,
} from "@/components";

import colors from "@/styles/modules/colors.module.scss";

const DashboardHome = () => {
	return (
		<div className="dashboard-container">
			<div className="dashboard-cards__grid">
				<div className="dashboard-card__profile">
					<div className="dashboard-card__profile--heading">
						<p className="g-title__sm--bold">Habil A</p>
						<p className="g-text__xs--medium text-secondary-grey">
							Baku, Azerbaijan
						</p>
					</div>
					<div className="dashboard-card__profile--body">
						<div className="dashboard-card__profile--logo">
							<CustomImage
								container_height={48}
								container_width={48}
								layout="fill"
								src={"/static/svgs/agencies/real-estate.svg"}
							/>
						</div>
						<div>
							<p className="g-text__sm--semibold text-primary-blue">
								Abşeron Əmlak agentliyi
							</p>
							<p className="g-caption__lg--regular">Агентство</p>
						</div>
					</div>
				</div>
				<div className="dashboard-cards__grid--side">
					<div className="d-flex align-items-center justify-content-end mt-sm">
						<Link href="/contact" passHref>
							<a className="g-text__sm--semibold text-ntr-dark-04 hover-primary-blue">
								Появились вопросы?
							</a>
						</Link>
					</div>
					<div className="dashboard-cards__stats--grid">
						<div className="dashboard-card__stats">
							<div className="dashboard-card__stats--icon">
								<DocumentIcon />
							</div>
							<div>
								<p className="g-title__sm--bold text-black">26</p>
								<p className="g-caption__lg--regular text-black">Объявлений</p>
							</div>
						</div>
						<div className="dashboard-card__stats">
							<div className="dashboard-card__stats--icon">
								<LockIcon />
							</div>
							<div>
								<p className="g-title__sm--bold text-black">2</p>
								<p className="g-caption__lg--regular text-black">
									на модерации
								</p>
							</div>
						</div>
						<div className="dashboard-card__stats">
							<div className="dashboard-card__stats--icon">
								<EyeOpenIcon stroke={"white"} />
							</div>
							<div>
								<p className="g-title__sm--bold text-black">326</p>
								<p className="g-caption__lg--regular text-black">Просмотрено</p>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div className="flex-center-between">
				<p className="g-title__sm--bold">Последние объявления</p>
				<div className="g-section-tabs">
					<button className="g-section-tab active">Все</button>
					<button className="g-section-tab">Собственник</button>
					<button className="g-section-tab">Агенство</button>
				</div>
			</div>
			<div className="announcement-cards">
				<div className="announcement-card">
					<div className="announcement-card__header">
						<p className="g-text__sm--semibold text-primary-grey announcement-card__title">
							Продается 3-комнатная старинная постро
						</p>
						<FaEllipsisH color={colors["ntr-dark-03"]} />
					</div>
					<div className="announcement-card__body">
						<div className="announcement-card__img">
							<Link href="/home" passHref>
								<a>
									<CustomImage
										container_width={150}
										container_height={100}
										layout="fill"
										src={"/static/svgs/products/product-1.svg"}
										alt={"Wesale | Product"}
									/>
								</a>
							</Link>
						</div>
						<div className="announcement-card__main">
							<div className="d-flex align-item-center flex-wrap gap-3 mb-md-24">
								<p className="g-caption__lg--regular text-secondary-error">
									На модерации
								</p>
								<p className="g-caption__lg--regular">18.02.2021</p>
								<div className="_flex-center gap-2">
									<EyeOpenIcon stroke={colors["ntr-dark-03"]} />
									<span className="g-caption__lg--regular">14456</span>
								</div>
							</div>
							<div className="d-flex align-items-center flex-wrap gap-2">
								<p className="g-text__sm--semibold text-primary-grey">
									2000 ₼/мес
								</p>
								<ContractIcon />
								<PercentageIcon />
							</div>
							<div className="d-flex align-items-center flex-wrap mt-1">
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									4 комн.
								</p>
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									220 м2
								</p>
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									14/17 этаж
								</p>
							</div>
						</div>
					</div>
					<div className="announcement-card__footer">
						<div className="g-caption__lg--regular text-primary-grey">
							Habil A
						</div>
					</div>
				</div>
				<div className="announcement-card">
					<div className="announcement-card__header">
						<p className="g-text__sm--semibold text-primary-grey announcement-card__title">
							Продается 3-комнатная старинная постро
						</p>
						<FaEllipsisH color={colors["ntr-dark-03"]} />
					</div>
					<div className="announcement-card__body">
						<div className="announcement-card__img">
							<Link href="/home" passHref>
								<a>
									<CustomImage
										container_width={150}
										container_height={100}
										layout="fill"
										src={"/static/svgs/products/product-1.svg"}
										alt={"Wesale | Product"}
									/>
								</a>
							</Link>
						</div>
						<div className="announcement-card__main">
							<div className="d-flex align-item-center flex-wrap gap-3 mb-md-24">
								<p className="g-caption__lg--regular text-primary-green">
									Опубликовано
								</p>
								<p className="g-caption__lg--regular">18.02.2021</p>
								<div className="_flex-center gap-2">
									<EyeOpenIcon stroke={colors["ntr-dark-03"]} />
									<span className="g-caption__lg--regular">14456</span>
								</div>
							</div>
							<div className="d-flex align-items-center flex-wrap gap-2">
								<p className="g-text__sm--semibold text-primary-grey">
									2000 ₼/мес
								</p>
								<ContractIcon />
								<PercentageIcon />
							</div>
							<div className="d-flex align-items-center flex-wrap mt-1">
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									4 комн.
								</p>
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									220 м2
								</p>
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									14/17 этаж
								</p>
							</div>
						</div>
					</div>
					<div className="announcement-card__footer">
						<div className="g-caption__lg--regular text-primary-grey">
							Abşeron Əmlak agentliyi
						</div>
					</div>
				</div>
				<div className="announcement-card">
					<div className="announcement-card__header">
						<p className="g-text__sm--semibold text-primary-grey announcement-card__title">
							Продается 3-комнатная старинная постро
						</p>
						<FaEllipsisH color={colors["ntr-dark-03"]} />
					</div>
					<div className="announcement-card__body">
						<div className="announcement-card__img">
							<Link href="/home" passHref>
								<a>
									<CustomImage
										container_width={150}
										container_height={100}
										layout="fill"
										src={"/static/svgs/products/product-1.svg"}
										alt={"Wesale | Product"}
									/>
								</a>
							</Link>
						</div>
						<div className="announcement-card__main">
							<div className="d-flex align-item-center flex-wrap gap-3 mb-md-24">
								<p className="g-caption__lg--regular text-primary-green">
									Опубликовано
								</p>
								<p className="g-caption__lg--regular">18.02.2021</p>
								<div className="_flex-center gap-2">
									<EyeOpenIcon stroke={colors["ntr-dark-03"]} />
									<span className="g-caption__lg--regular">14456</span>
								</div>
							</div>
							<div className="d-flex align-items-center flex-wrap gap-2">
								<p className="g-text__sm--semibold text-primary-grey">
									2000 ₼/мес
								</p>
								<ContractIcon />
								<PercentageIcon />
							</div>
							<div className="d-flex align-items-center flex-wrap mt-1">
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									4 комн.
								</p>
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									220 м2
								</p>
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									14/17 этаж
								</p>
							</div>
						</div>
					</div>
					<div className="announcement-card__footer">
						<div className="g-caption__lg--regular text-primary-grey">
							Abşeron Əmlak agentliyi
						</div>
					</div>
				</div>
				<div className="announcement-card">
					<div className="announcement-card__header">
						<p className="g-text__sm--semibold text-primary-grey announcement-card__title">
							Продается 3-комнатная старинная постро
						</p>
						<FaEllipsisH color={colors["ntr-dark-03"]} />
					</div>
					<div className="announcement-card__body">
						<div className="announcement-card__img">
							<Link href="/home" passHref>
								<a>
									<CustomImage
										container_width={150}
										container_height={100}
										layout="fill"
										src={"/static/svgs/products/product-1.svg"}
										alt={"Wesale | Product"}
									/>
								</a>
							</Link>
						</div>
						<div className="announcement-card__main">
							<div className="d-flex align-item-center flex-wrap gap-3 mb-md-24">
								<p className="g-caption__lg--regular text-secondary-error">
									На модерации
								</p>
								<p className="g-caption__lg--regular">18.02.2021</p>
								<div className="_flex-center gap-2">
									<EyeOpenIcon stroke={colors["ntr-dark-03"]} />
									<span className="g-caption__lg--regular">14456</span>
								</div>
							</div>
							<div className="d-flex align-items-center flex-wrap gap-2">
								<p className="g-text__sm--semibold text-primary-grey">
									2000 ₼/мес
								</p>
								<ContractIcon />
								<PercentageIcon />
							</div>
							<div className="d-flex align-items-center flex-wrap mt-1">
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									4 комн.
								</p>
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									220 м2
								</p>
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									14/17 этаж
								</p>
							</div>
						</div>
					</div>
					<div className="announcement-card__footer">
						<div className="g-caption__lg--regular text-primary-grey">
							Habil A
						</div>
					</div>
				</div>
				<div className="announcement-card">
					<div className="announcement-card__header">
						<p className="g-text__sm--semibold text-primary-grey announcement-card__title">
							Продается 3-комнатная старинная постро
						</p>
						<FaEllipsisH color={colors["ntr-dark-03"]} />
					</div>
					<div className="announcement-card__body">
						<div className="announcement-card__img">
							<Link href="/home" passHref>
								<a>
									<CustomImage
										container_width={150}
										container_height={100}
										layout="fill"
										src={"/static/svgs/products/product-1.svg"}
										alt={"Wesale | Product"}
									/>
								</a>
							</Link>
						</div>
						<div className="announcement-card__main">
							<div className="d-flex align-item-center flex-wrap gap-3 mb-md-24">
								<p className="g-caption__lg--regular text-secondary-error">
									На модерации
								</p>
								<p className="g-caption__lg--regular">18.02.2021</p>
								<div className="_flex-center gap-2">
									<EyeOpenIcon stroke={colors["ntr-dark-03"]} />
									<span className="g-caption__lg--regular">14456</span>
								</div>
							</div>
							<div className="d-flex align-items-center flex-wrap gap-2">
								<p className="g-text__sm--semibold text-primary-grey">
									2000 ₼/мес
								</p>
								<ContractIcon />
								<PercentageIcon />
							</div>
							<div className="d-flex align-items-center flex-wrap mt-1">
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									4 комн.
								</p>
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									220 м2
								</p>
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									14/17 этаж
								</p>
							</div>
						</div>
					</div>
					<div className="announcement-card__footer">
						<div className="g-caption__lg--regular text-primary-grey">
							Habil A
						</div>
					</div>
				</div>
				<div className="announcement-card">
					<div className="announcement-card__header">
						<p className="g-text__sm--semibold text-primary-grey announcement-card__title">
							Продается 3-комнатная старинная постро
						</p>
						<FaEllipsisH color={colors["ntr-dark-03"]} />
					</div>
					<div className="announcement-card__body">
						<div className="announcement-card__img">
							<Link href="/home" passHref>
								<a>
									<CustomImage
										container_width={150}
										container_height={100}
										layout="fill"
										src={"/static/svgs/products/product-1.svg"}
										alt={"Wesale | Product"}
									/>
								</a>
							</Link>
						</div>
						<div className="announcement-card__main">
							<div className="d-flex align-item-center flex-wrap gap-3 mb-md-24">
								<p className="g-caption__lg--regular text-secondary-error">
									На модерации
								</p>
								<p className="g-caption__lg--regular">18.02.2021</p>
								<div className="_flex-center gap-2">
									<EyeOpenIcon stroke={colors["ntr-dark-03"]} />
									<span className="g-caption__lg--regular">14456</span>
								</div>
							</div>
							<div className="d-flex align-items-center flex-wrap gap-2">
								<p className="g-text__sm--semibold text-primary-grey">
									2000 ₼/мес
								</p>
								<ContractIcon />
								<PercentageIcon />
							</div>
							<div className="d-flex align-items-center flex-wrap mt-1">
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									4 комн.
								</p>
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									220 м2
								</p>
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									14/17 этаж
								</p>
							</div>
						</div>
					</div>
					<div className="announcement-card__footer">
						<div className="g-caption__lg--regular text-primary-grey">
							Habil A
						</div>
					</div>
				</div>
				<div className="announcement-card">
					<div className="announcement-card__header">
						<p className="g-text__sm--semibold text-primary-grey announcement-card__title">
							Продается 3-комнатная старинная постро
						</p>
						<FaEllipsisH color={colors["ntr-dark-03"]} />
					</div>
					<div className="announcement-card__body">
						<div className="announcement-card__img">
							<Link href="/home" passHref>
								<a>
									<CustomImage
										container_width={150}
										container_height={100}
										layout="fill"
										src={"/static/svgs/products/product-1.svg"}
										alt={"Wesale | Product"}
									/>
								</a>
							</Link>
						</div>
						<div className="announcement-card__main">
							<div className="d-flex align-item-center flex-wrap gap-3 mb-md-24">
								<p className="g-caption__lg--regular text-secondary-error">
									На модерации
								</p>
								<p className="g-caption__lg--regular">18.02.2021</p>
								<div className="_flex-center gap-2">
									<EyeOpenIcon stroke={colors["ntr-dark-03"]} />
									<span className="g-caption__lg--regular">14456</span>
								</div>
							</div>
							<div className="d-flex align-items-center flex-wrap gap-2">
								<p className="g-text__sm--semibold text-primary-grey">
									2000 ₼/мес
								</p>
								<ContractIcon />
								<PercentageIcon />
							</div>
							<div className="d-flex align-items-center flex-wrap mt-1">
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									4 комн.
								</p>
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									220 м2
								</p>
								<p className="g-caption__lg--regular text-ntr-dark-02 with-dot with-dot--grey">
									14/17 этаж
								</p>
							</div>
						</div>
					</div>
					<div className="announcement-card__footer">
						<div className="g-caption__lg--regular text-primary-grey">
							Habil A
						</div>
					</div>
				</div>
			</div>
			<div className="_flex-center">
				<Link href="/home" passHref>
					<a className="g-btn-secondary">Показать еще</a>
				</Link>
			</div>
		</div>
	);
};

DashboardHome.getLayout = (page) => {
	return <DashboardLayout>{page}</DashboardLayout>;
};

export default DashboardHome;
