// Redux
import { setUser } from "@/app/features/auth/authSlice";
import { endpoints, useGetUserQuery } from "@/app/services/authService";
import { wrapper } from "@/app/store";
import { SSRProvider } from "@react-aria/ssr";
import Cookies from "js-cookie";

import { useEffect } from "react";
import { useDispatch } from "react-redux";

// Next JS
import App from "next/app";

import { NextSeo } from "next-seo";

import "swiper/css";
import "swiper/css/effect-fade";
import "swiper/css/navigation";
import "swiper/css/pagination";
import "swiper/css/zoom";

import { LoginModal, MainLayout, RegisterModal } from "@/components";
import { NProgress } from "@/components";

// Context
import { MainProvider } from "@/context/providers/main-context";

import "@/styles/main.scss";
import "animate.css";
import "bootstrap/scss/bootstrap.scss";
import "mapbox-gl/dist/mapbox-gl.css";

const MyApp = ({ Component, ...pageProps }) => {
	const dispatch = useDispatch();
	const { isSuccess, data } = useGetUserQuery(Cookies.get("token"));

	useEffect(() => {
		if (isSuccess) {
			dispatch(setUser(data));
			console.log("worked", { data });
		}
	}, [isSuccess]);

	const getLayout =
		Component.getLayout || ((page) => <MainLayout>{page}</MainLayout>);

	return (
		<SSRProvider>
			<NextSeo title="Wesale" description="Wesale" />
			<NProgress />
			<MainProvider>{getLayout(<Component {...pageProps} />)}</MainProvider>
			<LoginModal />
			<RegisterModal />
		</SSRProvider>
	);
};

MyApp.getInitialProps = wrapper.getInitialAppProps(
	(store) => async (appContext) => {
		// calls page's `getInitialProps` and fills `appProps.pageProps`
		const appProps = await App.getInitialProps(appContext);

		// console.log(appProps, appContext);
		// const { token } = appContext.ctx.req.cookies;

		// const getUserInfo = await store.dispatch(endpoints.getUser.initiate(token));

		// // setUser(user);

		// console.log("worked");

		return { ...appProps };
	}
);

export default wrapper.withRedux(MyApp, {
	debug: true,
});
