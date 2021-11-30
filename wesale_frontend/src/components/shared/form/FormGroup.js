import React from "react";

import classNames from "classnames";

const FormGroup = ({ children, label, id, error, info, disabled, size }) => {
	// className={classNames("g-form-group", {
	// 	disabled: disabled,
	// })}
	return (
		<div
			className={classNames("g-form-group", {
				[`g-form-group__${size}`]: size,
			})}
		>
			<label htmlFor={id} className="g-label">
				{label}
			</label>
			{children}
			{error && (
				<span className="g-error g-caption__md--medium text-secondary-error">
					{error}
				</span>
			)}
			{info && (
				<span className="g-caption g-caption__md--medium text-ntr-dark-02">
					{info}
				</span>
			)}
		</div>
	);
};

export default FormGroup;
