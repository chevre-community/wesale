import validator from "validator";

export default function validateLoginFields(email, password, errors) {
	if (validator.isEmpty(email)) {
		errors.email = "Email is required!";
	}

	if (validator.isEmpty(password)) {
		errors.password = "Password is required!";
	}

	if (!validator.isEmail(email)) {
		errors.email = "Please, enter valid email";
	}
}
