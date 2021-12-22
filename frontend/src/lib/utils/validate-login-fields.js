import validator from "validator";

export default function validateLoginFields({
	email,
	password,
	errors,
	authErrors,
}) {
	if (validator.isEmpty(email)) {
		errors.email = "Email is required!";
	} else if (!validator.isEmail(email)) {
		errors.email = "Please, enter valid email";
	} else if (authErrors.Email) {
		errors.email = authErrors.Email[0];
	}

	if (validator.isEmpty(password)) {
		errors.password = "Password is required!";
	} else if (authErrors.Password) {
		errors.password = authErrors.Password[0];
	}
}
