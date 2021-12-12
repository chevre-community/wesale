import React from "react";

const DocumentIcon = ({ stroke }) => {
	if (!stroke) {
		return (
			<svg
				width="22"
				height="22"
				viewBox="0 0 22 22"
				fill="none"
				xmlns="http://www.w3.org/2000/svg"
			>
				<path
					fillRule="evenodd"
					clipRule="evenodd"
					d="M15.1559 1C15.1559 1 6.81588 1.00435 6.80285 1.00435C3.80448 1.02281 1.94788 2.99565 1.94788 6.00489V15.9951C1.94788 19.0196 3.8186 21 6.84304 21C6.84304 21 15.182 20.9967 15.1961 20.9967C18.1945 20.9783 20.0522 19.0043 20.0522 15.9951V6.00489C20.0522 2.98045 18.1804 1 15.1559 1Z"
					fill="white"
					stroke="white"
					strokeWidth="2"
					strokeLinecap="round"
					strokeLinejoin="round"
				/>
				<path
					fillRule="evenodd"
					clipRule="evenodd"
					d="M14.9471 15.6372H7.10352H14.9471Z"
					fill="#3F8CFF"
				/>
				<path
					d="M14.9471 15.6372H7.10352"
					stroke="#3F8CFF"
					strokeWidth="2"
					strokeLinecap="round"
					strokeLinejoin="round"
				/>
				<path
					fillRule="evenodd"
					clipRule="evenodd"
					d="M14.9471 11.0893H7.10352H14.9471Z"
					fill="#3F8CFF"
				/>
				<path
					d="M14.9471 11.0893H7.10352"
					stroke="#3F8CFF"
					strokeWidth="2"
					strokeLinecap="round"
					strokeLinejoin="round"
				/>
				<path
					fillRule="evenodd"
					clipRule="evenodd"
					d="M10.0965 6.55173H7.10352H10.0965Z"
					fill="#3F8CFF"
				/>
				<path
					d="M10.0965 6.55173H7.10352"
					stroke="#3F8CFF"
					strokeWidth="2"
					strokeLinecap="round"
					strokeLinejoin="round"
				/>
			</svg>
		);
	}

	return (
		<svg
			width="22"
			height="24"
			viewBox="0 0 22 24"
			fill="none"
			xmlns="http://www.w3.org/2000/svg"
		>
			<path
				d="M15.3418 17.1009H6.71387"
				stroke="#3F8CFF"
				strokeWidth="2"
				strokeLinecap="round"
				strokeLinejoin="round"
			/>
			<path
				d="M15.3418 12.098H6.71387"
				stroke="#3F8CFF"
				strokeWidth="2"
				strokeLinecap="round"
				strokeLinejoin="round"
			/>
			<path
				d="M10.0071 7.10678H6.71484"
				stroke="#3F8CFF"
				strokeWidth="2"
				strokeLinecap="round"
				strokeLinejoin="round"
			/>
			<path
				fillRule="evenodd"
				clipRule="evenodd"
				d="M15.5718 1C15.5718 1 6.39778 1.00478 6.38344 1.00478C3.08523 1.0251 1.04297 3.19522 1.04297 6.50538V17.4946C1.04297 20.8215 3.10076 23 6.42765 23C6.42765 23 15.6005 22.9964 15.616 22.9964C18.9142 22.9761 20.9577 20.8048 20.9577 17.4946V6.50538C20.9577 3.17849 18.8987 1 15.5718 1Z"
				stroke="#200E32"
				strokeWidth="2"
				strokeLinecap="round"
				strokeLinejoin="round"
			/>
		</svg>
	);
};

export default DocumentIcon;
