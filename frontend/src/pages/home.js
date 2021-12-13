import { authLogin } from "@/app/features/auth/authSlice";
import { wrapper } from "@/app/store";

import React from "react";
import { useEffect } from "react";
import { useDispatch } from "react-redux";

import { NextSeo } from "next-seo";

import HomePage from "@/components/home/HomePage.component";

const Home = () => {
	const dispatch = useDispatch();

	useEffect(() => {
		dispatch(authLogin());
	}, []);

	return (
		<>
			<NextSeo title="Wesale" description="Wesale" />
			<HomePage />
		</>
	);
};

// export const getServerSideProps = wrapper.getServerSideProps(
// 	(store) => async (ctx) => {
// 		await store.dispatch(authLogin());
// 		console.log("worked");

// 		return {
// 			props: {},
// 		};
// 	}
// );

export default Home;
