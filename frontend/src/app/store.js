import { configureStore } from "@reduxjs/toolkit";
import { setupListeners } from "@reduxjs/toolkit/dist/query";
import { createWrapper } from "next-redux-wrapper";

import authSlice from "./features/auth/authSlice";
import filterFormSlice from "./features/filter-form/filterFormSlice";
import mockDataSlice from "./features/mock/mockDataSlice";
import modalSlice from "./features/modal/modalSlice";
import { authApi } from "./services/auth";
import { authService } from "./services/authService";

export const makeStore = () =>
	configureStore({
		reducer: {
			modal: modalSlice,
			filterForm: filterFormSlice,
			mockData: mockDataSlice,
			auth: authSlice,
			[authService.reducerPath]: authService.reducer,
		},
		middleware: (getDefaultMiddleware) =>
			getDefaultMiddleware().concat(authService.middleware),
		devTools: process.env.NODE_ENV !== "production",
	});

setupListeners(makeStore().dispatch);

export const wrapper = createWrapper(makeStore);
