import React, { useState } from "react";

const { createContext, useContext, useReducer, useEffect } = require("react");

const { FilterFormWrapperReducer } = require("@/context");

const store = {
	FilterFormWrapperIsOpen: false,
	images: [
		"https://media.istockphoto.com/photos/digitally-rendered-view-of-a-beautiful-living-room-picture-id1284941025?b=1&k=20&m=1284941025&s=170667a&w=0&h=JfkOADW4trv6oQWATk6nuDQdBTEQig3c_u03pwM58PI=",
		"https://media.istockphoto.com/photos/luxury-great-room-with-lots-of-glass-windows-picture-id1320898410?b=1&k=20&m=1320898410&s=170667a&w=0&h=zPzrpICSfE0-3WzjS2Dgh5_skyb9CA8X-vzU6yTTOgs=",
		"https://images.unsplash.com/photo-1591088398332-8a7791972843?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8aG9tZSUyMGRlc2lnbnxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
		"https://images.unsplash.com/photo-1618221195710-dd6b41faaea6?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
		"https://images.unsplash.com/photo-1616486029423-aaa4789e8c9a?ixid=MnwxMjA3fDB8MHxzZWFyY2h8OXx8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
	],
};

const Main = createContext();
Main.displayName = "Main Store";

const useMain = () => useContext(Main);

const MainProvider = ({ children }) => {
	const [state, dispatch] = useReducer(FilterFormWrapperReducer, store);
	const [navHeight, setNavHeight] = useState(0);
	const [filterFormHeight, setFilterFormHeight] = useState(0);

	useEffect(() => {
		const navHeight = document?.querySelector(".g-nav")?.clientHeight;
		const formHeight = document?.querySelector(
			".filter-form-wrapper"
		)?.clientHeight;

		setNavHeight(navHeight);
		setFilterFormHeight(formHeight);
	}, [filterFormHeight]);

	return (
		<Main.Provider
			value={{
				mainState: {
					...state,
					navHeight,
					filterFormHeight,
				},
				mainDispatch: dispatch,
			}}
		>
			{children}
		</Main.Provider>
	);
};

export { useMain, MainProvider };
