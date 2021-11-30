/* eslint-disable react/display-name */
import React, { forwardRef } from "react";

const withForwardRef = (WrapperComponent) =>
	forwardRef((props, ref) => (
		<div ref={ref}>
			<WrapperComponent {...props} />
		</div>
	));

export default withForwardRef;
