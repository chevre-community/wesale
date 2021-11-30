import { useModal } from "@/lib";

import React from "react";

import { Modal } from "@/components";

const BasicInfoModal = ({ justClose, modal }) => {
	const { isShowing, toggle } = useModal();

	return (
		<Modal
			isShowing={isShowing[modal]}
			hide={() =>
				toggle({
					value: false,
					modal,
				})
			}
			size="md"
			justClose={
				justClose && {
					toggle: (payload) => toggle(payload),
					modal,
				}
			}
		>
			<h4 className="text-center g-text__lg--semibold">
				Ваша жалоба была отправлена
			</h4>
		</Modal>
	);
};

export default BasicInfoModal;
