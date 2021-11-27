import { configureStore } from "@reduxjs/toolkit";
import { createWrapper } from "next-redux-wrapper";

import filterFormSlice from "./filter-form/filterFormSlice";
import mockDataSlice from "./mock/mockDataSlice";
import modalSlice from "./modal/modalSlice";

export const makeStore = () =>
	configureStore({
		reducer: {
			modal: modalSlice,
			filterForm: filterFormSlice,
			mockData: mockDataSlice,
		},
		devTools: process.env.NODE_ENV !== "production",
	});

export const wrapper = createWrapper(makeStore);
