import { configureStore } from "@reduxjs/toolkit";
import { createWrapper } from "next-redux-wrapper";

import authSlice from "./features/auth/authSlice";
import filterFormSlice from "./features/filter-form/filterFormSlice";
import mockDataSlice from "./features/mock/mockDataSlice";
import modalSlice from "./features/modal/modalSlice";

export const makeStore = () =>
	configureStore({
		reducer: {
			modal: modalSlice,
			filterForm: filterFormSlice,
			mockData: mockDataSlice,
			auth: authSlice,
		},
		devTools: process.env.NODE_ENV !== "production",
	});

export const wrapper = createWrapper(makeStore);
