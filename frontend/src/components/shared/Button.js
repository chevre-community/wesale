import React from "react";

import { withLoader } from "@/components";

import classNames from "classnames";

const Button = ({
	children,
	as,
	variant,
	size,
	loader,
	className,
	...rest
}) => {
	const Element = as || "button";

	const classes = classNames(
		variant ? `g-btn-${variant}` : "g-btn-primary",
		`${className}`
		// size && `btn-${size}`
		// loader && "btn-loader"
	);

	const ButtonJSX = () => (
		<Element className={classes} {...rest}>
			<span>{children}</span>
		</Element>
	);

	if (loader) {
		return withLoader({ ...loader, variant })(ButtonJSX);
	}

	return <ButtonJSX />;
};

export default Button;
