import { seperateWithSpace } from "@/lib";

import React, { useEffect, useRef, useState } from "react";
import { FiSearch } from "react-icons/fi";
import { CSSTransition } from "react-transition-group";

import { FilterIcon, GInput, GSelect } from "@/components";

import classNames from "classnames";

const FilterFormHome = ({ options, options2, colors }) => {
	const priceRangeInput = useRef(null);
	const priceRangeInputs = useRef(null);
	const willFocusRef = useRef(null);

	const [showPriceRangeInput, setShowPriceRangeInput] = useState(false);

	const [priceRange, setPriceRange] = useState({
		min: "",
		max: "",
	});

	const handleClickOutside = (e) => {
		if (
			priceRangeInput.current &&
			!priceRangeInput.current.contains(e.target) &&
			priceRangeInputs.current &&
			!priceRangeInputs.current.contains(e.target)
		) {
			setShowPriceRangeInput(false);
		}
	};

	useEffect(() => {
		window.addEventListener("click", handleClickOutside);
	}, []);

	return (
		<form action="" method="get">
			<div className="filter-form-grid">
				<div className="filter-form-grid__item">
					<GSelect
						options={options}
						placeholder={"Type"}
						radius={8}
						instanceId={"filter-form-home-1"}
						padding_control={12}
						padding_option={[8, 12]}
						height={48}
					/>
				</div>
				<div className="filter-form-grid__item">
					<GSelect
						options={options2}
						placeholder={"Квартиру"}
						radius={8}
						instanceId={"filter-form-home-2"}
						padding_control={12}
						padding_option={[8, 12]}
						height={48}
					/>
				</div>
				<div className="filter-form-grid__item">
					<div className="rooms">
						<p className="rooms-label">Комнаты</p>
						<div className="number-of-rooms">
							<div className="number-of-rooms__item">
								<input
									className="visually-hidden"
									type="radio"
									name="rooms"
									id="1"
								/>
								<label htmlFor="1">1</label>
							</div>
							<div className="number-of-rooms__item">
								<input
									className="visually-hidden"
									type="radio"
									name="rooms"
									id="2"
								/>
								<label htmlFor="2">2</label>
							</div>
							<div className="number-of-rooms__item">
								<input
									className="visually-hidden"
									type="radio"
									name="rooms"
									id="3"
								/>
								<label htmlFor="3">3</label>
							</div>
							<div className="number-of-rooms__item">
								<input
									className="visually-hidden"
									type="radio"
									name="rooms"
									id="4"
								/>
								<label htmlFor="4">4+</label>
							</div>
						</div>
					</div>
				</div>
				<div className="filter-form-grid__item">
					{/* <GInput
						id={"Цена"}
						placeholder={"Цена"}
						classname="filter-form-input"
						name={"Цена"}
					/> */}
					<input
						ref={priceRangeInput}
						type="text"
						className={"g-input filter-form-input"}
						placeholder={"Цена"}
						name={"Цена"}
						id={"Цена"}
						value={
							(priceRange.min || priceRange.max) &&
							`${seperateWithSpace(priceRange.min)}-${seperateWithSpace(
								priceRange.max
							)}`
						}
						readOnly
						onClick={() => {
							setShowPriceRangeInput(!showPriceRangeInput);

							showPriceRangeInput && willFocusRef.current.focus();
						}}
					/>
					<CSSTransition
						in={showPriceRangeInput}
						timeout={300}
						classNames="item"
						unmountOnExit
					>
						<div className="filter-form__price-range" ref={priceRangeInputs}>
							<input
								ref={willFocusRef}
								type="number"
								name=""
								id=""
								placeholder="от"
								value={priceRange.min}
								onChange={(e) =>
									setPriceRange({ ...priceRange, min: e.target.value })
								}
								onSubmit={(e) => {
									e.preventDefault();

									setShowPriceRangeInput(false);
								}}
							/>
							<div className="price-range__divider" />
							<input
								type="number"
								name=""
								id=""
								placeholder="до"
								value={priceRange.max}
								onChange={(e) =>
									setPriceRange({ ...priceRange, max: e.target.value })
								}
								onSubmit={(e) => {
									e.preventDefault();

									setShowPriceRangeInput(false);
								}}
							/>
						</div>
					</CSSTransition>
				</div>
				<div className="filter-form-grid__item">
					<GInput
						id={"Область поиска"}
						placeholder={"Область поиска"}
						classname="filter-form-input"
						name={"Область поиска"}
					/>
					{/* <div className="filter-form__search-results">
						<ul>
							<li>метро Нариманово</li>
							<li>Наримановский парк</li>
							<li>метро Нариманово</li>
						</ul>
					</div> */}
				</div>
				<div className="filter-form__action-buttons">
					<button
						className={classNames("filter-form__btn", {
							["text-" + colors?.icon]: "text" + colors?.icon,
						})}
					>
						<FilterIcon />
						<span className="number-of-active-filters">12</span>
					</button>
					<button className="filter-form__submit" type="submit">
						<FiSearch />
					</button>
				</div>
			</div>
		</form>
	);
};

export default FilterFormHome;
