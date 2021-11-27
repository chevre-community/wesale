import React from "react";

const HomeIcon = ({ fill, pathStroke }) => {
	return (
		<svg
			width="16"
			height="18"
			viewBox="0 0 16 18"
			fill={fill}
			xmlns="http://www.w3.org/2000/svg"
		>
			<path
				d="M5.86791 15.9439V13.5161C5.8679 12.8986 6.34484 12.3968 6.93576 12.3927H9.10032C9.69406 12.3927 10.1754 12.8957 10.1754 13.5161V13.5161V15.9515C10.1752 16.4758 10.5757 16.9043 11.0773 16.9166H12.5203C13.9588 16.9166 15.125 15.698 15.125 14.1947V14.1947V7.28821C15.1173 6.69682 14.8516 6.14149 14.4035 5.78024L9.46829 1.62578C8.6037 0.902409 7.37465 0.902409 6.51006 1.62578L1.59652 5.78778C1.14669 6.14756 0.88054 6.70382 0.875 7.29574V14.1947C0.875 15.698 2.04116 16.9166 3.47968 16.9166H4.92272C5.43677 16.9166 5.85348 16.4811 5.85348 15.9439V15.9439"
				stroke={pathStroke}
				strokeWidth="1.5"
				strokeLinecap="round"
				strokeLinejoin="round"
			/>
		</svg>
	);
};

export default HomeIcon;
