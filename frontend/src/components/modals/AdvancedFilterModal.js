import { useModal } from "@/lib";
import { A11y, EffectFade } from "swiper";
import { Swiper, SwiperSlide } from "swiper/react";

import React, { useCallback } from "react";

import { ChevronLeft, FormGroup, GSelect, Modal, SearchIcon } from "@/components";

import { htmlToProps } from "@/lib";
import { BsSearch } from "react-icons/bs";
import { FaSearch, FaTimes } from "react-icons/fa";
import { FiSearch } from "react-icons/fi";

const AdvancedFilterModal = ({ justClose, modal }) => {
	const { isShowing, toggle } = useModal();
	const [filterFormSwiper, setFilterFormSwiper] = React.useState(null);
	const [activeIndex, setActiveIndex] = React.useState(0);

	const tabsSwiperParams = {
		modules: [A11y],
		slidesPerView: "auto",
		spaceBetween: 16,
		direction: "horizontal",
	};

	const changeActiveIndex = useCallback(
		(swiper) => {
			setActiveIndex(swiper.activeIndex);
		},
		[activeIndex, isShowing]
	);

	const handleSlideTo = (swiper, index) => swiper.slideTo(index);

	return (
		<Modal
			isShowing={isShowing[modal]}
			hide={() =>
				toggle({
					value: false,
					modal,
				})
			}
			size="lg"
			title="Расширенный фильтр"
			justClose={
				justClose && {
					toggle: (payload) => toggle(payload),
					modal,
				}
			}
			isCloseable={activeIndex === 0}
			closeableIsBoolean={true}
		>
			{activeIndex !== 0 && (
				<button
					className="g-btn-text prev-btn-modal"
					onClick={() => {
						handleSlideTo(filterFormSwiper, 0);
					}}
				>
					<ChevronLeft />
				</button>
			)}
			<div className="filter-modal-wrapper">
				<div className="filter-modal-tabs">
					<p className="g-caption__lg--regular text-ntr-dark-01">
						Расположение
					</p>
					<div className="filter-modal-tabs-content">
						<div className="g-tabs">
							<Swiper {...tabsSwiperParams}>
								<SwiperSlide>
									<button
										className={`g-tabs__item ${filterFormSwiper?.activeIndex === 1 ? "active" : ""
											}`}
										onClick={() => handleSlideTo(filterFormSwiper, 1)}
									>
										Районы
									</button>
								</SwiperSlide>
								<SwiperSlide>
									<button
										className={`g-tabs__item ${filterFormSwiper?.activeIndex === 2 ? "active" : ""
											}`}
										onClick={() => handleSlideTo(filterFormSwiper, 2)}
									>
										Станции метро
									</button>
								</SwiperSlide>
								<SwiperSlide>
									<button
										className={`g-tabs__item ${filterFormSwiper?.activeIndex === 3 ? "active" : ""
											}`}
										onClick={() => handleSlideTo(filterFormSwiper, 3)}
									>
										Ориентиры
									</button>
								</SwiperSlide>
							</Swiper>
						</div>
					</div>
				</div>
				<div className="filter-modal-content">
					<form method="POST">
						<Swiper
							direction="horizontal"
							allowTouchMove={false}
							onSwiper={setFilterFormSwiper}
							onSlideChange={changeActiveIndex}
							effect="fade"
							fadeEffect={{ crossFade: true }}
							speed={500}
							modules={[EffectFade]}
							autoHeight={true}
						>
							<SwiperSlide>
								<div className="filter-modal-content__common">
									<div className="filter-form-modal__grid">
										<div className="filter-form-modal__grid--item">
											<FormGroup label={htmlToProps(<>Площадь (м<sup>2</sup>)</>)}>
												<div className="range-value-inputs">
													<div className="range-value-inputs__item">
														<input placeholder="от" type="text" name="" id="" />
													</div>
													<div className="range-value-inputs__item">
														<input placeholder="до" type="text" name="" id="" />
													</div>
												</div>
											</FormGroup>
										</div>
										<div className="filter-form-modal__grid--item">
											<FormGroup label={htmlToProps(<>Жилая площадь (м<sup>2</sup>)</>)}>
												<div className="range-value-inputs">
													<div className="range-value-inputs__item">
														<input placeholder="от" type="text" name="" id="" />
													</div>
													<div className="range-value-inputs__item">
														<input placeholder="до" type="text" name="" id="" />
													</div>
												</div>
											</FormGroup>
										</div>
										<div className="filter-form-modal__grid--item">
											<FormGroup label={"Год постройки"}>
												<div className="range-value-inputs">
													<div className="range-value-inputs__item">
														<input placeholder="от" type="text" name="" id="" />
														<label htmlFor="">г.</label>
													</div>
													<div className="range-value-inputs__item">
														<input placeholder="до" type="text" name="" id="" />
														<label htmlFor="">г.</label>
													</div>
												</div>
											</FormGroup>
										</div>
										<div className="filter-form-modal__grid--item">
											<FormGroup label={"Этаж"}>
												<div className="range-value-inputs">
													<div className="range-value-inputs__item">
														<input placeholder="от" type="text" name="" id="" />
													</div>
													<div className="range-value-inputs__item">
														<input placeholder="до" type="text" name="" id="" />
													</div>
												</div>
											</FormGroup>
										</div>
										<div className="filter-form-modal__grid--item">
											<FormGroup label={"Ремонт дома:"}>
												<GSelect
													instanceId="select-1"
													options={[
														{
															label: "Новый",
															value: "new",
														},
														{
															label: "Без отделки",
															value: "no-decoration",
														},
														{
															label: "С отделкой",
															value: "decoration",
														},
														{
															label: "С перепланировкой",
															value: "replan",
														}
													]}
												/>
											</FormGroup>
										</div>
										<div className="filter-form-modal__grid--item">
											<FormGroup label={"Материал дома:"}>
												<GSelect
													instanceId="select-2"
													options={[
														{
															label: "Кирпич",
															value: "brick",
														},
														{
															label: "Брус",
															value: "timber",
														},
														{
															label: "Кирпич и брус",
															value: "brick-timber",
														},
														{
															label: "Дерево",
															value: "wood",
														},
														{
															label: "Дерево и кирпич",
															value: "wood-brick",
														}
													]}
												/>
											</FormGroup>
										</div>
									</div>
								</div>
							</SwiperSlide>
							<SwiperSlide>
								<div className="search-box">
									<input type="text" id="search-districts" placeholder="Поиск" />
									<label htmlFor="search-districts">
										<SearchIcon fill="#200E32" />
									</label>
								</div>
								<div className="selection-choices">
									<div className="selection-choices__item">
										<input type="checkbox" name="" id="khazar" />
										<label htmlFor="khazar">
											Хазарский р.
											<span className="selection-choices__times">
												<FaTimes />
											</span>
										</label>
									</div>
								</div>
							</SwiperSlide>
							<SwiperSlide>
								<h1>The Third</h1>
							</SwiperSlide>
							<SwiperSlide>
								<h1>The Fourth</h1>
							</SwiperSlide>
						</Swiper>
						<div className="d-flex align-items-center gap-4 mt-sm">
							<button className="g-btn-text g-caption__lg--semibold text-ntr-dark-02" form="" type="reset">Очистить фильтры</button>
							<button className="g-btn-green" form="" type="submit">Применить фильтры</button>
						</div>
					</form>
				</div>
			</div>
		</Modal>
	);
};

export default AdvancedFilterModal;
