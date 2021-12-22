// Redux
import { getUserByToken, setUser } from "@/app/features/auth/authSlice";
import { wrapper } from "@/app/store";
import { SSRProvider } from "@react-aria/ssr";

// Next JS
import App from "next/app";
import Router from "next/router";

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

// const token =
// 	"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJjMmFiYmFlNC1mODM4LTRmYjUtOTM5Ny1iMmEyOGEzMTI0NWUiLCJ1bmlxdWVfbmFtZSI6Indlc2FsZV9tYW5hZ2VyQGdtYWlsLmNvbSIsImVtYWlsIjpbIndlc2FsZV9tYW5hZ2VyQGdtYWlsLmNvbSIsIndlc2FsZV9tYW5hZ2VyQGdtYWlsLmNvbSJdLCJzdWIiOiJ3ZXNhbGVfbWFuYWdlckBnbWFpbC5jb20iLCJqdGkiOiI1MGI1N2FjMy1jYzlmLTQzMmItYThhMy04YWE5NTllOGYwY2MiLCJuYmYiOjE2NDAwODg4NDgsImV4cCI6MTY0MTM4NDg0OCwiaWF0IjoxNjQwMDg4ODQ4fQ.bj01XusBRoMaAVF-BJ7lWy1E3HmlhK_a8QwxbM3ur3o";

const MyApp = ({ Component, pageProps }) => {
	// const store = useStore(pageProps.initialReduxState);

	const getLayout =
		Component.getLayout || ((page) => <MainLayout>{page}</MainLayout>);

	return (
		<SSRProvider>
			{/* <Provider store={store}> */}
			<NextSeo title="Wesale" description="Wesale" />
			<NProgress />
			<MainProvider>{getLayout(<Component {...pageProps} />)}</MainProvider>
			<LoginModal />
			<RegisterModal />
			{/* </Provider> */}
		</SSRProvider>
	);
};

MyApp.getInitialProps = wrapper.getInitialAppProps(
	(store) => async (appContext) => {
		// calls page's `getInitialProps` and fills `appProps.pageProps`
		// const ctx = appContext.ctx || null;
		// const res = ctx.res || null;
		const appProps = await App.getInitialProps(appContext);
		const token =
			store.getState().auth.token || appContext.ctx.req?.cookies.token || null;

		if (token) {
			const getUserFn = await store.dispatch(getUserByToken({ token }));

			console.log(getUserFn.payload.error);
			if (getUserFn.payload.error || getUserFn.error) {
				if (res) {
					if (ctx.pathname === "/dashboard") {
						res.writeHead(302, {
							Location: "/home",
						});

						res.end();
					}
				}
				// else {
				// 	console.log("res not existed");
				// 	alert("helloo");
				// 	Router.push("/home");
				// }
			}
		}

		return {
			...appProps,
		};
	}
);

export default wrapper.withRedux(MyApp, {
	debug: true,
});

// MyApp.getInitialProps = async (appContext) => {
// 	const store = initializeStore();
// 	// calls page's `getInitialProps` and fills `appProps.pageProps`
// 	const appProps = await App.getInitialProps(appContext);
// 	const getUser = await store.dispatch(getUserByToken({ token }));

// 	console.log(getUser);

// 	console.log(appContext);
// 	const ctx = appContext?.ctx;
// 	const { token } = ctx?.req?.cookies;

// 	if (token) {
// 		try {
// 			await store.dispatch(authEndpoints.getUserByToken.initiate(token));

// 			// const authState = authEndpoints.getUserByToken.select()(store.getState());
// 		} catch (err) {
// 			console.log(err);
// 		}
// 	}

// 	return {
// 		...appProps,
// 	};
// };

// export default MyApp;
