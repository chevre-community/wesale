import React from "react";

import { Breadcrumb } from "@/components";

const PrivacyPolicy = () => {
	return (
		<div className="page-wrapper">
			<Breadcrumb
				links={[
					{
						title: "Главная",
						href: "/home",
					},
					{
						title: "Политика конфидециальности",
						href: "/privacy-policy",
					},
				]}
			/>
			<div className="privacy-policy">
				<h1 className="g-title__lg--bold my-md">Пользовательскте условия</h1>
				<p className="text-primary-grey">
					Interpretation of Showaround host
					<br />
					<br />
					On Showaround, a ‘host’ is a broad definition of a person who resides
					in a certain location and wishes to share his personal local
					experience with travellers he meets on Showaround so that they could
					become acquainted with the area from the perspective of a local.
					Showaround local hosts must meet all legal requirements to give tours
					in their area. In some cases, and in some locations, this means that a
					specific license has to be obtained from an appropriate authority.
					However if a Showaround host is simply accompanying travellers, offers
					practical advice or shares his experience about ‘best bars and
					restaurants’, ‘non-touristic spots’, ‘shopping areas’ etc. he may just
					be a passionate local person without any formal training in tour
					organising. Services Description of the Services
					<br />
					<br />
					Compassfriends Limited makes available an online platform for the
					Locals and Visitors to meet online and arrange for the Show-around
					directly with each other. By using the Site or Application, the Locals
					may create profiles (the “Profiles”) that provide information about
					their knowledge of and experience with a specific travel destination,
					and may make themselves available to offer the Show-around to the
					Visitors. Based on the Profiles, the Visitors may select the Locals to
					provide the Show-around. Visitors can purchase a Membership allowing
					them to book and contact Locals; however, it does not guarantee the
					occurrence of tours and therefore, all agreements made about city
					tours as well as payments are solely up to the visitor and local to
					decide and discuss among themselves. Membership Fee is payable to
					Compassfriends Limited. Membership can be purchased for the duration
					of one month, three months or one year and it is a recurring
					subscription-based payment.
					<br />
					<br />
					Role and responsibilities of Compassfriends Limited Compassfriends
					Limited is not a tour operator nor it is a travel agent.
					Compassfriends Limited does not provide the Show-around or any other
					travel or similar services. Its role and responsibilities are strictly
					limited to (i) facilitating the connections between the Locals and
					Visitors in arranging for the Show-around and (ii) processing payment
					transactions between the Locals and Visitors, when the latters book
					the Show-around.
					<br />
					<br />
					With reference to above, you understand and agree that Compassfriends
					Limited is not a party to any agreement between the Local and Visitor
					in relation to the Show-around. Intellectual Property All Intellectual
					Property to the Content (except for the User Content) featured or
					displayed on the Site or Application or via the Services, is the
					property of Compassfriends Limited and is protected by copyright laws,
					patent and trademark laws and other legislation. You will not remove,
					alter or obscure any copyright, trademark, service mark or other
					proprietary rights notices incorporated in or accompanying the Site,
					Application or Services. Subject to your compliance with these Terms,
					Compassfriends Limited grants you a limited, non-exclusive,
					non-sublicensable, revocable, non-transferrable license to (i) access
					and use the Site and Application solely in connection with your use of
					the Services, and (ii) access and use any content, information and
					related materials that may be made available through the Services.
					Network Access You are responsible for obtaining the data network
					access necessary to use the Services. You understand that such access
					may involve third-party fees (such as Internet service provider).
				</p>
			</div>
		</div>
	);
};

export default PrivacyPolicy;
