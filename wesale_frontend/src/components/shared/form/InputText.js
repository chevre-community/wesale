import React from "react";

import classNames from "classnames";

const InputText = ({ placeholder, name, id, classname }) => {
  return (
    <input
      type="text"
      className={classname ? classNames(classname, "g-input") : "g-input"}
      placeholder={placeholder}
      name={name}
      id={id}
    />
  );
};

export default InputText;
