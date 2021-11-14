const toRem = (val) => {
  return val / 16 + "rem";
};

const rem = (val) => {
  const result = [];

  if (Array.isArray(val)) {
    val.forEach((v) => {
      if (!isNaN(v)) {
        result.push(toRem(v));
      } else {
        result.push(v);
      }
    });

    return result.toString().split(",").join(" ");
  } else {
    if (!isNaN(val)) {
      return toRem(val);
    } else {
      return val;
    }
  }
};

export default rem;
