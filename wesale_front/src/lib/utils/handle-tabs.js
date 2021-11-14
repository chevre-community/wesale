const handleTabs = (tabs, tabBtns, btn) => {
  const target = btn.dataset["target"];

  const pane = document.getElementById(target);

  pane?.classList.remove("hidden");
  pane?.classList.add("fade");
  pane?.classList.add("show");
  btn.classList.add("active");

  tabs.forEach((tab, i) => {
    if (tab !== pane) {
      tab.classList.add("hidden");
      tab.classList.remove("show");
      tabBtns[i].classList.remove("active");
    }
  });
};

export default handleTabs;
