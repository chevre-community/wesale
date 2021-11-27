import React, { useEffect, useState } from "react";

import Link from "next/link";
import { useRouter } from "next/router";

import {
	ArrowRightIcon,
	CustomImage,
	FacebookIcon,
	InstagramIcon,
} from "@/components";

import classNames from "classnames";

const Footer = () => {
	const router = useRouter();
	const [isMapPage, setIsMapPage] = useState(false);

	useEffect(() => {
		if (!router.pathname.startsWith("/search/map")) {
			setIsMapPage(false);
		} else {
			setIsMapPage(true);
		}
	}, [router.pathname]);

	return (
		<footer
			className={classNames("g-footer", {
				"mt-0": isMapPage,
			})}
		>
			<div className="g-container">
				<div className="g-footer__grid">
					<div className="g-footer__grid--side">
						<div className="g-footer__brand">
							<Link href="/home" passHref>
								<a>
									<CustomImage
										width={90}
										height={20}
										priority
										src="/static/svgs/WeSale.svg"
										alt="WeSale"
									/>
								</a>
							</Link>
						</div>
						<p className="g-text__xs--medium text-secondary-grey mt-sm">
							Удобный и выгодный сервис услуг.
						</p>
						<p className="g-text__xs--medium text-secondary-grey mt-sm">
							WeSale Copyright 2021. All Right Reserved WeSale
						</p>
					</div>
					<div className="g-footer__grid--center">
						<ul className="g-footer__links">
							<li className="g-footer__links--item">
								<a className="g-link" href="">
									Sale
								</a>
							</li>
							<li className="g-footer__links--item">
								<a className="g-link" href="">
									Rent
								</a>
							</li>
							<li className="g-footer__links--item">
								<Link href="/agencies" passHref>
									<a className="g-link">Agencies</a>
								</Link>
							</li>
						</ul>
						<ul className="g-footer__links">
							<li className="g-footer__links--item">
								<a className="g-link" href="">
									About us
								</a>
							</li>
							<li className="g-footer__links--item">
								<Link href="/contact" passHref>
									<a className="g-link">Contact</a>
								</Link>
							</li>
							<li className="g-footer__links--item">
								<Link href="/privacy-policy" passHref>
									<a className="g-link">Terms of use</a>
								</Link>
							</li>
							<li className="g-footer__links--item">
								<div className="d-flex">
									<a
										className="g-footer__links--social"
										href=""
										target="_blank"
										rel="noopener noreferrer"
									>
										<InstagramIcon />
									</a>
									<a
										className="g-footer__links--social"
										href=""
										target="_blank"
										rel="noopener noreferrer"
									>
										<FacebookIcon />
									</a>
								</div>
							</li>
						</ul>
					</div>
					<div className="g-footer__grid--side">
						<p className="g-text__sm--medium">
							Подпишитесь что бы первым получать горячие предложения!
						</p>
						<form action="" className="g-footer__search-form">
							<div className="g-footer__search">
								<input type="text" placeholder="Ваша электронная почта" />
								<button type="submit">
									<ArrowRightIcon />
								</button>
							</div>
						</form>
					</div>
				</div>
			</div>
		</footer>
	);
};

export default Footer;
