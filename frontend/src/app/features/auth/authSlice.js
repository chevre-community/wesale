import { authService } from "@/app/services/authService";
import { weAxios } from "@/config";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import Cookies from "js-cookie";
import { HYDRATE } from "next-redux-wrapper";

const initialState = {
	user: null,
	token: null,
	errors: {},
	response: null,
};

export const getUserByToken = createAsyncThunk(
	"auth/getUserByToken",
	async ({ token }, { rejectWithValue }) => {
		const USER_INFO_ENDPOINT = "/user/info";

		try {
			const res = await weAxios.get(USER_INFO_ENDPOINT, {
				headers: {
					Authorization: `Bearer ${token}`,
				},
			});

			// dispatch(setResponse(res.data));
			// dispatch(setResponse(res.data))

			return res.data;
		} catch (err) {
			if (!err.response) throw err;
			rejectWithValue(err.response);
		}
	}
);

const authSlice = createSlice({
	name: "auth",
	initialState,
	reducers: {
		setCredentials: (state, { payload }) => {
			state.token = payload;
			Cookies.set("token", state.token);
		},
		removeCredentials: (state) => {
			state.token = null;
		},
		setUser: (state, { payload }) => {
			console.log(payload, "payload");
			state.user = payload;
			console.log({ user: state.user });
		},
		removeUser: (state) => {
			state.user = null;
		},
		setAuthLoginErrors: (state, { payload }) => {
			state.errors[payload.key] = payload.error;
		},
		resetAuthLoginErrors: (state) => {
			state.errors = {};
		},
		setResponse: (state, { payload }) => {
			console.log(response);
			state.response = payload;
		},
	},
	extraReducers: (builder) => {
		builder.addCase(HYDRATE, (state, { payload }) => {
			// console.log(payload);
			return {
				...state,
				...payload.auth,
			};
		});
		builder.addCase(getUserByToken.rejected, (state, { payload }) => {
			state.response = payload;
		});
		builder.addCase(getUserByToken.fulfilled, (state, { payload }) => {
			state.user = payload;
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
		// builder.addMatcher(
		// 	authService.endpoints.getUserByToken.matchFulfilled,
		// 	(state, { payload }) => {
		// 		// console.log(payload);
		// 		state.user = payload;
		// 	}
		// );
	},
});

export const authSelectors = (state) => state.auth;

export const {
	setCredentials,
	setUser,
	setResponse,
	setAuthLoginErrors,
	removeCredentials,
	removeUser,
	resetAuthLoginErrors,
} = authSlice.actions;

export default authSlice.reducer;
