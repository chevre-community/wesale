import React, { useEffect, useRef, useState } from "react";
import { CSSTransition } from "react-transition-group";

import { FilterFormWrapper, Footer, Navbar } from "@/components";

import { useMain } from "@/context/providers/main-context";

const MainLayout = ({ children }) => {
	return (
		<>
			<Navbar />
			<div className="g-container">{children}</div>
			<Footer />
		</>
	);
};

export default MainLayout;
