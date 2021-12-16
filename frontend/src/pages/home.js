import { wrapper } from "@/app/store";
import axios from "axios";

import React from "react";
import { useEffect } from "react";

import { NextSeo } from "next-seo";

import HomePage from "@/components/home/HomePage.component";

const Home = () => {
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

export default Home;
