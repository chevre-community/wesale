import React from "react";

import Image from "next/image";
import Link from "next/link";

const Breadcrumb = ({ links }) => {
	return (
		<ol className="g-breadcrumb breadcrumb">
			{links.map(({ title, href }, index) => (
				<li key={index} className="g-breadcrumb-item breadcrumb-item">
					<Link href={href} passHref>
						{title}
					</Link>
				</li>
			))}
		</ol>
	);
};

export default Breadcrumb;
