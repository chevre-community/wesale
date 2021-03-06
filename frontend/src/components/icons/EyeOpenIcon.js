import React from "react";

const EyeOpenIcon = ({ stroke }) => {
	return (
		<svg
			width="20"
			height="12"
			viewBox="0 0 20 12"
			fill="none"
			xmlns="http://www.w3.org/2000/svg"
		>
			<path
				d="M1.08984 6.73886C4.67193 -1.02233 15.4182 -1.02233 19.0003 6.73886"
				stroke={stroke || "black"}
				strokeWidth="1.5"
				strokeLinecap="round"
				strokeLinejoin="round"
			/>
			<path
				d="M10.0453 10.918C9.41193 10.918 8.80452 10.6664 8.35667 10.2185C7.90883 9.77067 7.65723 9.16326 7.65723 8.52991C7.65723 7.89655 7.90883 7.28914 8.35667 6.84129C8.80452 6.39344 9.41193 6.14185 10.0453 6.14185C10.6786 6.14185 11.2861 6.39344 11.7339 6.84129C12.1817 7.28914 12.4333 7.89655 12.4333 8.52991C12.4333 9.16326 12.1817 9.77067 11.7339 10.2185C11.2861 10.6664 10.6786 10.918 10.0453 10.918Z"
				stroke={stroke || "black"}
				strokeWidth="1.5"
				strokeLinecap="round"
				strokeLinejoin="round"
			/>
		</svg>
	);
};

export default EyeOpenIcon;
