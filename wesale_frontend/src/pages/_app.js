import { autoResize } from "@/lib";
import "@/styles/main.scss";
import { SSRProvider } from "@react-aria/ssr";
import "animate.css";
import "bootstrap/scss/bootstrap.scss";
import "mapbox-gl/dist/mapbox-gl.css";

import { useEffect } from "react";

// Next JS
import { useRouter } from "next/router";

import "swiper/css";
import "swiper/css/navigation";
import "swiper/css/pagination";
import "swiper/css/zoom";

import { MainLayout } from "@/components";
import { NProgress } from "@/components";

// Context
import { MainProvider } from "@/context/providers/main-context";

function MyApp({ Component, pageProps }) {
	// const getLayout =
	// 	Component.getLayout || ((page) => <MainLayout>{page}</MainLayout>);
	const getLayout = Component.getLayout || ((page) => <>{page}</>);

	useEffect(() => {
		autoResize();
	}, []);

	return (
		<SSRProvider>
			<NProgress />
			<MainProvider>{getLayout(<Component {...pageProps} />)}</MainProvider>
		</SSRProvider>
	);
}

export default MyApp;
