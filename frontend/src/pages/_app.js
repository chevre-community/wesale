// Redux
import { setUser } from "@/app/features/auth/authSlice";
import { authEndpoints } from "@/app/services/authService";
import {
	initializeStore,
	removeUndefined,
	useStore, // wrapper,
} from "@/app/store";
import { SSRProvider } from "@react-aria/ssr";

import { Provider, useDispatch } from "react-redux";

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
	const store = useStore(pageProps.initialReduxState);

	const getLayout =
		Component.getLayout || ((page) => <MainLayout>{page}</MainLayout>);

	return (
		<SSRProvider>
			<Provider store={store}>
				<NextSeo title="Wesale" description="Wesale" />
				<NProgress />
				<MainProvider>{getLayout(<Component {...pageProps} />)}</MainProvider>
				<LoginModal />
				<RegisterModal />
			</Provider>
		</SSRProvider>
	);
};

MyApp.getInitialProps = async (appContext) => {
	const store = initializeStore();
	// calls page's `getInitialProps` and fills `appProps.pageProps`
	const appProps = await App.getInitialProps(appContext);

	console.log(store);

	return { ...appProps, initialReduxState: removeUndefined(store.getState()) };
};

export default MyApp;

// export default wrapper.withRedux(MyApp, {
// 	debug: true,
// });
