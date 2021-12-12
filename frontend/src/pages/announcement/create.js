import React from "react";

import { Swiper, SwiperSlide } from "swiper/react";

import { DocumentIcon, LocationIcon } from "@/components";

const CreateAnnouncement = () => {
	return (
		<>
			<div className="caption__cards">
				<Swiper slidesPerView={3} spaceBetween={20}>
					<SwiperSlide>
						<div className="caption__card">
							<p className="caption__card--title">Поиск арендаторов</p>
							<p className="caption__card--text">
								Разместим объявление, проверим жильцов и поможем подписать
								договор.
							</p>
						</div>
					</SwiperSlide>
					<SwiperSlide>
						<div className="caption__card caption--major">
							<p className="caption__card--title">Безопасность и свобода</p>
							<p className="caption__card--text">
								Разместим объявление, проверим жильцов и поможем подписать
								договор.
							</p>
						</div>
					</SwiperSlide>
					<SwiperSlide>
						<div className="caption__card">
							<p className="caption__card--title">Показ онлайн</p>
							<p className="caption__card--text">
								Разместим объявление, проверим жильцов и поможем подписать
								договор.
							</p>
						</div>
					</SwiperSlide>
				</Swiper>
			</div>
			<div className="announcement__create--container">
				<h3 className="announcement__create--title g-title__lg--bold">
					Мое объявление
				</h3>
				<div className="announcement__create">
					<div className="announcement__create--section">
						<div className="announcement__create--grid">
							<div className="announcement__create--grid-item">1</div>
							<div className="announcement__create--grid-item">
								<div className="guide__card">
									<div className="guide__card--icon">
										<DocumentIcon stroke />
									</div>
									<p className="guide__card--title">
										Опишите свою недвижимость
									</p>
									<ul className="guide__card--list">
										<li>
											Помогите пользовотелям побольше узнать о вашей
											недвижимости.
										</li>
										<li>
											Помогите пользовотелям побольше узнать о вашей
											недвижимости.
										</li>
									</ul>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</>
	);
};

export default CreateAnnouncement;
