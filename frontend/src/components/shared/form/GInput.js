import React from "react";

import classNames from "classnames";

/**
 *
 * @param {*} supported types: text, password, email, number, tel, url
 *  @returns
 */

const GInput = ({
	type,
	placeholder,
	name,
	id,
	classname,
	disabled,
	defaultValue,
	...rest
}) => {
	return (
		<input
			type={type || "text"}
			className={classname ? classNames(classname, "g-input") : "g-input"}
			placeholder={placeholder}
			name={name}
			id={id}
			disabled={disabled}
			defaultValue={defaultValue}
			{...rest}
		/>
	);
};

export default GInput;
