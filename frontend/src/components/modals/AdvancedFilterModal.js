import { useModal } from "@/lib";
import { A11y, EffectFade } from "swiper";
import { Swiper, SwiperSlide } from "swiper/react";

import React, { useCallback } from "react";

import { ChevronLeft, Modal } from "@/components";

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
		[activeIndex]
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
			)}{" "}
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
										className={`g-tabs__item ${
											filterFormSwiper?.activeIndex === 1 ? "active" : ""
										}`}
										onClick={() => handleSlideTo(filterFormSwiper, 1)}
									>
										Районы
									</button>
								</SwiperSlide>
								<SwiperSlide>
									<button
										className={`g-tabs__item ${
											filterFormSwiper?.activeIndex === 2 ? "active" : ""
										}`}
										onClick={() => handleSlideTo(filterFormSwiper, 2)}
									>
										Станции метро
									</button>
								</SwiperSlide>
								<SwiperSlide>
									<button
										className={`g-tabs__item ${
											filterFormSwiper?.activeIndex === 3 ? "active" : ""
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
					<Swiper
						direction="horizontal"
						allowTouchMove={false}
						onSwiper={setFilterFormSwiper}
						onSlideChange={changeActiveIndex}
						effect="fade"
						fadeEffect={{ crossFade: true }}
						speed={500}
						modules={[EffectFade]}
					>
						<SwiperSlide>
							<h1>The First</h1>
						</SwiperSlide>
						<SwiperSlide>
							<h1>The Second</h1>
						</SwiperSlide>
						<SwiperSlide>
							<h1>The Third</h1>
						</SwiperSlide>
						<SwiperSlide>
							<h1>The Fourth</h1>
						</SwiperSlide>
					</Swiper>
				</div>
			</div>
		</Modal>
	);
};

export default AdvancedFilterModal;
