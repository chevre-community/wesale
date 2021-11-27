import { TOGGLE_MODAL, selectIsShowing } from "@/app/modal/modalSlice";

import { useDispatch, useSelector } from "react-redux";

const useModal = () => {
	const isShowing = useSelector(selectIsShowing);
	const dispatch = useDispatch();

	const toggle = (payload) => dispatch(TOGGLE_MODAL(payload));

	return {
		isShowing,
		toggle,
	};
};

export default useModal;
