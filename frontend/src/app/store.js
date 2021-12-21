import { configureStore } from "@reduxjs/toolkit";
import { setupListeners } from "@reduxjs/toolkit/dist/query";
import { createWrapper } from "next-redux-wrapper";

import { useMemo } from "react";

import authSlice from "./features/auth/authSlice";
import filterFormSlice from "./features/filter-form/filterFormSlice";
import mockDataSlice from "./features/mock/mockDataSlice";
import modalSlice from "./features/modal/modalSlice";
import { authService } from "./services/authService";

const store = configureStore({
	reducer: {
		modal: modalSlice,
		filterForm: filterFormSlice,
		mockData: mockDataSlice,
		auth: authSlice,
		[authService.reducerPath]: authService.reducer,
	},
	devTools: process.env.NODE_ENV !== "production",
});

export const makeStore = () => store;

export const wrapper = createWrapper(makeStore);

setupListeners(store.dispatch);

// let store;

// function initStore(preloadedState) {
// 	return configureStore({
// 		reducer: {
// 			// Add the generated reducer as a specific top-level slice
// 			modal: modalSlice,
// 			filterForm: filterFormSlice,
// 			mockData: mockDataSlice,
// 			auth: authSlice,
// 			[authService.reducerPath]: authService.reducer,
// 		},
// 		preloadedState,
// 		// Adding the api middleware enables caching, invalidation, polling,
// 		// and other useful features of `rtk-query`.
// 		middleware: (getDefaultMiddleware) =>
// 			getDefaultMiddleware().concat(authService.middleware),
// 	});
// }

// export const initializeStore = (preloadedState) => {
// 	let _store = store ?? initStore(preloadedState);

// 	// After navigating to a page with an initial Redux state, merge that state
// 	// with the current state in the store, and create a new store
// 	if (preloadedState && store) {
// 		_store = initStore({
// 			...store.getState(),
// 			...preloadedState,
// 		});
// 		// Reset the current store
// 		store = undefined;
// 	}

// 	// For SSG and SSR always create a new store
// 	if (typeof window === "undefined") return _store;
// 	// Create the store once in the client
// 	if (!store) store = _store;

// 	return _store;
// };

// export function useStore(initialState) {
// 	const store = useMemo(() => initializeStore(initialState), [initialState]);
// 	return store;
// }

// export function removeUndefined(state) {
// 	if (typeof state === "undefined") return null;
// 	if (Array.isArray(state)) return state.map(removeUndefined);
// 	if (typeof state === "object" && state !== null) {
// 		return Object.entries(state).reduce((acc, [key, value]) => {
// 			return {
// 				...acc,
// 				[key]: removeUndefined(value),
// 			};
// 		}, {});
// 	}

// 	return state;
// }
