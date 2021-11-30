import { useModal } from "@/lib";

import React from "react";

import { FormGroup, GInput, Modal } from "@/components";

const ChangeEmailModal = ({ justClose, modal }) => {
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
			title={"Сменить почту"}
			justClose={
				justClose && {
					toggle: (payload) => toggle(payload),
					modal,
				}
			}
		>
			<div className="modal-form-wrapper">
				<p className="g-caption__lg--regular text-secondary-grey mb-md-24">
					Мы отправим на вашу почту что то там а вам надо будет подтведить
				</p>
				<form action="" method="post">
					<FormGroup label={"Новая электронная почта"}>
						<GInput type="email" />
					</FormGroup>
					<button
						className="g-btn-secondary g-btn--block mt-sm mb-md"
						onClick={(e) => {
							e.preventDefault();
							toggle({
								value: false,
								modal,
							});

							toggle({
								value: true,
								modal: "basicInfo",
							});
						}}
					>
						Сменить почту
					</button>
				</form>
			</div>
		</Modal>
	);
};

export default ChangeEmailModal;
