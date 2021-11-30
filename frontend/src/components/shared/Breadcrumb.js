import Breadcrumbs from "nextjs-breadcrumbs";

import React from "react";

import Link from "next/link";

const Breadcrumb = ({ links }) => {
	return (
		<Breadcrumbs
			rootLabel="Home"
			listClassName="g-breadcrumb breadcrumb"
			inactiveItemClassName="g-breadcrumb-item breadcrumb-item"
			activeItemClassName="g-breadcrumb-item breadcrumb-item"
		/>
		// <ol className="g-breadcrumb breadcrumb">
		// 	{links.map(({ title, href }, index) => (
		// 		<li key={index} className="g-breadcrumb-item breadcrumb-item">
		// 			<Link href={href} passHref>
		// 				{title}
		// 			</Link>
		// 		</li>
		// 	))}
		// </ol>
	);
};

export default Breadcrumb;
