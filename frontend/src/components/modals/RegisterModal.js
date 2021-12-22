import { useModal } from "@/lib";

import React, { useEffect, useRef, useState } from "react";

import { useRouter } from "next/router";

import { Modal, GoogleIcon, AppleIcon, SignupForm } from "@/components";

const RegisterModal = () => {
	const router = useRouter();

	const { isShowing, toggle } = useModal();

	useEffect(() => {
		toggle({
			value: router.query.signup === "true",
			modal: "signup",
		});
		// console.log(isShowing);
	}, [router.query.signup, toggle]);

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
			title={"Быстрая регистрация через:"}
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
				<SignupForm />
			</div>
		</Modal>
	);
};

export default RegisterModal;
