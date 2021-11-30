import rem from "./rem";

export default function autoResize() {
	if (typeof document !== "undefined") {
		const textareas = [...document?.querySelectorAll("[data-autoresize]")];

		textareas.forEach((area) => {
			const offset = area.offsetHeight - area.clientHeight;

			area.addEventListener("input", function (event) {
				event.target.style.height = "auto";
				event.target.style.height = rem(event.target.scrollHeight + offset);
			});

			area.removeAttribute("data-autoresize");
		});
	}
}
