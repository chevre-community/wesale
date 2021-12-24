import { authService } from "@/app/services/authService";
import { weAxios } from "@/config";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import Cookies from "js-cookie";
import { HYDRATE } from "next-redux-wrapper";

const initialState = {
	user: null,
	token: null || Cookies.get("token"),
	errors: {
		login: {},
		signup: {},
	},
	messages: {
		login: {},
		signup: {},
	},
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

			// if (res.data) {
			// 	return res.data;
			// }
			// rejectWithValue(res);
			return res.data;
		} catch (err) {
			rejectWithValue(err?.response);
			return {
				error: {
					status: err.response.status,
					message: err.response.statusText,
				},
			};
		}
	}
);

const authSlice = createSlice({
	name: "auth",
	initialState,
	reducers: {
		// Signup and Login
		setCredentials: (state, { payload }) => {
			state.token = payload;
			Cookies.set("token", state.token);
		},
		// Log out
		removeCredentials: (state) => {
			state.token = null;
		},
		// Login
		setUser: (state, { payload }) => {
			console.log(payload, "payload");
			state.user = payload;
			console.log({ user: state.user });
		},
		// Log out
		removeUser: (state) => {
			state.user = null;
		},
		// Login
		setAuthLoginErrors: (state, { payload }) => {
			state.errors.login[payload.key] = payload.error;
		},
		resetAuthLoginErrors: (state) => {
			state.errors.login = {};
		},
		// Sign up
		setAuthSignupErros: (state, { payload }) => {
			state.errors.signup[payload.key] = payload.error;
		},
		resetAuthSignupErrors: (state) => {
			state.errors.signup = {};
		},
		setAuthMessages: (state, { payload }) => {
			const { messages, auth } = payload;
			console.log(messages, auth);
			Object.keys(messages).forEach((key) => {
				state.messages[auth][key] = messages[key];
			});
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
		// Get User Token
		builder.addCase(getUserByToken.rejected, (state, { payload }) => {
			state.response = payload.error;
		});
		builder.addCase(getUserByToken.fulfilled, (state, { payload }) => {
			console.log(payload);
			state.user = payload;
		});
		// Login
		builder.addMatcher(
			authService.endpoints.authLogin.matchFulfilled,
			(state, { payload }) => {
				console.log({ state, payload });
				state.token = payload.token;
				state.errors.login = {};
			}
		);
		builder.addMatcher(
			authService.endpoints.authLogin.matchRejected,
			(state, { payload }) => {
				const { errors } = payload.data;
				console.log({ errors });
				Object.keys(errors).forEach((key) => {
					state.errors.login[key] = errors[key];
				});
			}
		);
		// Signup
		builder.addMatcher(
			authService.endpoints.authSignup.matchRejected,
			(state, { payload }) => {
				const { errors } = payload.data;
				Object.keys(errors).forEach((key) => {
					state.errors.signup[key] = errors[key];
				});
			}
		);
		builder.addMatcher(
			authService.endpoints.authSignup.matchFulfilled,
			(state, { payload }) => {
				authSlice.caseReducers.setAuthMessages({
					messages: payload,
					auth: "signup",
				});

				state.errors.signup = {};
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
	setAuthLoginErrors,
	setAuthSignupErros,
	setAuthMessages,
	removeCredentials,
	removeUser,
	resetAuthLoginErrors,
	resetAuthSignupErrors,
} = authSlice.actions;

export default authSlice.reducer;
