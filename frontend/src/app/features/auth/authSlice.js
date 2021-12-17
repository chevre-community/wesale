import { authService } from "@/app/services/authService";
import { createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import Cookies from "js-cookie";
import { HYDRATE } from "next-redux-wrapper";

const initialState = {
	user: null,
	token: null,
	errors: {},
};

const authSlice = createSlice({
	name: "auth",
	initialState,
	reducers: {
		setCredentials: (state, { payload }) => {
			state.token = payload;
			Cookies.set("token", state.token);
		},
		setUser: (state, { payload }) => {
			console.log(payload, "payload");
			state.user = payload;
			console.log({ user: state.user });
		},
		setAuthLoginErrors: (state, { payload }) => {
			state.errors[payload.key] = payload.error;
		},
		resetAuthLoginErrors: (state) => {
			state.errors = {};
		},
	},
	extraReducers: (builder) => {
		builder.addCase(HYDRATE, (state, { payload }) => {
			return {
				...state,
				...payload.auth,
			};
		});
		builder.addMatcher(
			authService.endpoints.authLogin.matchFulfilled,
			(state, { payload }) => {
				// console.log({ state, payload });
				state.token = payload.token;
				state.errors = {};
			}
		);
		builder.addMatcher(
			authService.endpoints.authLogin.matchRejected,
			(state, { payload }) => {
				const { errors } = payload.data;
				console.log({ errors });
				Object.keys(errors).forEach((key) => {
					state.errors[key] = errors[key];
				});
			}
		);
	},
});

export const authSelectors = (state) => state.auth;

export const {
	setCredentials,
	setUser,
	setAuthLoginErrors,
	resetAuthLoginErrors,
} = authSlice.actions;

export default authSlice.reducer;
