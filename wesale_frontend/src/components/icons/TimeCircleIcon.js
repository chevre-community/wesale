import React from "react";

const TimeCircleIcon = ({ width, height }) => {
	return (
		<svg
			width={width}
			height={height}
			viewBox={`0 0 ${width} ${height}`}
			fill="none"
			xmlns="http://www.w3.org/2000/svg"
		>
			<path
				fillRule="evenodd"
				clipRule="evenodd"
				d="M19.2498 10.1743C19.2498 15.3574 15.1088 19.5584 9.99982 19.5584C4.89082 19.5584 0.749817 15.3574 0.749817 10.1743C0.749817 4.9913 4.89082 0.790283 9.99982 0.790283C15.1088 0.790283 19.2498 4.9913 19.2498 10.1743Z"
				stroke="#434343"
				strokeWidth="1.5"
				strokeLinecap="round"
				strokeLinejoin="round"
			/>
			<path
				d="M13.4314 13.1593L9.66144 10.8777V5.96045"
				stroke="#3F8CFF"
				strokeWidth="1.5"
				strokeLinecap="round"
				strokeLinejoin="round"
			/>
		</svg>
	);
};

export default TimeCircleIcon;
