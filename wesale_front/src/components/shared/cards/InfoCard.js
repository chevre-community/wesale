import React from "react";

import { ContractIcon, PercentageIcon, ProfileIcon } from "@/components";

import { FiHeart } from "react-icons/fi";

import { CSSTransition } from "react-transition-group";

import { seperateWithSpace } from "@/lib";

const InfoCard = ({
  showPhone,
  setShowPhone,
  price,
  currency,
  mortgage_price,
  phone_numbers,
  wp_phone,
}) => {
  return (
    <div className="info-card">
      <div className="d-flex align-items-center justify-content-between flex-wrap">
        <p className="g-title__sm--bold">
          {seperateWithSpace(price)} {currency}
        </p>
        <button className="info-card__like-btn">
          <FiHeart />
        </button>
      </div>
      <div className="info-card__details">
        <div className="info-card__details--item">
          <div className="info-card__details--icon">
            <ContractIcon />
          </div>
          <div className="ml-sm">
            <p className="g-caption__lg--regular">Купчая</p>
            <p className="g-text__sm--bold">Имеется</p>
          </div>
        </div>
        <div className="info-card__details--item">
          <div className="info-card__details--icon">
            <PercentageIcon />
          </div>
          <div className="ml-sm">
            <p className="g-caption__lg--regular">Ипотека</p>
            <p className="g-text__sm--bold">
              от {mortgage_price} {currency}/мес
            </p>
            <a href="" className="mt-xs g-caption__lg--semibold text-primary">
              Подать заявку
            </a>
          </div>
        </div>
        <div className="info-card__details--item">
          <div className="info-card__details--icon">
            <ProfileIcon />
          </div>
          <div className="ml-sm">
            <p className="g-caption__lg--regular">Собственник</p>
            <p className="g-text__sm--bold">Ангелина Петровна</p>
          </div>
        </div>
      </div>
      {!showPhone && (
        <button
          className="g-btn-primary g-btn--block"
          onClick={() => setShowPhone(true)}
        >
          Показать номер
        </button>
      )}
      {phone_numbers && (
        <div className="phone-list">
          {phone_numbers.map((phone, index) => (
            <CSSTransition
              classNames="item"
              timeout={600}
              onEnter={() => setShowPhone(true)}
              onExit={() => setShowPhone(false)}
              unmountOnExit
              in={showPhone}
              key={index}
            >
              <a href={`tel:+${phone}`} className="g-btn-blue g-btn--block">
                {phone}
              </a>
            </CSSTransition>
          ))}
        </div>
      )}
      {wp_phone && (
        <a href="tel:+" className="g-btn-mint g-btn--block mt-sm">
          Написать в WhatsApp
        </a>
      )}
    </div>
  );
};

export default InfoCard;
