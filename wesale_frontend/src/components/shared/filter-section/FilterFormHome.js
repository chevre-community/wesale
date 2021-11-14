import React from "react";

import { FilterIcon, GSelect, InputText } from "@/components";

import { FiSearch } from "react-icons/fi";

import classNames from "classnames";

import colorVariables from "@/styles/modules/colors.module.scss";

const FilterFormHome = ({ options, options2, colors }) => {
  return (
    <form action="" method="get">
      <div className="filter-form-grid">
        <div className="filter-form-grid__item">
          <GSelect
            options={options}
            placeholder={"Type"}
            radius={8}
            instanceId={"filter-form-home-1"}
            padding_control={12}
            padding_option={[8, 12]}
            height={48}
          />
        </div>
        <div className="filter-form-grid__item">
          <GSelect
            options={options2}
            placeholder={"Квартиру"}
            radius={8}
            instanceId={"filter-form-home-2"}
            padding_control={12}
            padding_option={[8, 12]}
            height={48}
          />
        </div>
        <div className="filter-form-grid__item">
          <div className="rooms">
            <p className="rooms-label">Комнаты</p>
            <div className="number-of-rooms">
              <div className="number-of-rooms__item">
                <input
                  className="visually-hidden"
                  type="radio"
                  name="rooms"
                  id="1"
                />
                <label htmlFor="1">1</label>
              </div>
              <div className="number-of-rooms__item">
                <input
                  className="visually-hidden"
                  type="radio"
                  name="rooms"
                  id="2"
                />
                <label htmlFor="2">2</label>
              </div>
              <div className="number-of-rooms__item">
                <input
                  className="visually-hidden"
                  type="radio"
                  name="rooms"
                  id="3"
                />
                <label htmlFor="3">3</label>
              </div>
              <div className="number-of-rooms__item">
                <input
                  className="visually-hidden"
                  type="radio"
                  name="rooms"
                  id="4"
                />
                <label htmlFor="4">4+</label>
              </div>
            </div>
          </div>
        </div>
        <div className="filter-form-grid__item">
          <InputText
            id={"Цена"}
            placeholder={"Цена"}
            classname="filter-form-input"
            name={"Цена"}
          />
          {/* <div className="filter-form__price-range">
                      <input type="number" name="" id="" placeholder="от" />
                      <div className="price-range__divider" />
                      <input type="number" name="" id="" placeholder="до" />
                    </div> */}
        </div>
        <div className="filter-form-grid__item">
          <InputText
            id={"Область поиска"}
            placeholder={"Область поиска"}
            classname="filter-form-input"
            name={"Область поиска"}
          />
          {/* <div className="filter-form__search-results">
                      <ul>
                        <li>метро Нариманово</li>
                        <li>Наримановский парк</li>
                        <li>метро Нариманово</li>
                      </ul>
                    </div> */}
        </div>
        <div className="filter-form__action-buttons">
          <button
            className={classNames("filter-form__btn", {
              ["text-" + colors?.icon]: "text" + colors?.icon,
            })}
          >
            <FilterIcon />
            <span className="number-of-active-filters">12</span>
          </button>
          <button className="filter-form__submit" type="submit">
            <FiSearch />
          </button>
        </div>
      </div>
    </form>
  );
};

export default FilterFormHome;
