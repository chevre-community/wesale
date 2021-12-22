import validator from "validator";

export default function validateSignupFields({
	firstname,
	lastname,
	email,
	password,
	confirmPassword,
	acceptTerms,
	errors,
	authErrors,
}) {
	if (firstname.length < 2) {
		errors.firstname = "Firstname must contain at least 2 charachters";
	} else if (firstname.length > 35) {
		errors.firstname = "Firstname must contain max 255 charachters";
	} else if (authErrors.FirstName) {
		errors.firstName = authErrors.FirstName;
	}

	if (lastname.length < 2) {
		errors.lastname = "Lastname must contain at least 2 characters";
	} else if (lastname.length > 35) {
		errors.lastname = "Lastname must contain max 255 characters";
	} else if (authErrors.LastName) {
		errors.lastName = authErrors.LastName;
	}

	if (!validator.isEmail(email)) {
		errors.email = "Please, enter valid email";
	} else if (authErrors.Email) {
		errors.email = authErrors.Email;
	}

	if (!password.length) {
		errors.password = "Password is required!";
	} else if (authErrors.Password) {
		errors.password = authErrors.Password;
	}

	if (confirmPassword !== password) {
		errors.confirmPassword = "Passwords are different!";
	} else if (authErrors.ConfirmPassword) {
		errors.confirmPassword = authErrors.ConfirmPassword;
	}

	if (!acceptTerms) {
		errors.acceptTerms = "You have to agree with terms and conditions!";
	}
	// console.log({ authErrors });
}
