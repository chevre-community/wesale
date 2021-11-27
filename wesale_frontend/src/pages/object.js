import { wrapper } from "@/app/store";

import React from "react";

import { NextSeo } from "next-seo";

import HomePage from "@/components/home/HomePage.component";

const ObjectsPage = () => {
	return (
		<>
			<NextSeo title="Wesale" description="Wesale" />
			<HomePage />
		</>
	);
};

export const getServerSideProps = wrapper.getServerSideProps(
	(store) => async (ctx) => {
		return {
			props: {},
		};
	}
);

export default ObjectsPage;
