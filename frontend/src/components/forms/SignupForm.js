import {
	authSelectors,
	resetAuthSignupErrors,
	setAuthSignupMessages,
	setCredentials,
} from "@/app/features/auth/authSlice";
import { useAuthSignupMutation } from "@/app/services/authService";
import { validateSignupFields } from "@/lib";
import { ErrorMessage, Field, Form, Formik } from "formik";

import React, { useRef } from "react";
import { useDispatch, useSelector } from "react-redux";

import Link from "next/link";
import { useRouter } from "next/router";

import { Button, FormGroup, PasswordInput } from "@/components";

import classNames from "classnames";

const SignupForm = () => {
	const passwordInput = useRef();
	const confirmPasswordInput = useRef();

	const router = useRouter();
	const dispatch = useDispatch();

	const { errors } = useSelector(authSelectors);
	const authSignupErrors = errors.signup;

	const [signup, {}] = useAuthSignupMutation();

	return (
		<>
			<Formik
				initialValues={{
					firstname: "",
					lastname: "",
					email: "",
					password: "",
					confirmPassword: "",
					acceptTerms: false,
				}}
				validate={(values) => {
					const errors = {};

					// authSignupErrors
					validateSignupFields({
						...values,
						errors,
						authErrors: authSignupErrors,
					});

					return errors;
				}}
				onSubmit={async (values, { validateForm }) => {
					try {
						await signup({ ...values }).unwrap();
					} catch (err) {
						validateForm({
							...values,
						});
					}
				}}
			>
				{({ errors, touched, isSubmitting, isValid }) => (
					<Form
						name="signup"
						// autoComplete="off"
						onChange={() => dispatch(resetAuthSignupErrors())}
					>
						<FormGroup
							label={"Имя"}
							id={"firstname"}
							{...(errors.firstname &&
								touched.firstname && {
									error: <ErrorMessage name="firstname" />,
								})}
							key="firstname"
						>
							<Field
								className="g-input"
								type="text"
								id="firstname"
								name="firstname"
								autoComplete="off"
							/>
						</FormGroup>
						<FormGroup
							label={"Фамилия"}
							id={"lastname"}
							{...(errors.lastname &&
								touched.lastname && {
									error: <ErrorMessage name="lastname" />,
								})}
							key="lastname"
						>
							<Field
								className="g-input"
								type="text"
								id="lastname"
								name="lastname"
								autoComplete="off"
							/>
						</FormGroup>
						<FormGroup
							label={"Электронное письмо"}
							id={"email"}
							{...(errors.email &&
								touched.email && {
									error: <ErrorMessage name="email" />,
								})}
							key="email"
						>
							<Field
								className="g-input"
								type="text"
								id="email"
								name="email"
								autoComplete="off"
							/>
						</FormGroup>
						<FormGroup
							label="Пароль"
							id="password"
							{...(errors.password &&
								touched.password && {
									error: <ErrorMessage name="password" />,
								})}
							key="password"
						>
							<Field type="password" name="password" autoComplete="off">
								{({ field: { value }, form: { setFieldValue } }) => (
									<PasswordInput
										ref={passwordInput}
										value={value}
										id="password"
										name="password"
										onChange={({ target }) =>
											setFieldValue("password", target.value)
										}
									/>
								)}
							</Field>
						</FormGroup>
						<FormGroup
							label="Подтвердите пароль"
							id="confirm-password"
							{...(errors.confirmPassword &&
								touched.confirmPassword && {
									error: <ErrorMessage name="confirmPassword" />,
								})}
							key="confirm-password"
						>
							<Field
								type="password"
								name="confirmPassword"
								id="confirm-password"
								autoComplete="off"
							>
								{({ field: { value }, form: { setFieldValue } }) => (
									<PasswordInput
										ref={confirmPasswordInput}
										value={value}
										id="confirm-password"
										name="confirm-password"
										onChange={({ target }) =>
											setFieldValue("confirmPassword", target.value)
										}
									/>
								)}
							</Field>
						</FormGroup>

						<div className="g-checkbox">
							<Field type="checkbox" name="acceptTerms" id="terms-conditions" />
							<label htmlFor={"terms-conditions"}>
								Я согласен с
								<Link href="/privacy-policy" passHref>
									<a className="ms-1 text-primary-blue hover-primary-blue">
										Правилами сайта
									</a>
								</Link>
							</label>
							{errors.acceptTerms && touched.acceptTerms && (
								<ErrorMessage
									name="acceptTerms"
									render={() => (
										<span className="g-error g-caption__md--medium text-secondary-error">
											{errors.acceptTerms}
										</span>
									)}
								/>
							)}
						</div>
						<Button
							variant="primary"
							className={classNames("g-btn--block my-md-24", {
								disabled: !isValid,
							})}
							type="submit"
							loader={{
								isLoading: isSubmitting,
								withContent: true,
								location: "center",
							}}
						>
							Sign up
						</Button>
						<div className="text-center">
							<a
								href=""
								className="g-caption__lg--medium text-ntr-dark-02 hover-primary-blue"
							>
								Забыли пароль?
							</a>
							<p className="g-caption__lg--medium mt-md-32 mb-sm">
								Уже зарегистрированы?
								<Link href="/home?login=true" shallow passHref>
									<a className="text-primary-blue hover-primary-blue-hover">
										Войти
									</a>
								</Link>
							</p>
						</div>
					</Form>
				)}
			</Formik>
		</>
	);
};

export default SignupForm;
