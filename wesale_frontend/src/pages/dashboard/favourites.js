import React from "react";

import Link from "next/link";

import { AlertIcon, DashboardLayout, ProductCard } from "@/components";

import { useMain } from "@/context/providers/main-context";

const DashboardFavourites = () => {
	const { mainState } = useMain();

	return (
		<div className="dashboard-container">
			<div className="d-flex align-items-center gap-2 mb-md">
				<h2 className="g-title__sm--bold m-0">Favourites</h2>
				<p className="g-text__xs--medium text-secondary-grey">4 объекта</p>
			</div>
			<div className="mt-sm">
				<div className="g-alert g-alert-login">
					<div className="g-alert-login__icon">
						<AlertIcon />
					</div>
					<div className="g-alert-login__body">
						<p className="g-text__sm--semibold text-primary-blue">
							Это может быть полезным!
						</p>
						<p className="g-text__sm--regular text-ntr-dark-01">
							Мы рекомендуем вам авторизироваться, чтобы ваш список избранного
							всегда был доступен. После авторизации сохраненные поиски
							перенесутся в ваш профиль.
							<Link href="/home">
								<a className="text-primary-blue text-decoration-underline">
									Авторизироваться
								</a>
							</Link>
						</p>
					</div>
				</div>
			</div>
			<div className="g-section-cards">
				<ProductCard
					area={220}
					price={1200}
					rooms={3}
					images={mainState.images}
					isFavourite={true}
				/>
				<ProductCard
					area={280}
					price={1892}
					rooms={3}
					images={mainState.images}
					isFavourite={true}
				/>
				<ProductCard
					area={152}
					price={965}
					rooms={3}
					images={mainState.images}
					isFavourite={true}
				/>
				<ProductCard
					area={720}
					price={18000}
					rooms={3}
					images={mainState.images}
					isFavourite={true}
				/>
				<ProductCard
					area={520}
					price={1200}
					rooms={3}
					images={mainState.images}
					isFavourite={true}
				/>
				<ProductCard
					area={220}
					price={56000}
					rooms={3}
					images={mainState.images}
					isFavourite={true}
				/>
			</div>
			{/* <div className="no-results-found">
				<p className="g-title__sm--medium text-secondary-grey mb-md-24">
					Ваше избранное пустое
				</p>
				<Link href="/search/list" passHref>
					<a className="g-btn-primary">Перейти к поиску</a>
				</Link>
			</div> */}
		</div>
	);
};

DashboardFavourites.getLayout = (page) => (
	<DashboardLayout>{page}</DashboardLayout>
);

export default DashboardFavourites;
