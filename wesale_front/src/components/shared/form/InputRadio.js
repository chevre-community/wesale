import React from "react";

const InputRadio = ({ id, name, label, ...rest }) => {
  return (
    <div className="g-radio">
      <input type="radio" name={name} id={id} {...rest} />
      <label htmlFor={id}>{label}</label>
    </div>
  );
};

export default InputRadio;
