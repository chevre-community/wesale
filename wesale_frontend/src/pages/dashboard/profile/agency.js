import { autoResize } from "@/lib";

import React, { useEffect } from "react";

import {
	Checkbox,
	CustomImage,
	DashboardLayout,
	FormGroup,
	GInput,
	UploadIcon,
} from "@/components";

const AgencyProfile = () => {
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
							<label
								className="g-btn-upload mb-2 w-content"
								htmlFor="upload-btn"
							>
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
							<div className="mt-lg">
								<div className="d-flex align-items-center gap-3">
									<button className="g-btn-secondary">
										Отменить изменения
									</button>
									<button className="g-btn-green">Сохранить</button>
								</div>
							</div>
						</div>
					</form>
				</div>
			</div>
		</div>
	);
};

AgencyProfile.getLayout = (page) => {
	return <DashboardLayout>{page}</DashboardLayout>;
};

export default AgencyProfile;
