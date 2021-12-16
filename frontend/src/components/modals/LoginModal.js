import { useModal } from "@/lib";

import React, { useEffect } from "react";

import { useRouter } from "next/router";

import { Modal } from "@/components";

import LoginForm from "../forms/LoginForm";

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
				<LoginForm />
			</div>
		</Modal>
	);
};

export default LoginModal;
