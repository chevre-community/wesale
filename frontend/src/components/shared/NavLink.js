import React, { Children, cloneElement } from "react";

import Link from "next/link";
import { useRouter } from "next/router";

const NavLink = ({ children, activeClassName, ...props }) => {
	const router = useRouter();
	const child = Children.only(children);

	const className = child.props.className || "";
	const active = router.pathname === props.href;

	const childProps = {
		...props,
		className: className + (active ? ` ${activeClassName}` : ""),
	};

	return <Link {...props}>{cloneElement(child, childProps)}</Link>;
};

export default NavLink;
