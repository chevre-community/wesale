import { useModal } from "@/lib";

import React from "react";

import { Modal } from "@/components";

const AdvancedFilterModal = ({ justClose, modal }) => {
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
			title="Расширенный фильтр"
			justClose={
				justClose && {
					toggle: (payload) => toggle(payload),
					modal,
				}
			}
		>
			<h4>Hello</h4>
		</Modal>
	);
};

export default AdvancedFilterModal;
