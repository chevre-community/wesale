import React from "react";

const SwitchButton = ({ id, label, name, ...rest }) => {
  return (
    <div className="g-switch">
      <input type="checkbox" name={name} id={id} {...rest} />
      <label htmlFor={id}>{label}</label>
    </div>
  );
};

export default SwitchButton;
