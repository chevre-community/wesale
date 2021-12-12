let lastScroll = 0;

function initRevealNavOnScroll(body) {
	const currentScroll = window.scrollY;

	if (currentScroll <= 0) {
		body.classList.remove("scroll-up");

		return;
	}

	if (currentScroll > lastScroll && !body.classList.contains("scroll-down")) {
		body.classList.remove("scroll-up");
		body.classList.add("scroll-down");
	}

	if (currentScroll < lastScroll && body.classList.contains("scroll-down")) {
		body.classList.remove("scroll-down");
		body.classList.add("scroll-up");
	}

	lastScroll = currentScroll;
}

export default function revealNavOnScroll() {
	if (typeof window === "object") {
		const body = document.body;
		window.addEventListener("scroll", () => initRevealNavOnScroll(body));
	}
}
