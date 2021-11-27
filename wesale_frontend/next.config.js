module.exports = {
	reactStrictMode: false,
	images: {
		domains: ["media.istockphoto.com", "images.unsplash.com"],
	},
	async redirects() {
		return [
			{
				source: "/",
				destination: "/404",
				permanent: true,
			},
		];
	},
};
