import React from "react";
import { FaSpinner } from "react-icons/fa";

import classNames from "classnames";

const withLoader =
	({ isLoading, withContent, location, variant, ...rest }) =>
	// eslint-disable-next-line react/display-name
	(WrappedComponent) => {
		const loaderIconClasses = classNames(
			"g-loader-icon",
			location ? `g-loader-icon--${location}` : "g-loader-icon--center",
			variant ? `g-loader--${variant}` : "g-loader--primary"
		);

		const loaderClasses = classNames(
			"g-loader",
			location ? `g-loader--${location}` : "g-loader--center"
		);

		if (isLoading) {
			if (withContent) {
				return (
					<div className={loaderClasses}>
						<WrappedComponent />
						<FaSpinner className={loaderIconClasses} />
					</div>
				);
			}

			return <FaSpinner />;
		}

		return <WrappedComponent />;
	};

export default withLoader;
