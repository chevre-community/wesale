import {
	authSelectors,
	resetAuthLoginErrors,
	setCredentials,
} from "@/app/features/auth/authSlice";
import { useAuthLoginMutation } from "@/app/services/authService";
import { validateLoginFields } from "@/lib";
import { ErrorMessage, Field, Form, Formik } from "formik";

import React, { useRef } from "react";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";

import Link from "next/link";
import { useRouter } from "next/router";

import { AppleIcon, Button, FormGroup, GoogleIcon } from "@/components";

import PasswordInput from "../shared/form/PasswordInput";

const LoginForm = ({}) => {
	const passwordInput = useRef();
	const dispatch = useDispatch();
	const { errors: authLoginErrors } = useSelector(authSelectors);
	const router = useRouter();
	const [login, {}] = useAuthLoginMutation();

	return (
		<>
			<div className="auth-providers">
				<button className="g-btn-auth-provider provider-google">
					<GoogleIcon />
				</button>
				<button className="g-btn-auth-provider provider-apple">
					<AppleIcon />
				</button>
			</div>
			<div className="text-center mb-md-24">
				<p className="g-caption__lg--medium text-ntr-dark-02">
					или войдите, используя
				</p>
			</div>
			<Formik
				initialValues={{
					email: "",
					password: "",
				}}
				validate={({ email, password }) => {
					const errors = {};

					validateLoginFields(email, password, errors, authLoginErrors);

					return errors;
				}}
				onSubmit={async ({ email, password }, { validateForm }) => {
					try {
						const token = await login({ email, password }).unwrap();

						dispatch(setCredentials(token));

						router.push("/dashboard");
					} catch (err) {
						validateForm({
							email,
							password,
						});
					}
				}}
			>
				{({ errors, isSubmitting }) => (
					<Form
						name="login"
						autoComplete="off"
						onChange={() => dispatch(resetAuthLoginErrors())}
					>
						<FormGroup
							label="Ваша номер или email"
							id="email"
							{...(errors.email && {
								error: <ErrorMessage name="email" />,
							})}
							key="email"
						>
							<Field
								className="g-input"
								type="text"
								name="email"
								autoComplete="off"
							/>
						</FormGroup>
						<FormGroup
							label="Password"
							id="password"
							{...(errors.password && {
								error: <ErrorMessage name="password" />,
							})}
							key="password"
						>
							<Field type="password" name="password" autoComplete="off">
								{({ field: { value }, form: { setFieldValue } }) => (
									<PasswordInput
										ref={passwordInput}
										value={value}
										name="password"
										onChange={({ target }) =>
											setFieldValue("password", target.value)
										}
									/>
								)}
							</Field>
						</FormGroup>
						<Button
							variant="primary"
							className="g-btn--block my-md-24"
							type="submit"
							loader={{
								isLoading: isSubmitting,
								withContent: true,
								location: "center",
							}}
						>
							Войти
						</Button>
						<div className="text-center">
							<a
								href=""
								className="g-caption__lg--medium text-ntr-dark-02 hover-primary-blue"
							>
								Забыли пароль?
							</a>
							<p className="g-caption__lg--medium mt-md-32 mb-sm">
								У вас нет аккаунта?
								<Link href="/home?signup=true" passHref>
									<a className="text-primary-blue hover-primary-blue-hover">
										Зарегистрироваться
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

export default LoginForm;
