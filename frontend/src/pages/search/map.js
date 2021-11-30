import { MAPBOX_ACCESS_TOKEN, MAPBOX_STYLE_URL } from "@/config/base";
import { rem } from "@/lib";

import React, { useCallback, useEffect, useState } from "react";
import { FaTimes } from "react-icons/fa";
import ReactMapGL, {
	FlyToInterpolator,
	Marker,
	NavigationControl,
} from "react-map-gl";

import Link from "next/link";

import { MarkerIcon, ProductCard, ProfileIcon } from "@/components";

import { useMain } from "@/context/providers/main-context";

import classNames from "classnames";

const NavigationControlStyle = {
	top: 100,
	right: 82,
};

const locations = [
	{
		lat: 40.421599,
		long: 49.86096,
		price: 2000,
		currency: "$",
		rooms: 4,
		area: 220,
		floor: 14,
		totalFloor: 17,
		brief: "Квартира, метро Н.Нариманов",
	},
	{
		lat: 40.422644,
		long: 49.86499,
		price: 2000,
		currency: "$",
		rooms: 4,
		area: 220,
		floor: 14,
		totalFloor: 17,
		brief: "Квартира, метро Н.Нариманов",
	},
	{
		lat: 40.414934,
		long: 49.849187,
		price: 2400,
		currency: "$",
		rooms: 2,
		area: 120,
		floor: 14,
		totalFloor: 17,
		brief: "Квартира, метро Н.Ganjlik",
	},
	{
		lat: 40.404608,
		long: 49.839567,
		price: 2000,
		currency: "$",
		rooms: 4,
		area: 220,
		floor: 14,
		totalFloor: 17,
		brief: "Квартира, метро Н.Нариманов",
	},
	{
		lat: 40.408137,
		long: 49.861726,
		price: 2000,
		currency: "$",
		rooms: 4,
		area: 220,
		floor: 14,
		totalFloor: 17,
		brief: "Квартира, метро Н.Нариманов",
	},
	{
		lat: 40.408137,
		long: 50.861726,
		price: 2000,
		currency: "$",
		rooms: 4,
		area: 220,
		floor: 14,
		totalFloor: 17,
		brief: "Квартира, метро Н.Нариманов",
	},
	{
		lat: 40.808137,
		long: 50.261726,
	},
];

const Map = () => {
	const { mainState, mainDispatch } = useMain();
	const { navHeight, filterFormHeight } = mainState;
	const [marginTop, setMarginTop] = useState(0);
	const [activeLocation, setActiveLocation] = useState(null);

	const [viewport, setViewport] = useState({
		width: "100%",
		height: 0,
		latitude: locations[0].lat,
		longitude: locations[0].long,
		zoom: 13,
		minZoom: 7,
	});

	useEffect(() => {
		mainDispatch({
			type: "TOGGLE_FILTER_FORM",
			payload: true,
		});
	}, []);

	useEffect(() => {
		const windowHeight = window.innerHeight;
		let height;

		if (!mainState.FilterFormWrapperIsOpen) {
			height = windowHeight - navHeight;
			setViewport((prev) => ({
				...prev,
				height,
			}));
		} else {
			height = windowHeight - (navHeight + filterFormHeight);
			setViewport((prev) => ({
				...prev,
				height: height || 0,
			}));
		}
	}, [filterFormHeight, mainState.FilterFormWrapperIsOpen, navHeight]);

	useEffect(() => {
		setMarginTop(filterFormHeight);
	}, [filterFormHeight]);

	const handleMarker = useCallback((e, index) => {
		setViewport((prev) => ({
			...prev,
			latitude: locations[index].lat,
			longitude: locations[index].long,

			transitionInterpolator: new FlyToInterpolator({
				speed: 0.4,
				curve: 2,
			}),
			transitionDuration: "auto",
		}));

		setActiveLocation(locations[index]);
	}, []);

	const closeDetails = useCallback(() => {
		setActiveLocation(null);
	}, []);

	return (
		<div className="map-page">
			<div
				className="map-page-wrapper"
				style={{
					marginTop: mainState.FilterFormWrapperIsOpen ? rem(marginTop) : 0,
					position: "relative",
				}}
			>
				<div className="search-page-tabs">
					<div className="search-page-tab-btn">
						<Link href="/search/list">
							<a>Список</a>
						</Link>
					</div>
					<div className="search-page-tab-btn active">
						<Link href="/search/map">
							<a>На карте</a>
						</Link>
					</div>
				</div>
				<div
					className={classNames("map-page-detail", {
						open: activeLocation,
					})}
				>
					<div className="_flex-end">
						<button className="close-details" onClick={closeDetails}>
							<FaTimes />
						</button>
					</div>
					<ProductCard
						area={activeLocation?.area}
						price={activeLocation?.price}
						rooms={activeLocation?.rooms}
						images={mainState?.images}
					/>
					<div className="g-divider"></div>
					<p className="g-caption__lg--regular text-ntr-light-06">Ипотека</p>
					<div className="flex-center-between">
						<p className="product-card__title mb-xxs">
							<span className="g-text__sm--bold">{activeLocation?.price}</span>
							<span className="g-text__lg--regular">₼/мес</span>
						</p>
						<Link href="/home" passHref>
							<a className="g-caption__lg--semibold text-primary-blue">
								Подать заявку
							</a>
						</Link>
					</div>
					<div className="g-divider"></div>
					<div className="info-card__details">
						<div className="info-card__details--item">
							<div className="info-card__details--icon">
								<ProfileIcon />
							</div>
							<div className="ml-sm">
								<p className="g-caption__lg--regular">Собственник</p>
								<p className="g-text__sm--bold">Ангелина Петровна</p>
							</div>
						</div>
					</div>
					<Link href="/home">
						<a className="g-btn-secondary g-btn--block">Подробнее</a>
					</Link>
				</div>
				<ReactMapGL
					{...viewport}
					onViewportChange={(nextViewport) => setViewport(nextViewport)}
					mapboxApiAccessToken={MAPBOX_ACCESS_TOKEN}
					mapStyle={MAPBOX_STYLE_URL}
				>
					<NavigationControl
						style={NavigationControlStyle}
						showCompass={false}
					/>
					{locations.map(({ lat, long }, index) => (
						<Marker
							onClick={(e) => handleMarker(e, index)}
							key={index}
							latitude={lat}
							longitude={long}
						>
							<div className="map-marker">
								<MarkerIcon filled={lat === activeLocation?.lat} />
							</div>
						</Marker>
					))}
				</ReactMapGL>
			</div>
		</div>
	);
};

export default Map;
