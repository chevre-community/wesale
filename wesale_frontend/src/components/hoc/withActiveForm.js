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
		if (pathname === "/home") {
			dispatch(toggleActiveForm("home"));
		} else if (pathname === "/object") {
			dispatch(toggleActiveForm("object"));
		}
	}, [pathname, dispatch]);

	return <WrappedComponent activeForm={activeForm} />;
}
