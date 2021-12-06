import React from "react";

import { AdvancedFilterModal, Footer, Navbar } from "@/components";

const MainLayout = ({ children }) => {
	return (
		<>
			<Navbar />
			<div className="g-container">{children}</div>
			<AdvancedFilterModal justClose={true} modal="advancedFilter" />
			<Footer />
		</>
	);
};

export default MainLayout;
