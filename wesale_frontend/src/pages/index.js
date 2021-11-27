import React from "react";

const HomePageIndex = () => {
	return <></>;
};

HomePageIndex.getInitialProps = ({ res }) => {
	if (res) {
		res.writeHead(301, {
			Location: "/home",
		});

		res.end();
	}

	return {
		props: {},
	};
};

export default HomePageIndex;
