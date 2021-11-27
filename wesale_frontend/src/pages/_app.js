// Redux
import { wrapper } from "@/app/store";
import { SSRProvider } from "@react-aria/ssr";

import { useEffect } from "react";

// Next JS
import App from "next/app";
import { useRouter } from "next/router";

import { NextSeo } from "next-seo";

import { LoginModal, MainLayout, RegisterModal } from "@/components";
import { NProgress } from "@/components";

// Context
import { MainProvider } from "@/context/providers/main-context";

import "@/styles/main.scss";
import "animate.css";
import "bootstrap/scss/bootstrap.scss";
import "mapbox-gl/dist/mapbox-gl.css";
import "swiper/css";
import "swiper/css/navigation";
import "swiper/css/pagination";
import "swiper/css/zoom";

const MyApp = ({ Component, ...pageProps }) => {
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

MyApp.getInitialProps = async (appContext) => {
	// calls page's `getInitialProps` and fills `appProps.pageProps`
	const appProps = await App.getInitialProps(appContext);

	return { ...appProps };
};

export default wrapper.withRedux(MyApp, {
	debug: true,
});
