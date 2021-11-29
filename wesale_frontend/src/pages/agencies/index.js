import React from "react";
import { Pagination } from "react-bootstrap";

import Link from "next/link";

import { CustomImage, GSelect } from "@/components";

const options = [
	{
		label: "По популярности",
		value: "По популярности",
	},
	{
		label: "По цене",
		value: "By PrПо цене",
	},
];

const agencies = [
	{
		name: "INGRAD",
		ads: 34,
		img: "/static/svgs/agencies/ingrad.svg",
		reviews: {
			images: [
				"https://images.unsplash.com/photo-1544457070-4cd773b4d71e?ixid=MnwxMjA3fDB8MHxzZWFyY2h8Nnx8ZGVjb3JhdGlvbnxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://media.istockphoto.com/photos/apartment-kitchen-in-modern-rustic-style-picture-id1261144904?b=1&k=20&m=1261144904&s=170667a&w=0&h=-zGXW8T8NKbyKcrQ5Ty1M3nHxoB-NY9ZsIX_sHcC230=",
				"https://images.unsplash.com/photo-1527694224012-be005121c774?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTN8fGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
			],
			info: "4 комн. квартира, метр...",
		},
	},
	{
		name: "REMAKS",
		ads: 23,
		img: "/static/svgs/agencies/remax.svg",
		reviews: {
			images: [
				"https://images.unsplash.com/photo-1544457070-4cd773b4d71e?ixid=MnwxMjA3fDB8MHxzZWFyY2h8Nnx8ZGVjb3JhdGlvbnxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://media.istockphoto.com/photos/apartment-kitchen-in-modern-rustic-style-picture-id1261144904?b=1&k=20&m=1261144904&s=170667a&w=0&h=-zGXW8T8NKbyKcrQ5Ty1M3nHxoB-NY9ZsIX_sHcC230=",
				"https://images.unsplash.com/photo-1527694224012-be005121c774?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTN8fGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
			],
			info: "4 комн. квартира, метр...",
		},
	},
	{
		name: "Abşeron Əmlak agentliyi",
		ads: 45,
		img: "/static/svgs/agencies/absheron.svg",
		reviews: {
			images: [
				"https://images.unsplash.com/photo-1544457070-4cd773b4d71e?ixid=MnwxMjA3fDB8MHxzZWFyY2h8Nnx8ZGVjb3JhdGlvbnxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://media.istockphoto.com/photos/apartment-kitchen-in-modern-rustic-style-picture-id1261144904?b=1&k=20&m=1261144904&s=170667a&w=0&h=-zGXW8T8NKbyKcrQ5Ty1M3nHxoB-NY9ZsIX_sHcC230=",
				"https://images.unsplash.com/photo-1527694224012-be005121c774?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTN8fGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
			],
			info: "4 комн. квартира, метр...",
		},
	},
	{
		name: "Trend Estate Baku",
		ads: 2,
		img: "/static/svgs/agencies/trend-estate.svg",
		reviews: {
			images: [
				"https://images.unsplash.com/photo-1544457070-4cd773b4d71e?ixid=MnwxMjA3fDB8MHxzZWFyY2h8Nnx8ZGVjb3JhdGlvbnxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://media.istockphoto.com/photos/apartment-kitchen-in-modern-rustic-style-picture-id1261144904?b=1&k=20&m=1261144904&s=170667a&w=0&h=-zGXW8T8NKbyKcrQ5Ty1M3nHxoB-NY9ZsIX_sHcC230=",
				"https://images.unsplash.com/photo-1527694224012-be005121c774?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTN8fGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
			],
			info: "4 комн. квартира, метр...",
		},
	},
	{
		name: "Rahat ev",
		ads: 66,
		img: "/static/svgs/agencies/rahat-ev.svg",
		reviews: {
			images: [
				"https://images.unsplash.com/photo-1544457070-4cd773b4d71e?ixid=MnwxMjA3fDB8MHxzZWFyY2h8Nnx8ZGVjb3JhdGlvbnxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://media.istockphoto.com/photos/apartment-kitchen-in-modern-rustic-style-picture-id1261144904?b=1&k=20&m=1261144904&s=170667a&w=0&h=-zGXW8T8NKbyKcrQ5Ty1M3nHxoB-NY9ZsIX_sHcC230=",
				"https://images.unsplash.com/photo-1527694224012-be005121c774?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTN8fGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
			],
			info: "4 комн. квартира, метр...",
		},
	},
	{
		name: "TOWER",
		ads: 142,
		img: "/static/svgs/agencies/tower.svg",
		reviews: {
			images: [
				"https://images.unsplash.com/photo-1544457070-4cd773b4d71e?ixid=MnwxMjA3fDB8MHxzZWFyY2h8Nnx8ZGVjb3JhdGlvbnxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://media.istockphoto.com/photos/apartment-kitchen-in-modern-rustic-style-picture-id1261144904?b=1&k=20&m=1261144904&s=170667a&w=0&h=-zGXW8T8NKbyKcrQ5Ty1M3nHxoB-NY9ZsIX_sHcC230=",
				"https://images.unsplash.com/photo-1527694224012-be005121c774?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTN8fGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
			],
			info: "4 комн. квартира, метр...",
		},
	},
	{
		name: "REAL ESTATE",
		ads: 244,
		img: "/static/svgs/agencies/real-estate.svg",
		reviews: {
			images: [
				"https://images.unsplash.com/photo-1544457070-4cd773b4d71e?ixid=MnwxMjA3fDB8MHxzZWFyY2h8Nnx8ZGVjb3JhdGlvbnxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://media.istockphoto.com/photos/apartment-kitchen-in-modern-rustic-style-picture-id1261144904?b=1&k=20&m=1261144904&s=170667a&w=0&h=-zGXW8T8NKbyKcrQ5Ty1M3nHxoB-NY9ZsIX_sHcC230=",
				"https://images.unsplash.com/photo-1527694224012-be005121c774?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTN8fGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
			],
			info: "4 комн. квартира, метр...",
		},
	},
];

const AgenciesPage = () => {
	return (
		<div className="agencies-page">
			<div className="flex-center-between">
				<div>
					<h2 className="mb-0 g-title__lg--bold">Агентства</h2>
					<p className="g-caption__lg--medium text-ntr-light-08">
						333 агентств
					</p>
				</div>
				<GSelect
					options={options}
					radius={8}
					instanceId={"agencies-filter"}
					padding_control={12}
					padding_option={[8, 12]}
					height={48}
					width={180}
				/>
			</div>
			<div className="agency-cards">
				{agencies?.slice(0, 3).map(({ name, ads, img, reviews }, index) => (
					<div className="agency-card agency-card--lg" key={index}>
						<div className="agency-card__logo">
							<CustomImage
								src={img}
								container_width={266}
								container_height={184}
								layout="fill"
								alt="Agency | Wesale"
							/>
						</div>
						<div className="agency-card__details">
							<div className="flex-center-between">
								<div>
									<p className="g-text__lg--semibold text-black">{name}</p>
									<p className="g-caption__lg--regular text-ntr-light-08">
										{ads} объявлений
									</p>
								</div>
								<Link href={`/agencies/${decodeURI(name)}`} passHref>
									<a className="g-btn-secondary">Показать все</a>
								</Link>
							</div>
							<div className="review-images">
								<div className="review-images__card">
									<div className="review-images__wrapper">
										{reviews?.images?.map((img, index) => (
											<div className="review-images__img" key={index}>
												<img src={img} alt="Wesale | Review" />
											</div>
										))}
									</div>
									<p>{reviews.info}</p>
								</div>
								<div className="review-images__card">
									<div className="review-images__wrapper">
										{reviews?.images?.map((img, index) => (
											<div className="review-images__img" key={index}>
												<img src={img} alt="Wesale | Review" />
											</div>
										))}
									</div>
									<p>{reviews.info}</p>
								</div>
								<div className="review-images__card">
									<div className="review-images__wrapper">
										{reviews?.images?.map((img, index) => (
											<div className="review-images__img" key={index}>
												<img src={img} alt="Wesale | Review" />
											</div>
										))}
									</div>
									<p>{reviews.info}</p>
								</div>
								<div className="review-images__card">
									<div className="review-images__wrapper">
										{reviews?.images?.map((img, index) => (
											<div className="review-images__img" key={index}>
												<img src={img} alt="Wesale | Review" />
											</div>
										))}
									</div>
									<p>{reviews.info}</p>
								</div>
							</div>
						</div>
					</div>
				))}
				<div className="custom-cards my-md-24">
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
				{agencies
					?.slice(3, agencies.length - 1)
					?.map(({ name, ads, img, reviews }, index) => (
						<div className="agency-card agency-card--lg" key={index}>
							<div className="agency-card__logo">
								<CustomImage
									src={img}
									container_width={266}
									container_height={184}
									layout="fill"
									alt="Agency | Wesale"
								/>
							</div>
							<div className="agency-card__details">
								<div className="flex-center-between">
									<div>
										<p className="g-text__lg--semibold text-black">{name}</p>
										<p className="g-caption__lg--regular text-ntr-light-08">
											{ads} объявлений
										</p>
									</div>
									<Link href={`/agencies/${decodeURI(name)}`} passHref>
										<a className="g-btn-secondary">Показать все</a>
									</Link>
								</div>
								<div className="review-images">
									<div className="review-images__card">
										<div className="review-images__wrapper">
											{reviews?.images?.map((img, index) => (
												<div className="review-images__img" key={index}>
													<img src={img} alt="Wesale | Review" />
												</div>
											))}
										</div>
										<p>{reviews.info}</p>
									</div>
									<div className="review-images__card">
										<div className="review-images__wrapper">
											{reviews?.images?.map((img, index) => (
												<div className="review-images__img" key={index}>
													<img src={img} alt="Wesale | Review" />
												</div>
											))}
										</div>
										<p>{reviews.info}</p>
									</div>
									<div className="review-images__card">
										<div className="review-images__wrapper">
											{reviews?.images?.map((img, index) => (
												<div className="review-images__img" key={index}>
													<img src={img} alt="Wesale | Review" />
												</div>
											))}
										</div>
										<p>{reviews.info}</p>
									</div>
									<div className="review-images__card">
										<div className="review-images__wrapper">
											{reviews?.images?.map((img, index) => (
												<div className="review-images__img" key={index}>
													<img src={img} alt="Wesale | Review" />
												</div>
											))}
										</div>
										<p>{reviews.info}</p>
									</div>
								</div>
							</div>
						</div>
					))}
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
	);
};

export default AgenciesPage;
