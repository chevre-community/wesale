import React from "react";

import Link from "next/link";

import { CustomImage } from "@/components";

const NotFound = () => {
	return (
		<div className="_404-page">
			<div className="_404-page-wrapper">
				<div className="_404-page-img">
					<CustomImage
						src={"/static/svgs/404.svg"}
						container_width={430}
						container_height={340}
						alt="WESALE 404"
						layout="fill"
						priority
					/>
				</div>
				<h2 className="_404-page-title">Ой! Страница не найдена</h2>
				<h4 className="_404-page-subtitle">
					Кажется, мы не можем найти страницу, которую вы ищете
				</h4>
				<Link href="/" passHref>
					<a className="_404-page-btn g-btn-secondary">Вернуться на главную</a>
				</Link>
			</div>
		</div>
	);
};

export default NotFound;
