import { createSlice } from "@reduxjs/toolkit";
import { HYDRATE } from "next-redux-wrapper";

const initialState = {
	formIsOpen: false,
	activeForm: null,
};

const filterFormSlice = createSlice({
	name: "filterForm",
	initialState,
	reducers: {
		toggleForm: (state) => {
			state.formIsOpen = !state.formIsOpen;
		},
		toggleActiveForm: (state, { payload }) => {
			state.activeForm = payload;
		},
	},
	[HYDRATE]: (state, { payload }) => {
		return {
			...state,
			...payload.filterForm,
		};
	},
});

export const { toggleForm, toggleActiveForm } = filterFormSlice.actions;

export default filterFormSlice.reducer;

export const selectFormIsOpen = ({ filterForm }) => filterForm.formIsOpen;
export const selectActiveForm = ({ filterForm }) => filterForm.activeForm;
