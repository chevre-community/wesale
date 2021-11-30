/* eslint-disable @next/next/no-img-element */
import React from "react";
import { Accordion } from "react-bootstrap";

import Link from "next/link";

import { FacebookIcon, InstagramIcon } from "@/components";

const ContactPage = () => {
	return (
		<div className="contact-container">
			<h1 className="g-title__lg--bold">
				WeSale - <br />
				Здесь Вы найдете недвижимость по своему вкусу
			</h1>
			<div className="contact-grid">
				<div className="contact-grid__wesale-info">
					<p className="g-text__lg--semibold mb-sm">WeSale</p>
					<p className="g-text__md--regular">
						Задача организации, в особенности же сложившаяся структура
						организации требуют от нас анализа направлений прогрессивного
						развития. Таким образом новая модель организационной деятельности
						играет важную роль в формировании существенных финансовых и
						административных условий. Разнообразный и богатый опыт сложившаяся
						структура организации играет важную роль в формировании существенных
						финансовых и административных условий. С другой стороны постоянный
						количественный рост и сфера нашей активности обеспечивает широкому
						кругу (специалистов) участие в формировании направлений
						прогрессивного развития.
						<br />
						<br />
						Равным образом реализация намеченных плановых заданий в значительной
						степени обуславливает создание соответствующий условий активизации.
						Товарищи!
					</p>
				</div>
				<div className="contact-grid__info">
					<div className="contact-grid__info--img">
						<img src="/static/svgs/contact-illustration.svg" alt="WeSale" />
					</div>
					<div className="contact-grid__info--body">
						<p className="g-text__lg--semibold text-primary-grey">
							Наши контакты
						</p>
						<div className="my-sm">
							<div className="g-text__sm--regular text-primary-grey">
								<p>Элеткронная почта:</p>
								<p>info@advance.az</p>
							</div>
							<br />
							<div className="g-text__sm--regular text-primary-grey">
								<p>Контактный номер поддержки:</p>
								<p>+994 50 500 50 50</p>
							</div>
						</div>
						<div className="d-flex align-items-center gap-3">
							<Link href="/home">
								<a className="bg-white g-footer__links--social">
									<InstagramIcon />
								</a>
							</Link>
							<Link href="/home">
								<a className="bg-white g-footer__links--social m-0">
									<FacebookIcon />
								</a>
							</Link>
						</div>
					</div>
				</div>
			</div>
			<div className="accordion-wrapper">
				<p className="text-center g-title__sm--bold">
					Часто задаваемые вопросы
				</p>
				<Accordion className="faq-accordion" flush>
					<Accordion.Item eventKey="0">
						<Accordion.Header>
							Как новичку выдержать конкуренцию?
						</Accordion.Header>
						<Accordion.Body>
							Начинайте с простых заказов и оставляйте как можно больше
							предложений. Когда появятся первые положительные отзывы, получать
							задания станет проще.
						</Accordion.Body>
					</Accordion.Item>
					<Accordion.Item eventKey="1">
						<Accordion.Header>Где гарантии, что это не обман?</Accordion.Header>
						<Accordion.Body>
							Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
							eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut
							enim ad minim veniam, quis nostrud exercitation ullamco laboris
							nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in
							reprehenderit in voluptate velit esse cillum dolore eu fugiat
							nulla pariatur. Excepteur sint occaecat cupidatat non proident,
							sunt in culpa qui officia deserunt mollit anim id est laborum.
						</Accordion.Body>
					</Accordion.Item>
					<Accordion.Item eventKey="2">
						<Accordion.Header>Где гарантии, что это не обман?</Accordion.Header>
						<Accordion.Body>
							Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
							eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut
							enim ad minim veniam, quis nostrud exercitation ullamco laboris
							nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in
							reprehenderit in voluptate velit esse cillum dolore eu fugiat
							nulla pariatur. Excepteur sint occaecat cupidatat non proident,
							sunt in culpa qui officia deserunt mollit anim id est laborum.
						</Accordion.Body>
					</Accordion.Item>
					<Accordion.Item eventKey="3">
						<Accordion.Header>Где гарантии, что это не обман?</Accordion.Header>
						<Accordion.Body>
							Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
							eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut
							enim ad minim veniam, quis nostrud exercitation ullamco laboris
							nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in
							reprehenderit in voluptate velit esse cillum dolore eu fugiat
							nulla pariatur. Excepteur sint occaecat cupidatat non proident,
							sunt in culpa qui officia deserunt mollit anim id est laborum.
						</Accordion.Body>
					</Accordion.Item>
					<Accordion.Item eventKey="4">
						<Accordion.Header>Где гарантии, что это не обман?</Accordion.Header>
						<Accordion.Body>
							Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
							eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut
							enim ad minim veniam, quis nostrud exercitation ullamco laboris
							nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in
							reprehenderit in voluptate velit esse cillum dolore eu fugiat
							nulla pariatur. Excepteur sint occaecat cupidatat non proident,
							sunt in culpa qui officia deserunt mollit anim id est laborum.
						</Accordion.Body>
					</Accordion.Item>
				</Accordion>
			</div>
		</div>
	);
};

export default ContactPage;
