import { createSlice } from "@reduxjs/toolkit";
import { HYDRATE } from "next-redux-wrapper";

const initialState = {
	isShowing: {
		login: false,
		signup: false,
		changeEmail: false,
		basicInfo: false,
	},
};

export const modalSlice = createSlice({
	name: "modal",
	initialState,
	reducers: {
		TOGGLE_MODAL: (state, { payload }) => {
			const { modal, value } = payload;
			state.isShowing[modal] = value;
		},
	},
	extraReducers: {
		[HYDRATE]: (state, { payload }) => {
			const modalState = payload.modal;

			return {
				...state,
				...modalState,
			};
		},
	},
});

export const { TOGGLE_MODAL } = modalSlice.actions;

export const selectIsShowing = (state) => state.modal.isShowing;

export default modalSlice.reducer;
