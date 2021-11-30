const handleTabs = ({ tabs, tabBtns, btn, router, type }) => {
	const target = btn.dataset["target"];

	const pane = document.getElementById(target);

	pane?.classList.remove("hidden");
	pane?.classList.add("fade");
	pane?.classList.add("show");
	btn.classList.add("active");

	type !== "onload" && router.push(`/${target}`);

	console.log(tabs);

	tabs.forEach((tab, i) => {
		if (tab !== pane) {
			tab.classList.add("hidden");
			tab.classList.remove("show");
			tabBtns[i].classList.remove("active");
		}
	});
};

export default handleTabs;
