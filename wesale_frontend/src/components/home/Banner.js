import { handleTabs } from "@/lib";
import colors from "@/styles/modules/colors.module.scss";

import React, { useEffect } from "react";
import { Fa500Px } from "react-icons/fa";

import { CustomImage, FilterFormHome, FilterFormObject } from "@/components";

const Banner = () => {
	useEffect(() => {
		const tabs = [...document.querySelectorAll(".g-tab-pane")];
		const tabBtns = [...document.querySelectorAll(".g-tab-btn")];

		tabBtns.forEach((btn) => {
			handleTabs(tabs, tabBtns, btn);
			btn.addEventListener("click", () => handleTabs(tabs, tabBtns, btn));
		});
	}, []);

	const options = [
		{
			label: "Купить",
			value: "Купить",
		},
	];

	const options2 = [
		{
			label: "Квартиру",
			value: "Квартиру",
		},
	];

	return (
		<div className="banner-section">
			<div className="banner-section-cover">
				<CustomImage
					src={"/static/svgs/home/banner.jpg"}
					priority
					alt={"WeSale Banner"}
					layout="fill"
					container_height={340}
					container_width={"100%"}
					objectFit={"cover"}
				/>
			</div>
			<div className="banner-section-wrapper">
				<div className="banner-section-container">
					<div className="banner-section-tabs">
						<p className="g-title__lg--bold text-white">Найти</p>
						<button
							className="banner-section-tab-btn active g-tab-btn"
							data-target="home"
						>
							дом
						</button>
						<p className="g-title__lg--bold text-white">или</p>
						<button
							className="banner-section-tab-btn g-tab-btn"
							data-target="object"
						>
							объект
						</button>
					</div>
					<div className="banner-section-form">
						<div className="g-tab-pane" id="home">
							<FilterFormHome
								options={options}
								options2={options2}
								colors={{
									iconColor: "primary-grey",
								}}
							/>
						</div>
						<div className="g-tab-pane" id="object">
							<FilterFormObject
								options={options}
								options2={options2}
								colors={{
									iconColor: "primary-grey",
								}}
							/>
						</div>
					</div>
				</div>
			</div>
		</div>
	);
};

export default Banner;
