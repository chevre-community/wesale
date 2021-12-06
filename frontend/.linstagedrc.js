module.exports = {
	"**/*.js?{x}": (filenames) =>
		`next lin --fix --file ${filenames.map((file) =>
			file.split(process.cwd())[1].join(" --file ")
		)}`,
};
