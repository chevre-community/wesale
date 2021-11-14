const FilterFormWrapperReducer = (state, { type, payload }) => {
  switch (type) {
    case "TOGGLE_FILTER_FORM":
      return {
        ...state,
        FilterFormWrapperIsOpen: payload,
      };
      break;
    default:
      return {
        ...state,
      };
      break;
  }
};

export default FilterFormWrapperReducer;
