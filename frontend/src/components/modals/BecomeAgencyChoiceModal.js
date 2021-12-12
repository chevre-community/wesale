import { useModal } from "@/lib";

import React from "react";

import { Button, ChevronLeft, InputRadio, Modal } from "@/components";

const BecomeAgencyChoiceModal = ({ justClose, modal }) => {
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
			title="Это  очень важно!"
			justClose={
				justClose && {
					toggle: (payload) => toggle(payload),
					modal,
				}
			}
		>
			<button
				className="g-btn-text prev-btn-modal"
				onClick={() => {
					toggle({
						value: false,
						modal,
					});

					toggle({
						value: true,
						modal: "becomeAgency",
					});
				}}
			>
				<ChevronLeft />
			</button>
			<p className="g-text__sm--regular text-center">
				Вы хотите перенести существующие объявления в профиль Агенства? После
				завершения вы не сможете отменить действие.
			</p>
			<form action="" method="post">
				<ul className="list-with-gap mt-md-24">
					<li>
						<InputRadio
							id={"radio-2"}
							label={"Перенести все объявления в профиль Агенства"}
							name={"radio"}
							checked
						/>
					</li>
					<li>
						<InputRadio
							id={"radio-1"}
							label={
								"Оставить все объявления под именем собственника, то есть вашим именем"
							}
							name={"radio"}
						/>
					</li>
				</ul>
				<Button variant="primary" className="g-btn--block mt-md" type="submit">
					Стать агенством
				</Button>
			</form>
		</Modal>
	);
};

export default BecomeAgencyChoiceModal;
