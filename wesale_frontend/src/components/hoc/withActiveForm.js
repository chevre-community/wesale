import {
	selectActiveForm,
	toggleActiveForm,
} from "@/app/features/filter-form/filterFormSlice";

import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";

import { useRouter } from "next/router";

export default function WithActiveForm(WrappedComponent) {
	const dispatch = useDispatch();
	const activeForm = useSelector(selectActiveForm);

	const { pathname } = useRouter();

	useEffect(() => {
		if (pathname === "/object") {
			dispatch(toggleActiveForm("object"));
		}
		dispatch(toggleActiveForm("home"));
	}, [pathname, dispatch]);

	return <WrappedComponent activeForm={activeForm} />;
}
