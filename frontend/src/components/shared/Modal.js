import { useEffect, useState } from "react";
import { Modal as BsModal } from "react-bootstrap";
import { createPortal } from "react-dom";

import { useRouter } from "next/router";

import { DelayedPortal } from "@/components";

import classNames from "classnames";

const Modal = ({
	isShowing,
	children,
	title,
	size,
	justClose,
	isCloseable,
	closeableIsBoolean, // this prevents the close issue when pass the isCloseable as a boolean and not a function
}) => {
	const router = useRouter();

	const [classnames, setClassnames] = useState("");

	const onOpen = () => {
		setClassnames("animate__animated animate__fadeInDown animate__faster");
	};

	return isShowing
		? createPortal(
				<BsModal
					show={isShowing}
					onHide={() => {
						if (!justClose) {
							router.back() || router.push("/home");
						} else {
							justClose.toggle({
								value: false,
								modal: justClose.modal,
							});
						}
					}}
					size={size}
					aria-labelledby="contained-modal-title-vcenter"
					centered
					onEnter={onOpen}
					onExit={() => setClassnames("")}
					className={classNames("g-modal", classnames)}
				>
					<BsModal.Header
						{...(closeableIsBoolean
							? { closeButton: isCloseable }
							: { closeButton: true })}
						className="g-modal-header"
					>
						{title && (
							<BsModal.Title
								className="g-modal-title"
								id="contained-modal-title-vcenter"
								as="h5"
							>
								{title}
							</BsModal.Title>
						)}
					</BsModal.Header>
					<BsModal.Body className="g-modal-body">{children}</BsModal.Body>
				</BsModal>,
				document.body
		  )
		: null;
};

export default Modal;
