import React from "react";

const Checkbox = ({ id, name, label, ...rest }) => {
  return (
    <div className="g-checkbox">
      <input type="checkbox" id={id} name={name} {...rest} />
      <label htmlFor={id}>{label}</label>
    </div>
  );
};

export default Checkbox;
