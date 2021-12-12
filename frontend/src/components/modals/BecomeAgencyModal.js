import { useModal } from "@/lib";

import React from "react";

import { Button, CustomImage, Modal } from "@/components";

const BecomeAgencyModal = ({ justClose, modal }) => {
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
			<div className="become-agency-modal">
				<div className="become-agency-modal__img">
					<CustomImage
						src="/static/svgs/become-agency-modal-illustration.svg"
						width={800}
						height={720}
						alt="Become agency | WeSale"
					/>
				</div>
				<div className="text-center">
					<p className="g-text__lg--semibold mb-2">Хотите стать Агенстом?</p>
					<p className="g-caption__lg--regular text-secondary-grey mb-md-24">
						Вы сможете найти его в своем профиле. Заинтересованные специалисты
						будут откликаться на ваше задание.
					</p>
					<Button
						variant="secondary"
						onClick={() => {
							toggle({
								value: false,
								modal,
							});

							toggle({
								value: true,
								modal: "becomeAgencyChoice",
							});
						}}
					>
						Продолжить
					</Button>
				</div>
			</div>
		</Modal>
	);
};

export default BecomeAgencyModal;
