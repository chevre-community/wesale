const toggleByScroll = (prevScroll, navHeight) => {
  let currScroll = window.scrollY;
  let isSticky;

  // const elHeight = el.clientHeight;
  const elHeight = 120;

  const overallHeight = elHeight + navHeight;

  // console.table({ currScroll, overallHeight, navHeight, elHeight });

  if (currScroll > overallHeight) {
    if (currScroll > prevScroll) {
      isSticky = false;
    } else {
      isSticky = true;
    }

    prevScroll = currScroll;

    // console.table({ prevScroll, currScroll, isSticky });
    return isSticky;
  }
};

export default toggleByScroll;
