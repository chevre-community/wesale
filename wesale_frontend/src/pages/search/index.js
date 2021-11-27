import React from "react";

const SearchPageForRedirect = () => {
	return <></>;
};

SearchPageForRedirect.getInitialProps = ({ res }) => {
	if (res) {
		res.writeHead(301, {
			Location: "/search/list",
		});

		res.end();
	}

	return {
		props: {},
	};
};

export default SearchPageForRedirect;
