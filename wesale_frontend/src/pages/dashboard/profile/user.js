import React, { useRef, useState } from "react";
import { Tab, Tabs } from "react-bootstrap";

import {
	Checkbox,
	DashboardLayout,
	EyeCloseIcon,
	EyeOpenIcon,
	FormGroup,
	GInput,
	InputRadio,
} from "@/components";

const AgencyProfile = () => {
	const [isPassword, setIsPassword] = useState(true);

	const passwordInput = useRef();

	const togglePasswordType = (e) => {
		e.preventDefault();
		setIsPassword(!isPassword);

		if (isPassword) {
			passwordInput.current.type = "password";
		} else {
			passwordInput.current.type = "text";
		}
	};

	return (
		<div className="dashboard-container">
			<div className="dashboard-user-profile">
				<h3 className="g-title__sm--bold mb-md-24">Настройки профиля</h3>
				<div className="dashboard-tabs">
					<Tabs transition={true} onDurationChange={(e) => console.log(e)}>
						<Tab.Pane eventKey="profile" title="Личная информация">
							<form action="">
								<div className="profile-form-grid">
									<div className="profile-form-grid__item">
										<FormGroup label="Имя" id="name">
											<GInput
												id="name"
												disabled={true}
												defaultValue={"Habil"}
											/>
										</FormGroup>
									</div>
									<div className="profile-form-grid__item">
										<FormGroup label="Фамилия" id="surname">
											<GInput
												id="surname"
												disabled={true}
												defaultValue={"Abıyev"}
											/>
										</FormGroup>
									</div>
									<div className="profile-form-grid__item">
										<FormGroup label="Страна" id="country">
											<GInput id="country" defaultValue={"Azerbaijan"} />
										</FormGroup>
									</div>
									<div className="profile-form-grid__item">
										<FormGroup label="Город" id="city">
											<GInput id="city" defaultValue={"Lankaran"} />
										</FormGroup>
									</div>
									<div className="profile-form-grid__item">
										<FormGroup
											label="Email"
											id="email"
											info={"Ваш email виден только вам"}
										>
											<GInput
												id="email"
												defaultValue={"abiyevhabil3@gmail.com"}
												disabled
											/>
										</FormGroup>
									</div>
									<div className="profile-form-grid__item d-flex align-items-center">
										<button className="g-btn-text g-caption__lg--semibold text-primary-blue hover-primary-blue-hover">
											Сменить почту
										</button>
									</div>
									<div className="profile-form-grid__item profile-form-grid__item--full-col">
										<FormGroup label="Пол" id="Пол">
											<div className="d-flex align-items-center gap-4">
												<InputRadio
													id={"male"}
													name={"sex"}
													label={"Мужчина"}
												/>
												<InputRadio
													id={"female"}
													name={"sex"}
													label={"Женщина"}
												/>
											</div>
										</FormGroup>
									</div>
								</div>
								<button className="g-btn-text g-caption__lg--semibold text-secondary-grey mt-lg-42">
									Удалить профиль
								</button>
								<div className="d-flex align-items-center gap-3 mt-lg">
									<button className="g-btn-secondary">
										Отменить изменения
									</button>
									<button className="g-btn-green">Отменить изменения</button>
								</div>
							</form>
						</Tab.Pane>
						<Tab.Pane eventKey="Уведомления" title="Уведомления">
							<p className="g-text__sm--regular text-ntr-dark-06 mb-md-24">
								Получать предложения от исполнителей на задание, а так же
								получайте напоминания о ноых предложениях, отзывы от заказчиков,
								уведомления о заданиях и прочие советы о <br /> действиях на
								WeSale
							</p>
							<form action="">
								<ul className="profile-form__checkbox-list">
									<li>
										<Checkbox
											label={"Я хочу получать новости сайта"}
											id={"ch-1"}
										/>
									</li>
									<li>
										<Checkbox label={"Электронные письма"} id={"ch-1"} />
									</li>
									<li>
										<Checkbox label={"SMS-сообщения"} id={"ch-1"} />
									</li>
									<li>
										<Checkbox label={"Системные уведомления"} id={"ch-1"} />
									</li>
								</ul>
								<div className="d-flex align-items-center gap-3 mt-lg">
									<button className="g-btn-secondary">
										Отменить изменения
									</button>
									<button className="g-btn-green">Отменить изменения</button>
								</div>
							</form>
						</Tab.Pane>
						<Tab.Pane eventKey="Безопасность" title="Безопасность">
							<form action="" autoComplete={"off"}>
								<div className="profile-form__last">
									<div className="profile-form__info-list">
										<p>
											Ваш пароль должен состоять не менее чем из 8 символов:
										</p>
										<ul>
											<li>Заглавные буквы</li>
											<li>Строчные буквы</li>
											<li>Цифры или специальные символы: %, #, $ и другие</li>
										</ul>
									</div>
									<FormGroup label="Новый пароль" id="Сменить пароль">
										<div className="g-password-field">
											<input className="" type="password" ref={passwordInput} />
											<button
												className="password-toggle"
												onClick={togglePasswordType}
											>
												{!isPassword ? <EyeCloseIcon /> : <EyeOpenIcon />}
											</button>
										</div>
									</FormGroup>
									<FormGroup
										label="Повторить новый пароль"
										id="Повторить новый пароль"
									>
										<div className="g-password-field">
											<input className="" type="password" ref={passwordInput} />
											<button
												className="password-toggle"
												onClick={togglePasswordType}
											>
												{!isPassword ? <EyeCloseIcon /> : <EyeOpenIcon />}
											</button>
										</div>
									</FormGroup>
								</div>
								<div className="d-flex align-items-center gap-3 mt-lg">
									<button className="g-btn-secondary">
										Отменить изменения
									</button>
									<button className="g-btn-green">Сохранить</button>
								</div>
							</form>
						</Tab.Pane>
					</Tabs>
				</div>
			</div>
		</div>
	);
};

AgencyProfile.getLayout = (page) => {
	return <DashboardLayout>{page}</DashboardLayout>;
};

export default AgencyProfile;
