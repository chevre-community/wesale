import React from "react";

import { FilterForm, withActiveForm } from "@/components";

const FilterFormWrapper = () => {
	return (
		<div className="filter-form-wrapper">
			<div className="g-container">{withActiveForm(FilterForm)}</div>
		</div>
	);
};

export default FilterFormWrapper;
