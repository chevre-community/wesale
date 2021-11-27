import React, { useState } from "react";
import { FaTimes } from "react-icons/fa";
import { CSSTransition } from "react-transition-group";

import Link from "next/link";

import {
	DashboardBookmarkIcon,
	DashboardHomeIcon,
	DashboardLikeIcon,
	DashboardProfileIcon,
	DashboardSettingIcon,
	DashboardSignoutIcon,
	HandbagIcon,
	NavLink,
} from "@/components";

const Sidebar = () => {
	const [isOpen, setIsOpen] = useState(true);

	return (
		<aside className="dashboard-sidebar">
			<ul className="dashboard-nav">
				<li className="dashboard-nav__item">
					<NavLink activeClassName="active" href="/dashboard" passHref>
						<a>
							<span className="dashboard-nav__item--icon">
								<DashboardHomeIcon />
							</span>
							<span>Главная</span>
						</a>
					</NavLink>
				</li>
				<li className="dashboard-nav__item">
					<NavLink
						activeClassName="active"
						href="/dashboard/profile/agency"
						passHref
					>
						<a>
							<span className="dashboard-nav__item--icon">
								<DashboardProfileIcon />
							</span>
							<span>Профиль Агенства</span>
						</a>
					</NavLink>
				</li>
				<li className="dashboard-nav__item">
					<NavLink
						activeClassName="active"
						href="/dashboard/favourites"
						passHref
					>
						<a>
							<span className="dashboard-nav__item--icon">
								<DashboardLikeIcon />
							</span>
							<span>Избранное</span>
						</a>
					</NavLink>
				</li>
				<li className="dashboard-nav__item">
					<NavLink
						activeClassName="active"
						href="/dashboard/saved-searches"
						passHref
					>
						<a>
							<span className="dashboard-nav__item--icon">
								<DashboardBookmarkIcon />
							</span>
							<span>Сохранненый поиск</span>
						</a>
					</NavLink>
				</li>
				<li className="dashboard-nav__item">
					<NavLink
						activeClassName="active"
						href="/dashboard/profile/user"
						passHref
					>
						<a>
							<span className="dashboard-nav__item--icon">
								<DashboardSettingIcon />
							</span>
							<span>Настройки профиля</span>
						</a>
					</NavLink>
				</li>
				<li className="dashboard-nav__item">
					<NavLink activeClassName="active" href="/home" passHref>
						<a>
							<span className="dashboard-nav__item--icon">
								<DashboardSignoutIcon />
							</span>
							<span>Выход</span>
						</a>
					</NavLink>
				</li>
			</ul>
			<CSSTransition in={isOpen} timeout={300} classNames="item" unmountOnExit>
				<div className="become-agency">
					<div className="become-agency__header">
						<div className="become-agency__icon">
							<HandbagIcon />
						</div>
						<button
							className="g-btn-reset become-agency__close"
							onClick={() => setIsOpen(false)}
						>
							<FaTimes />
						</button>
					</div>
					<div className="become-agency__body">
						<p className="g-text__sm--semibold text-white mb-2">
							Публикуйте от имени Агенства!
						</p>
						<p className="g-caption__md--medium text-white">
							Смените свой аккаунт на аккаунт Агенства и бла бла бла
						</p>
						<Link href="/dashboard" passHref>
							<a className="g-btn-primary">Стать Агенством</a>
						</Link>
					</div>
				</div>
			</CSSTransition>
		</aside>
	);
};

export default Sidebar;
