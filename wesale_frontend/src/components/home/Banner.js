import {
	selectActiveForm,
	toggleActiveForm,
} from "@/app/filter-form/filterFormSlice";

import React, { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";

import Link from "next/link";
import { useRouter } from "next/router";

import { CustomImage, FilterFormHome, FilterFormObject } from "@/components";

import classNames from "classnames";

import colors from "@/styles/modules/colors.module.scss";

const Banner = ({ activeForm }) => {
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
						<Link href="/home" passHref>
							<a
								className={classNames(
									"banner-section-tab-btn g-tab-btn d-flex",
									{
										active: activeForm === "home",
									}
								)}
							>
								дом
							</a>
						</Link>
						<p className="g-title__lg--bold text-white">или</p>
						<Link href="/object" passHref>
							<a
								className={classNames(
									"banner-section-tab-btn g-tab-btn d-flex",
									{
										active: activeForm === "object",
									}
								)}
							>
								объект
							</a>
						</Link>
					</div>
					<div className="banner-section-form">
						{activeForm === "home" && (
							<div className="g-tab-pane">
								<FilterFormHome
									options={options}
									options2={options2}
									colors={{
										iconColor: "primary-grey",
									}}
								/>
							</div>
						)}
						{activeForm === "object" && (
							<div className="g-tab-pane">
								<FilterFormObject
									options={options}
									options2={options2}
									colors={{
										iconColor: "primary-grey",
									}}
								/>
							</div>
						)}
					</div>
				</div>
			</div>
		</div>
	);
};

export default Banner;
