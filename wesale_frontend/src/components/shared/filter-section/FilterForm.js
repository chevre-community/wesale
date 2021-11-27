import { toggleActiveForm } from "@/app/filter-form/filterFormSlice";

import React from "react";
import { Tab, Tabs } from "react-bootstrap";
import { useDispatch } from "react-redux";

import { Router, useRouter } from "next/router";

import { FilterFormHome, FilterFormObject, withActiveForm } from "@/components";

const FilterForm = ({ activeForm }) => {
	const dispatch = useDispatch();
	const router = useRouter();

	const options = [
		{
			label: "Купить",
			value: "Купить",
		},
	];

	const options2 = [
		{
			label: "Квартиру",
			value: "Квартиру",
		},
	];
	return (
		<div className="filter-form-tabs">
			<Tabs
				id="filter-form-tabs"
				activeKey={activeForm}
				transition={true}
				onSelect={(key) => {
					router.push(`/${key}`);
					Router.events.on("routeChangeComplete", () =>
						dispatch(toggleActiveForm(key))
					);
				}}
			>
				<Tab.Pane eventKey="home" title="Дом">
					<FilterFormHome
						colors={{
							icon: "white",
						}}
						options={options}
						options2={options2}
					/>
				</Tab.Pane>
				<Tab.Pane eventKey="object" title="Объект">
					<FilterFormObject
						colors={{
							icon: "white",
						}}
						options={options}
						options2={options2}
					/>
				</Tab.Pane>
			</Tabs>
		</div>
	);
};

export default FilterForm;
