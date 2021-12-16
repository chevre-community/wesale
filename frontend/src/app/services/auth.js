import { WESALE_API_URL } from "@/config/base";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/dist/query/react";

export const authApi = createApi({
	reducerPath: "auth",
	baseQuery: fetchBaseQuery({
		baseUrl: WESALE_API_URL,
	}),
	endpoints: (builder) => ({
		auth2Login: builder.mutation({
			query: (data) => ({
				url: "/account/login",
				method: "POST",
				body: data,
			}),
		}),
	}),
});
