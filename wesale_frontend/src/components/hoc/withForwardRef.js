/* eslint-disable react/display-name */
import React, { forwardRef, Fragment } from "react";

const withForwardRef = (WrapperComponent) =>
  forwardRef((props, ref) => (
    <Fragment ref={ref}>
      <WrapperComponent {...props} />
    </Fragment>
  ));

export default withForwardRef;
