import React from "react";

import Title from "./Title";

const Section = ({ children }) => {
	return (
		<div className="g-section">
			<div className="flex-center-between">
				{/* <p className="g-title__sm--bold">Последние объявления</p> */}
				<div className="g-section-tabs">
					<button className="g-section-tab active">Все</button>
					<button className="g-section-tab">Квартиры</button>
					<button className="g-section-tab">Дома</button>
					<button className="g-section-tab">Объекты</button>
				</div>
			</div>
			<div className="g-section-wrapper">{children}</div>
		</div>
	);
};

export default Object.assign(Section, {
	Title,
});
