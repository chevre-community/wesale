import {
	authSelectors,
	removeCredentials,
	removeUser,
} from "@/app/features/auth/authSlice";
import { getFullname, revealNavOnScroll } from "@/lib";
import Cookies from "js-cookie";

import React, { useEffect } from "react";
import { Dropdown } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import Select from "react-select";
import { CSSTransition } from "react-transition-group";

import Link from "next/link";
import { withRouter } from "next/router";

import {
	AdvancedFilterModal,
	BookmarkIcon,
	CustomImage,
	FilterFormWrapper,
	HeartIcon,
	ProfileIcon,
	SearchIcon,
} from "@/components";

import { useMain } from "@/context/providers/main-context";

import colors from "@/styles/modules/colors.module.scss";

const customStyles = {
	option: (provided, state) => ({
		...provided,
		padding: "4px 20px",
		background: colors["white"],
		color: !state.isSelected ? colors["primary-black"] : colors["primary-blue"],
		textAlign: "center",

		"&:hover": {
			color: colors["primary-blue"],
			cursor: "pointer",
		},
	}),
	control: (provided) => ({
		...provided,
		// none of react-select's styles are passed to <Control />
		borderStyle: "none !important",
		borderWidth: 0 + "!important",
		borderColor: "none !important",
		boxShadow: "none",
		width: "max-content",
		cursor: "pointer",
		marginRight: 16,
	}),
	menu: (provided) => ({
		...provided,
		border: "none",
		backgroundColor: colors["white"],
		boxShadow: "2px 5px 40px rgba(17, 20, 45, 0.08)",
		borderRadius: 12,
		width: "max-content",
		background: colors["white"],
	}),
	menuList: (provided) => ({
		...provided,
		border: "none",
		borderRadius: 12,
	}),
	singleValue: (provided, state) => {
		const opacity = state.isDisabled ? 0.5 : 1;
		const transition = "opacity 300ms";

		return { ...provided, opacity, transition };
	},
	dropdownIndicator: (provided) => ({
		...provided,
		padding: 4,
		color: colors["primary-black"],
	}),
};

const options = [
	{
		value: "az",
		label: "Az",
	},
	{
		value: "en",
		label: "En",
	},
	{
		value: "ru",
		label: "Ru",
	},
];

const Navbar = ({ router }) => {
	const dispatch = useDispatch();
	const { mainState, mainDispatch } = useMain();
	const { user, token } = useSelector(authSelectors);

	const handleLocaleChange = (locale) => {
		router.push(router.asPath, router.asPath, { locale });
	};

	const transitionClasses = {
		enter: "animate__animated animate__faster",
		enterActive: "animate__fadeInDown animate__faster",
		exit: "animate__animated animate__faster",
		exitActive: "animate__fadeOutUp animate__faster",
	};

	const logout = () => {
		Cookies.remove("token");
		dispatch(removeCredentials());
		dispatch(removeUser());

		router.push("/home");
	};

	useEffect(() => {
		revealNavOnScroll();

		return () => window.removeEventListener("scroll", revealNavOnScroll);
	}, []);

	return (
		<>
			<nav className="g-nav">
				<div className="g-container">
					<div className="g-nav__grid">
						<div className="g-nav__grid--main">
							<div className="g-nav__brand">
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
							<ul className="g-nav__links">
								<li className="g-nav__links--item">
									<Link href="/home" passHref>
										<a>Купить</a>
									</Link>
								</li>
								<li className="g-nav__links--item">
									<Link href="/home" passHref>
										<a>Снять</a>
									</Link>
								</li>
								<li className="g-nav__links--item">
									<Link href="/agencies" passHref>
										<a>Агентства</a>
									</Link>
								</li>
								<li className="g-nav__links--item">
									<Link href="/contact" passHref>
										<a>Контакты</a>
									</Link>
								</li>
							</ul>
							<button
								className="g-btn g-btn__with-icon g-transition"
								onClick={() => {
									mainDispatch({
										type: "TOGGLE_FILTER_FORM",
										payload: !mainState.FilterFormWrapperIsOpen,
									});
								}}
							>
								<SearchIcon />
								<span>
									{mainState.FilterFormWrapperIsOpen ? "Close" : "Search"}
								</span>
							</button>
						</div>
						<div className="g-nav__grid--side">
							<Select
								options={options}
								className="g-select"
								isSearchable={false}
								styles={customStyles}
								placeholder={false}
								defaultValue={options[1]}
								instanceId="languageSelect"
								onChange={(e) => handleLocaleChange(e.value)}
							/>
							<Link href="/dashboard/favourites" passHref>
								<a className="g-btn g-btn__icon with-gap-16">
									<HeartIcon />
								</a>
							</Link>
							<Link href="/dashboard/saved-searches" passHref>
								<a className="g-btn g-btn__icon with-gap-16">
									<BookmarkIcon />
								</a>
							</Link>
							{token && user ? (
								<div className="g-dropdown g-dropdown--user">
									<Dropdown>
										<Dropdown.Toggle>
											<ProfileIcon />
											<span>{getFullname(user.firstName, user.lastName)}</span>
										</Dropdown.Toggle>
										<Dropdown.Menu>
											<Dropdown.Item as="li">
												<Link href="/dashboard" passHref>
													<a>Главная</a>
												</Link>
											</Dropdown.Item>
											<Dropdown.Item as="li">
												<Link href="/dashboard" passHref>
													<a>Сохранненый поиск</a>
												</Link>
											</Dropdown.Item>
											<Dropdown.Item as="li">
												<Link href="/dashboard" passHref>
													<a>Настройки профиля</a>
												</Link>
											</Dropdown.Item>
											<Dropdown.Item as="li">
												<a onClick={logout}>Выход</a>
											</Dropdown.Item>
										</Dropdown.Menu>
									</Dropdown>
								</div>
							) : (
								<Link href="/home?login=true" shallow passHref>
									<a className="g-btn g-btn__icon with-gap-16">
										<ProfileIcon />
									</a>
								</Link>
							)}
							{/* <a className="g-btn g-btn__icon with-gap-16" onClick={toggle}>
								<ProfileIcon />
							</a> */}
							<Link href="/announcement/create" passHref>
								<a className="g-btn g-btn-blue with-gap-16">
									Разместить объявление
								</a>
							</Link>
						</div>
					</div>
				</div>
			</nav>
			<CSSTransition
				classNames={{
					...transitionClasses,
					exitDone: "hidden",
				}}
				timeout={500}
				onEnter={() =>
					mainDispatch({
						type: "TOGGLE_FILTER_FORM",
						payload: true,
					})
				}
				onExit={() => {
					mainDispatch({
						type: "TOGGLE_FILTER_FORM",
						payload: false,
					});
				}}
				mountOnEnter
				in={mainState.FilterFormWrapperIsOpen}
			>
				<FilterFormWrapper />
			</CSSTransition>

			<AdvancedFilterModal justClose={true} modal="advancedFilter" />
		</>
	);
};

export default withRouter(Navbar);
