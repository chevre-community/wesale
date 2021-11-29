import { useModal } from "@/lib";

import React, { useEffect, useRef, useState } from "react";

import Link from "next/link";
import { useRouter } from "next/router";

import {
	AppleIcon,
	Checkbox,
	FacebookIcon2,
	FormGroup,
	GInput,
	GoogleIcon,
	Modal,
} from "@/components";

const RegisterModal = () => {
	const router = useRouter();

	const [isPassword, setIsPassword] = useState(true);

	const passwordInput = useRef();

	const { isShowing, toggle } = useModal();

	useEffect(() => {
		toggle({
			value: router.query.signup === "true",
			modal: "signup",
		});
		// console.log(isShowing);
	}, [router.query.signup, toggle]);

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
			isShowing={isShowing.signup}
			hide={() =>
				toggle({
					value: router.query.signup === "true",
					modal: "signup",
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
					<FormGroup label="Мобильный номер" id="email">
						<GInput id="email" placeholder="Text" />
					</FormGroup>
					<div className="g-checkbox">
						<input type="checkbox" id={"checkbox-1"} name={"checkbox"} />
						<label htmlFor={"checkbox-1"}>
							Я согласен с
							<Link href="/privacy-policy" passHref>
								<a className="ms-1 text-primary-blue hover-primary-blue">
									Правилами сайта
								</a>
							</Link>
						</label>
					</div>
					<button className="g-btn-primary g-btn--block my-md-24" type="submit">
						Отправить SMS с кодом
					</button>
					<div className="text-center">
						<a
							href=""
							className="g-caption__lg--medium text-ntr-dark-02 hover-primary-blue"
						>
							Забыли пароль?
						</a>
						<p className="g-caption__lg--medium mt-md-32 mb-sm">
							Уже зарегистрированы?
							<Link href="?login=true" passHref>
								<a className="text-primary-blue hover-primary-blue-hover">
									Войти
								</a>
							</Link>
						</p>
					</div>
				</form>
			</div>
		</Modal>
	);
};

export default RegisterModal;
