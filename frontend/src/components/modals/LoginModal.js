import { useModal } from "@/lib";

import React, { useEffect } from "react";

import { useRouter } from "next/router";

import { Modal, LoginForm, AppleIcon, GoogleIcon } from "@/components";


const LoginModal = () => {
	const router = useRouter();

	const { isShowing, toggle } = useModal();

	useEffect(() => {
		toggle({
			value: router.query.login === "true",
			modal: "login",
		});
	}, [router.query.login, toggle]);

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
					<button className="g-btn-auth-provider provider-apple">
						<AppleIcon />
					</button>
				</div>
				<div className="text-center mb-md-24">
					<p className="g-caption__lg--medium text-ntr-dark-02">
						или войдите, используя
					</p>
				</div>
				<LoginForm />
			</div>
		</Modal>
	);
};

export default LoginModal;
