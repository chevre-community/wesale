import React, { forwardRef, memo, useState } from "react";
import { useCallback } from "react";
import { useEffect } from "react";

import { EyeCloseIcon, EyeOpenIcon } from "@/components";

const PasswordInput = forwardRef(({ ...rest }, ref) => {
	const [isPassword, setIsPassword] = useState(false);

	const togglePasswordType = useCallback(
		(e) => {
			e.preventDefault();
			setIsPassword(!isPassword);

			if (isPassword) {
				ref.current.type = "password";
			} else {
				ref.current.type = "text";
			}
		},
		[isPassword]
	);

	return (
		<div className="g-password-field">
			<input className="" type="password" ref={ref} {...rest} />
			<button
				className="password-toggle"
				type="button"
				onClick={togglePasswordType}
			>
				{!isPassword ? <EyeCloseIcon /> : <EyeOpenIcon />}
			</button>
		</div>
	);
});

export default memo(PasswordInput);
