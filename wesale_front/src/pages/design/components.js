import React, { useEffect, useState } from "react";
import { Col, Row } from "react-bootstrap";

import {
	ContractIcon,
	FilterFormWrapper,
	InfoCard,
	MainLayout,
	PercentageIcon,
	ProductCard,
	ProfileIcon,
	UploadedImage,
} from "@/components";

import { useMain } from "@/context/providers/main-context";

const Components = () => {
	const [showPhone, setShowPhone] = useState(false);
	const { mainState } = useMain();

	return (
		<>
			<div className="design-section">
				<Row>
					<Col md={4} lg={3}>
						<ProductCard
							images={mainState.images}
							rooms={3}
							price={1200}
							area={150}
						/>
					</Col>
					<Col md={4} lg={3}>
						<ProductCard
							images={mainState.images}
							rooms={2}
							price={1550}
							area={90}
						/>
					</Col>
					<Col md={4} lg={3}>
						<ProductCard
							images={mainState.images}
							rooms={4}
							price={2500}
							area={210}
						/>
					</Col>
					<Col md={4} lg={3}>
						<ProductCard
							images={mainState.images}
							rooms={1}
							price={1700}
							area={225}
						/>
					</Col>
				</Row>
			</div>
			<div className="design-section">
				<Row>
					<Col md={4} lg={3}>
						<InfoCard
							showPhone={showPhone}
							setShowPhone={setShowPhone}
							currency={"$"}
							mortgage_price={1500}
							price={200000}
							phone_numbers={["+994 50 599 12 67", "+994 70 478 65 85"]}
							wp_phone={"+994 50 599 12 67"}
						/>
					</Col>
				</Row>
			</div>
			<div className="design-section">
				<Row>
					<Col md={6}>
						<div className="uploaded-images">
							<UploadedImage
								image={"/static/svgs/uploaded/uploaded-3.svg"}
								alt={"WeSale"}
								isMain={false}
							/>
							<UploadedImage
								image={"/static/svgs/uploaded/uploaded-1.svg"}
								alt={"WeSale"}
								isMain={false}
							/>
							<UploadedImage
								image={"/static/svgs/uploaded/uploaded-4.svg"}
								alt={"WeSale"}
								isMain={true}
							/>
							<UploadedImage
								image={"/static/svgs/uploaded/uploaded-1.svg"}
								alt={"WeSale"}
								isMain={false}
							/>
						</div>
					</Col>
				</Row>
			</div>
		</>
	);
};

export default Components;
