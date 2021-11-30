import React from "react";

import { Footer, Navbar, Sidebar } from "@/components";

const DashboardLayout = ({ children }) => {
	return (
		<div className="dashboard-grid">
			<Navbar />
			<div className="dashboard">
				<Sidebar />
				<div className="dashboard-wrapper">
					{/* I didn`t use .dashboard-container inside layout component becuase even if user was not auth. they could see some pages in dashboard.  */}
					{children}
					<Footer />
				</div>
			</div>
		</div>
	);
};

export default DashboardLayout;
