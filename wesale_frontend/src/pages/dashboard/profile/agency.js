import React from "react";

import { DashboardLayout } from "@/components";

const UserProfile = () => {
	return (
		<div className="dashboard-container">
			<h1>User Profile</h1>
		</div>
	);
};

UserProfile.getLayout = (page) => {
	return <DashboardLayout>{page}</DashboardLayout>;
};

export default UserProfile;
