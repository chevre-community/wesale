import React from "react";
import classNames from "classnames";

const withFormGroup = (
  WrappedComponent,
  { disabled, placeholder, label, id }
) => {
  return (
    <div className={classNames("g-form-group", { disabled })}>
      <label htmlFor={id} className="g-label">
        {label}
      </label>
      <WrappedComponent id={id} placeholder={placeholder} />
    </div>
  );
};

export default withFormGroup;
