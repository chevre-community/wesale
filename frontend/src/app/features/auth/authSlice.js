import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import Cookies from "js-cookie";
import { HYDRATE } from "next-redux-wrapper";

const initialState = {
	token: null,
	loading: null,
	errors: null,
};

export const authLogin = createAsyncThunk(
	"auth/authLogin",
	async ({ email, password }) => {
		try {
			const res = await axios.post(
				"http://api.wesale.az/api/v1/account/login",
				{
					email,
					password,
				}
			);

			// console.log(res.data, "TRY");
			return res.data;
		} catch (err) {
			// console.log({
			// 	error: err.response,
			// 	response: JSON.parse(err.response?.request?.response),
			// });
			return {
				error: JSON.parse(err.response?.request?.response?.errors),
			};
		}
	}
);

const authSlice = createSlice({
	name: "auth",
	initialState,
	reducers: {},
	extraReducers: {
		[HYDRATE]: (state, { payload }) => {
			return {
				...state,
				...payload.auth,
			};
		},
		[authLogin.pending]: (state) => {
			state.loading = true;
		},
		[authLogin.rejected]: (state, action) => {
			// state.error = action;
			state.loading = false;

			console.log("REJECTED", action);
		},
		[authLogin.fulfilled]: (state, { payload }) => {
			if (!payload.error) {
				state.token = payload;
				Cookies.set("token", payload.token);
				console.log("IF", payload);
			} else {
				state.errors = payload.error;
				console.log("ELSE", payload);
			}

			state.loading = true;
		},
	},
});

export const authSelectors = (state) => state.auth;

export default authSlice.reducer;
