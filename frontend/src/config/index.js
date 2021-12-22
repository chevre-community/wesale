const { default: axios } = require("axios");
const { WESALE_API_URL } = require("./base");

export const weAxios = axios.create({
	baseURL: WESALE_API_URL,
});
