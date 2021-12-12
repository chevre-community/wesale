// import { revealNavOnScroll } from "@/lib";
import React, { useEffect } from "react";

import { Footer, Navbar } from "@/components";

const MainLayout = ({ children }) => {
	// useEffect(() => {
	// 	revealNavOnScroll();

	// 	return () => {
	// 		window.removeEventListener("scroll", revealNavOnScroll);
	// 	};
	// }, []);
	return (
		<>
			<Navbar />
			<div className="g-container">{children}</div>
			<Footer />
		</>
	);
};

export default MainLayout;
