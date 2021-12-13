import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import Cookies from "js-cookie";
import { HYDRATE } from "next-redux-wrapper";

const initialState = {
	token: null,
};

export const authLogin = createAsyncThunk("auth/authLogin", async () => {
	const res = await axios.post("http://api.wesale.az/api/v1/account/login", {
		email: "wesale_manager@gmail.com",
		password: "wesalemanager",
	});

	return res.data;
});

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
			console.log("PENDING");
		},
		[authLogin.rejected]: (state, { payload }) => {
			console.log("REJECTED", payload);
		},
		[authLogin.fulfilled]: (state, { payload }) => {
			console.log("token", payload);
			// state.token = payload;
			Cookies.set("token", payload.token);
		},
	},
});

export default authSlice.reducer;
