import { useModal } from "@/lib";

import React, { useEffect, useRef, useState } from "react";

import Link from "next/link";
import { useRouter } from "next/router";

import {
	AppleIcon,
	EyeCloseIcon,
	EyeOpenIcon,
	FacebookIcon2,
	FormGroup,
	GInput,
	GoogleIcon,
	Modal,
} from "@/components";

const LoginModal = () => {
	const router = useRouter();

	const [isPassword, setIsPassword] = useState(true);

	const passwordInput = useRef();

	const { isShowing, toggle } = useModal();

	useEffect(() => {
		toggle({
			value: router.query.login === "true",
			modal: "login",
		});
		// console.log(isShowing);
	}, [router.query.login, toggle]);

	const togglePasswordType = (e) => {
		e.preventDefault();
		setIsPassword(!isPassword);

		if (isPassword) {
			passwordInput.current.type = "password";
		} else {
			passwordInput.current.type = "text";
		}
	};

	return (
		<Modal
			isShowing={isShowing.login}
			hide={() =>
				toggle({
					value: false,
					modal: "login",
				})
			}
			size="md"
			title={"Войти"}
		>
			<div className="modal-form-wrapper">
				<div className="auth-providers">
					<button className="g-btn-auth-provider provider-google">
						<GoogleIcon />
					</button>
					{/* <button className="g-btn-auth-provider provider-facebook">
						<FacebookIcon2 />
					</button> */}
					<button className="g-btn-auth-provider provider-apple">
						<AppleIcon />
					</button>
				</div>
				<div className="text-center mb-md-24">
					<p className="g-caption__lg--medium text-ntr-dark-02">
						или войдите, используя
					</p>
				</div>
				<form action="" method="post">
					<FormGroup label="Ваша номер или email" id="email">
						<GInput id="email" placeholder="Text" />
					</FormGroup>
					<FormGroup label="Password" id="password">
						<div className="g-password-field">
							<input className="" type="password" ref={passwordInput} />
							<button className="password-toggle" onClick={togglePasswordType}>
								{!isPassword ? <EyeCloseIcon /> : <EyeOpenIcon />}
							</button>
						</div>
					</FormGroup>
					<button className="g-btn-primary g-btn--block my-md-24" type="submit">
						Войти
					</button>
					<div className="text-center">
						<a
							href=""
							className="g-caption__lg--medium text-ntr-dark-02 hover-primary-blue"
						>
							Забыли пароль?
						</a>
						<p className="g-caption__lg--medium mt-md-32 mb-sm">
							У вас нет аккаунта?
							<Link href="?signup=true" passHref>
								<a className="text-primary-blue hover-primary-blue-hover">
									Зарегистрироваться
								</a>
							</Link>
						</p>
					</div>
				</form>
			</div>
		</Modal>
	);
};

export default LoginModal;
