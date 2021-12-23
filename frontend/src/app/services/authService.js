import { WESALE_API_URL } from "@/config/base";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import Cookies from "js-cookie";

export const authService = createApi({
	reducerPath: "auth-service",
	tagTypes: ["User"],
	baseQuery: fetchBaseQuery({
		baseUrl: WESALE_API_URL,
		prepareHeaders: (headers, { getState }) => {
			const token = getState().auth.token || Cookies.get("token");
			// console.log(token);

			if (token) {
				headers.set("authorization", `Bearer ${token}`);
			}
			return headers;
		},
	}),
	endpoints: (builder) => ({
		authLogin: builder.mutation({
			query: (credentials) => ({
				url: "/account/login",
				method: "POST",
				body: credentials,
			}),
			transformResponse: (response, meta, arg) => response.token,
			// invalidatesTags: ["User"],
		}),
		authSignup: builder.mutation({
			query: (credentials) => ({
				url: "/account/register",
				method: "POST",
				body: credentials,
				transformResponse: (response, meta, arg) => response.messages,
			}),
		}),
		// getUserByToken: builder.mutation({
		// 	query: (token) => ({
		// 		url: "/user/update",
		// 		method: "GET",
		// 		headers: {
		// 			Authorization: `Bearer ${token}`,
		// 		},
		// 	}),
		// }),
	}),
});

export const { useAuthLoginMutation, useAuthSignupMutation } = authService;

export const authEndpoints = authService.endpoints;
