import { rem } from "@/lib";

import React, { useEffect } from "react";
import { Pagination } from "react-bootstrap";

import Link from "next/link";

import {
	ArrowRightIcon,
	BookmarkIcon,
	Breadcrumb,
	GSelect,
	ProductCard,
} from "@/components";

import { useMain } from "@/context/providers/main-context";

import colors from "@/styles/modules/colors.module.scss";

const SearchPage = () => {
	const { mainState, mainDispatch } = useMain();
	const selectStyles = {
		borderColor: colors["ntr-light-06"],
		borderWidth: 1,
		bgColorControl: colors["white"],
		controlColor: colors["primary-black"],
	};

	useEffect(() => {
		mainDispatch({
			type: "TOGGLE_FILTER_FORM",
			payload: true,
		});
	}, []);

	return (
		<div
			className="search-page"
			style={{
				marginTop: mainState.FilterFormWrapperIsOpen
					? rem(
							document?.querySelector(".filter-form-wrapper")?.clientHeight + 16
					  )
					: rem(16),
			}}
		>
			<div className="g-section">
				<div className="flex-center-between">
					<div className="g-breadcrumb-wrapper">
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
					</div>
					<button className="btn-save-search">
						<BookmarkIcon />
						Сохранить поиск
					</button>
				</div>
			</div>
			<div className="g-section">
				<div className="flex-center-between">
					<div className="_flex-center">
						<p className="g-title__sm--bold mr-sm">Все объявления</p>
						<span className="g-caption__lg--regular text-ntr-light-06">
							2224 объявления
						</span>
					</div>
					<div className="_flex-center">
						<div className="search-page-select">
							<GSelect
								options={[
									{
										label: "По популярности",
										value: "По популярности",
									},
									{
										label: "По популярности",
										value: "По популярности",
									},
									{
										label: "По популярности",
										value: "По популярности",
									},
								]}
								instanceId="filterSelect"
								radius={12}
								border_color={selectStyles.borderColor}
								border_width={selectStyles.borderWidth}
								bg_color_control={selectStyles.bgColorControl}
								color={selectStyles.controlColor}
								height={40}
								padding_control={[0, 16]}
							/>
						</div>
						<div className="search-page-tabs">
							<div className="search-page-tab-btn active">
								<Link href="/search/list">
									<a>Список</a>
								</Link>
							</div>
							<div className="search-page-tab-btn">
								<Link href="/search/map">
									<a>На карте</a>
								</Link>
							</div>
						</div>
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
					<div className="subscribe-card">
						<div className="subscribe-card-body">
							<p className="g-title__md--semibold text-primary-black">
								Подпишитесь что бы первым получать{" "}
								<span className="text-primary-blue">горячие предложения!</span>
							</p>
							<form action="" className="g-footer__search-form">
								<div className="g-footer__search">
									<input type="text" placeholder="Ваша электронная почта" />
									<button type="submit">
										<ArrowRightIcon />
									</button>
								</div>
							</form>
						</div>
						<div className="subscribe-card-img-wrapper">
							<div className="subscribe-card-img">
								<img
									src="/static/svgs/illustration-1.svg"
									alt="WeSale | Подпишитесь что бы первым получать
                    горячие предложения!"
								/>
							</div>
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

export default SearchPage;
