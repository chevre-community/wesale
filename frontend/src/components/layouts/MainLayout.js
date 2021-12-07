import React from "react";

import { Footer, Navbar } from "@/components";

const MainLayout = ({ children }) => {
	return (
		<>
			<Navbar />
			<div className="g-container">{children}</div>
			<Footer />
		</>
	);
};

export default MainLayout;
