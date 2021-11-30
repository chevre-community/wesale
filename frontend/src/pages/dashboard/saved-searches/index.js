import React from "react";

import Link from "next/link";

import { ContractIcon, DashboardLayout, PercentageIcon } from "@/components";

const SavedSearchesPage = (props) => {
	return (
		<div className="dashboard-container">
			<div className="d-flex align-items-center gap-2">
				<h4 className="g-title__md--bold">Сохранненый поиск</h4>
				<p className="g-text__xs--medium text-secondary-grey">2 поиска</p>
			</div>
			<div className="announcement-cards">
				<div className="announcement-card">
					<div className="announcement-card__header">
						<p className="g-text__sm--semibold text-primary-grey announcement-card__title">
							Очень срочно! Нариманово
						</p>
					</div>
					<div className="announcement-card__body">
						<div className="announcement-card__main w-100">
							<div className="d-flex align-items-center justify-content-between flex-wrap gap-2">
								<p className="g-text__sm--semibold text-primary-grey">
									2000 ₼/мес
								</p>
								<div className="d-flex align-items-center gap-2">
									<ContractIcon />
									<PercentageIcon />
								</div>
							</div>
							<div className="d-flex align-items-center flex-wrap mt-2">
								<p className="g-caption__lg--regular text-primary-grey with-dot">
									4 комн.
								</p>
								<p className="g-caption__lg--regular text-primary-grey with-dot">
									220 - 440 м <sup>2</sup>
								</p>
								<p className="g-caption__lg--regular text-primary-grey with-dot">
									14/17 этаж
								</p>
								<p className="g-caption__lg--regular text-primary-grey with-dot">
									еще 28 фильтров
								</p>
							</div>
						</div>
					</div>
				</div>
				<div className="announcement-card">
					<div className="announcement-card__header">
						<p className="g-text__sm--semibold text-primary-grey announcement-card__title">
							Сохраненный поиск 1
						</p>
					</div>
					<div className="announcement-card__body">
						<div className="announcement-card__main w-100">
							<div className="d-flex align-items-center justify-content-between flex-wrap gap-2">
								<p className="g-text__sm--semibold text-primary-grey">
									2000 ₼/мес
								</p>
								<div className="d-flex align-items-center gap-2">
									<ContractIcon />
									<PercentageIcon />
								</div>
							</div>
							<div className="d-flex align-items-center flex-wrap mt-2">
								<p className="g-caption__lg--regular text-primary-grey with-dot">
									4 комн.
								</p>
								<p className="g-caption__lg--regular text-primary-grey with-dot">
									220 - 440 м <sup>2</sup>
								</p>
								<p className="g-caption__lg--regular text-primary-grey with-dot">
									14/17 этаж
								</p>
								<p className="g-caption__lg--regular text-primary-grey with-dot">
									еще 28 фильтров
								</p>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	);
};

SavedSearchesPage.getLayout = (page) => {
	return <DashboardLayout>{page}</DashboardLayout>;
};

export default SavedSearchesPage;
