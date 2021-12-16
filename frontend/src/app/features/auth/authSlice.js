import { createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import Cookies from "js-cookie";
import { HYDRATE } from "next-redux-wrapper";

const initialState = {
	user: null,
	token: null,
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
	},
	extraReducers: {
		[HYDRATE]: (state, { payload }) => {
			return {
				...state,
				...payload.auth,
			};
		},
	},
});

export const authSelectors = (state) => state.auth;

export const { setCredentials, setUser } = authSlice.actions;

export default authSlice.reducer;
