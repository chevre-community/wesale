import { rem, transparentize } from "@/lib";

import React, { useEffect } from "react";
import Select, { components } from "react-select";

import { ChevronDown } from "@/components";

import colors from "@/styles/modules/colors.module.scss";

const GSelect = ({
	options,
	color,
	control_color,
	hover_color,
	bg_color_option,
	bg_color_option_selected,
	bg_color_hover,
	bg_color_control,
	bg_color_menu,
	border_color,
	border_width,
	radius,
	instanceId,
	placeholder,
	padding_control,
	padding_option,
	height,
	width,
	...rest
}) => {
	const selectStyles = {
		option: (provided, state) => ({
			...provided,
			padding: padding_option ? rem(padding_option) : rem([8, 24]),
			background: state.isSelected
				? bg_color_option_selected || colors["ntr-light-03"]
				: bg_color_option || colors["ntr-light-04"],
			color: color || colors["primary-black"],
			fontSize: rem(15),
			lineHeight: 1.7,
			letterSpacing: "0.02em",
			fontWeight: 400,
			transition: "all 0.2s linear",
			maxWidth: "100%",
			overflow: "hidden",
			whiteSpace: "nowrap",
			textOverflow: "ellipsis",

			"&:hover": {
				cursor: "pointer",
				background: bg_color_hover || colors["ntr-light-03"],
			},
		}),
		control: (provided, state) => ({
			...provided,
			// none of react-select's styles are passed to <Control />
			borderWidth: border_width ? rem(border_width) : "0 !important",
			borderColor: border_color
				? transparentize(border_color, 0.3)
				: "none !important",
			boxShadow: "none",
			cursor: "pointer",
			backgroundColor: bg_color_control || colors["ntr-light-04"],
			padding: padding_control ? rem(padding_control) : rem([12, 24]),
			borderRadius: radius ? rem(radius) : rem(16),
			height: height ? rem(height) : "auto",
			width: width ? rem(width) : "auto",
		}),

		menu: (provided, state) => ({
			...provided,
			border: "none",
			background: bg_color_menu || colors["ntr-light-04"],
			boxShadow: "none",
			borderRadius: radius ? rem(radius) : rem(16),
			width: "100%",
			overflow: "hidden",
			maxHeight: rem(250),
			overflowY: "auto",
			zIndex: 99,
		}),
		placeholder: (provided) => ({
			...provided,
			fontSize: rem(15),
			fontWeight: 400,
			lineHeight: 1.7,
			letterSpacing: "0.02em",
			color: "#9697af !important",
			opacity: 1,
		}),
		menuList: (provided) => ({
			...provided,
			border: "none",
		}),
		singleValue: (provided, state) => {
			const singleValueStyles = {
				opacity: state.isDisabled ? 0.5 : 1,
				transition: "opacity 300ms",
				fontSize: rem(15),
				lineHeight: 1.7,
				color:
					`${control_color} !important` ||
					`${colors["primary-black"]} !important`,
				letterSpacing: "0.02em",
				fontWeight: 400,
				padding: 0,
				maxWidth: "100%",
				overflow: "hidden",
				textOverflow: "ellipsis",
				whiteSpace: "nowrap",
			};

			return { ...provided, ...singleValueStyles };
		},
		valueContainer: (provided) => ({
			...provided,
			padding: 0,
		}),
		dropdownIndicator: (provided) => ({
			...provided,
			padding: 4,
			color: colors["primary-black"],
		}),
	};

	return (
		<Select
			className="g-select"
			styles={selectStyles}
			isSearchable={false}
			options={options}
			placeholder={placeholder}
			instanceId={instanceId}
			defaultValue={options[1]}
			noOptionsMessage={() => "No options"}
			components={{
				Menu: (props) => (
					<components.Menu {...props} className="g-select-dropdown" />
				),
				IndicatorsContainer: (props) => (
					<components.IndicatorsContainer {...props}>
						<ChevronDown />
					</components.IndicatorsContainer>
				),
				Control: (props) => (
					<components.Control {...props} className="g-select-control" />
				),
			}}
			{...rest}
		/>
	);
};

export default GSelect;
