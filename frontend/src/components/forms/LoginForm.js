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

import classNames from "classnames";

import PasswordInput from "../shared/form/PasswordInput";

const LoginForm = ({}) => {
	const passwordInput = useRef();
	const dispatch = useDispatch();
	const { errors } = useSelector(authSelectors);
	const authLoginErrors = errors.login;
	const router = useRouter();
	const [login, {}] = useAuthLoginMutation();

	return (
		<>
			<Formik
				initialValues={{
					email: "",
					password: "",
				}}
				validate={(values) => {
					const errors = {};

					validateLoginFields({
						...values,
						errors,
						authErrors: authLoginErrors,
					});

					return errors;
				}}
				onSubmit={async (values, { validateForm }) => {
					try {
						const token = await login({ ...values }).unwrap();

						dispatch(setCredentials(token));

						router.push("/dashboard");
					} catch (err) {
						validateForm({
							...values,
						});
					}
				}}
			>
				{({ errors, isSubmitting, isValid }) => (
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
								id="email"
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
										id="password"
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
