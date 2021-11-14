import { rem } from "@/lib";

import React from "react";

import Image from "next/image";

const CustomImage = ({
	container_width,
	container_height,
	src,
	width,
	height,
	alt,
	...rest
}) => {
	const parentStyles = {
		width: rem(container_width),
		height: rem(container_height),
	};

	return container_width && container_height ? (
		<div
			className="position-relative"
			style={{
				...parentStyles,
			}}
		>
			<Image src={src} alt={alt} {...rest} />
		</div>
	) : (
		<div className="w-auto h-auto position-relative">
			<Image src={src} width={width} height={height} alt={alt} {...rest} />
		</div>
	);
};

export default CustomImage;
