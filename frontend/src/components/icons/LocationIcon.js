import React from "react";

const LocationIcon = ({ width, height }) => {
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
				d="M1.23914 8.88983C1.25354 4.58779 4.7029 1.11214 8.94348 1.12675C13.1841 1.14137 16.6101 4.64072 16.5957 8.94276V9.03098C16.5435 11.8275 15.0044 14.4122 13.1174 16.4324C12.0382 17.5692 10.8331 18.5757 9.52609 19.4317C9.1766 19.7384 8.6582 19.7384 8.3087 19.4317C6.3602 18.1451 4.65007 16.5207 3.25653 14.6327C2.01449 12.9864 1.3093 10.9882 1.23914 8.9163L1.23914 8.88983Z"
				stroke="#434343"
				strokeWidth="1.5"
				strokeLinecap="round"
				strokeLinejoin="round"
			/>
			<ellipse
				cx="8.91741"
				cy="9.03975"
				rx="2.46087"
				ry="2.49654"
				stroke="#3F8CFF"
				strokeWidth="1.5"
				strokeLinecap="round"
				strokeLinejoin="round"
			/>
		</svg>
	);
};

export default LocationIcon;
