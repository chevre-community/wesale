import React from "react";

import { DashboardLayout } from "@/components";

const UserProfile = () => {
	return (
		<div className="dashboard-container">
			<h3 className="g-title__sm--bold mb-md-24">Профиль агенства</h3>
		</div>
	);
};

UserProfile.getLayout = (page) => {
	return <DashboardLayout>{page}</DashboardLayout>;
};

export default UserProfile;
