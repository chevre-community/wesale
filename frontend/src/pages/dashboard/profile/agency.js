import { autoResize, useModal } from "@/lib";

import React, { useEffect } from "react";

import {
	BasicInfoModal,
	Button,
	ChangeEmailModal,
	Checkbox,
	CustomImage,
	DashboardLayout,
	FormGroup,
	GInput,
	GSelect,
	PlusIcon,
	UploadIcon,
	WithLoader,
} from "@/components";

import colors from "@/styles/modules/colors.module.scss";

const AgencyProfile = () => {
	const { isShowing, toggle } = useModal();

	useEffect(() => {
		autoResize();
	}, []);

	return (
		<div className="dashboard-container">
			<h3 className="g-title__sm--bold mb-sm">Профиль агенства</h3>
			<div className="agency-profile">
				<div className="agency-profile__main-info">
					<div className="agency-profile__main-info-img">
						<CustomImage
							src="/static/svgs/agencies/absheron.svg"
							alt="Агенство БСХЕРОН"
							width="1040"
							height="800"
						/>
					</div>
					<div className="agency-profile__main-info-content">
						<p className="styled__list-title">
							Вы можете добавить свой логотип, чтобы пользователи быстрее
							замечали и узнавали вашу компанию.
						</p>
						<ul className="styled__list">
							<li className="styled__list-item">
								Формат – JPG, PNG, TIFF или BMP.
							</li>
							<li className="styled__list-item">Размер – не более 5 МБ.</li>
							<li className="styled__list-item">
								Рекомендуемое разрешение – не менее 720 x 720 пикс. и не более
								3000 x 3000 пикс.
							</li>
						</ul>
						<div className="d-flex align-items-center mt-md gap-5">
							<label className="g-btn-upload w-content" htmlFor="upload-btn">
								<input
									className="visually-hidden"
									type="file"
									name=""
									id="upload-btn"
								/>
								<span>Загрузить фото</span>
							</label>
							<button className="g-btn-text g-caption__lg--medium text-ntr-dark-03">
								Удалить фото
							</button>
						</div>
					</div>
				</div>
				<div className="agency-profile__form">
					<p className="g-text__lg--semibold">Общие данные</p>
					<form action="" method="post">
						<div className="mt-md-24">
							<div className="agency-profile__form-item">
								<FormGroup label={"Название агенства"} size="md">
									<GInput defaultValue="Abşeron Əmlak agentliyi" />
								</FormGroup>
							</div>
							<div className="agency-profile__form-item">
								<FormGroup label={"Об агестстве"}>
									<textarea
										name=""
										id="area-1"
										placeholder="Расскажите подробнее о своем агентстве"
										className="g-textarea"
										data-autoresize
									/>
								</FormGroup>
							</div>
							<div className="agency-profile__form-item">
								<div className="g-form-group-wrapper__two-item">
									<FormGroup label={"Время работы"}>
										<GInput defaultValue={"9:00-18:00"} />
									</FormGroup>
									<FormGroup label={"Рабочие дни"}>
										<GSelect
											options={[
												{
													label: "Пн - Пт",
													value: 0,
												},
												{
													label: "Lorem 1",
													value: 1,
												},
												{
													label: "Lorem 2",
													value: 2,
												},
											]}
											instanceId={"work-time-range"}
										/>
									</FormGroup>
								</div>
							</div>
							<div className="agency-profile__form-item">
								<FormGroup label={"Адрес"} size="lg">
									<GInput defaultValue="г. Баку , ул. Истиглалият 32" />
								</FormGroup>
							</div>
							<div className="agency-profile__form-item">
								<Checkbox
									id="iwant"
									label={"Я хочу получать новые уведомления на почту"}
								/>
							</div>
							<div className="my-lg">
								<p className="g-text__lg--semibold mb-md-24">
									Контактные данные
								</p>
								<p className="text-with-dash g-text__md--regular mb-sm">
									— Укажите номер телефона по которому пользователи смогут к вам
									позвонить
								</p>
								<div className="phone-input__grid">
									<FormGroup label={"Контактный номер"} size="md">
										<div className="phone-input">
											<div className="phone-input__select">
												<GSelect
													options={[
														{
															label: "+99450",
															value: "+99450",
														},
														{
															label: "+99455",
															value: "+99455",
														},
														{
															label: "+99470",
															value: "+99470",
														},
														{
															label: "+99477",
															value: "+99477",
														},
													]}
													instanceId="phone-input-select"
													control_color={colors["primary-blue"]}
												/>
											</div>
											<input type="text" placeholder="000  00  00" />
										</div>
									</FormGroup>
									<button className="g-btn-count">
										<PlusIcon />
									</button>
								</div>
								<div className="phone-input__grid mt-lg-42">
									<FormGroup label={"Связь по “WhatsApp”"} size="md">
										<div className="phone-input">
											<div className="phone-input__select">
												<GSelect
													options={[
														{
															label: "+99450",
															value: "+99450",
														},
														{
															label: "+99455",
															value: "+99455",
														},
														{
															label: "+99470",
															value: "+99470",
														},
														{
															label: "+99477",
															value: "+99477",
														},
													]}
													instanceId="phone-input-select-for-wp"
													control_color={colors["primary-blue"]}
												/>
											</div>
											<input type="text" placeholder="000  00  00" />
										</div>
									</FormGroup>
								</div>
								<div className="mt-lg-42">
									<div className="d-flex align-items-center gap-md">
										<FormGroup
											label="Email"
											size="md"
											info={"Ваш email виден только вам"}
										>
											<GInput
												type="email"
												disabled={true}
												defaultValue="absheronamlakagentliyi@gmail.com"
											/>
										</FormGroup>
										<button
											className="g-btn-text g-caption__lg--medium text-primary-blue"
											onClick={(e) => {
												e.preventDefault();

												toggle({
													value: true,
													modal: "changeEmail",
												});
											}}
										>
											Сменить почту
										</button>
									</div>
								</div>
							</div>
							<div className="d-flex align-items-center gap-3">
								<Button variant="secondary">Отменить изменения</Button>
								<Button variant="green">Сохранить</Button>
							</div>
						</div>
					</form>
				</div>
			</div>
		</div>
	);
};

AgencyProfile.getLayout = (page) => {
	return (
		<DashboardLayout>
			{page}
			<ChangeEmailModal justClose={true} modal="changeEmail" />
			<BasicInfoModal justClose={true} modal="basicInfo" />
		</DashboardLayout>
	);
};

export default AgencyProfile;
