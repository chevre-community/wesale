import { WESALE_API_URL } from "@/config/base";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const authService = createApi({
	reducerPath: "auth-service",
	baseQuery: fetchBaseQuery({
		baseUrl: WESALE_API_URL,
		headers: {
			"Access-Control-Allow-Origin": "https://api.wesale.az",
		},
		prepareHeaders: (headers, { getState }) => {
			const token = getState().auth.token;

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
		}),
		getUser: builder.query({
			query: (token) => ({
				url: "/user/update",
				method: "GET",
				headers: {
					Authorization: `Bearer ${token}`,
				},
			}),
		}),
	}),
});

export const { useGetUserQuery, useAuthLoginMutation } = authService;

export const endpoints = authService.endpoints;
