import {
  Checkbox,
  ChevronLeft,
  ChevronRight,
  EyeCloseIcon,
  EyeOpenIcon,
  GSelect,
  InputRadio,
  InputText,
  MainLayout,
  MinusIcon,
  PlusIcon,
  SwitchButton,
  UploadIcon,
  withFormGroup,
} from "@/components";

import React, { useEffect, useRef, useState } from "react";

import { Col, Pagination, Row } from "react-bootstrap";

const System = () => {
  const [isPassword, setIsPassword] = useState(true);
  const passwordInput = useRef();

  const options = [
    {
      label: "January",
      value: "January",
    },
    {
      label: "February",
      value: "February",
    },
    {
      label: "March",
      value: "March",
    },
  ];

  const togglePasswordType = () => {
    setIsPassword(!isPassword);

    if (isPassword) {
      passwordInput.current.type = "password";
    } else {
      passwordInput.current.type = "text";
    }
  };

  useEffect(() => togglePasswordType(), []);

  return (
    <>
      <div className="design-section">
        <div className="colors">
          <div className="bg-primary-black color"></div>
          <div className="bg-primary-blue color"></div>
          <div className="bg-primary-grey color"></div>
          <div className="bg-secondary-error color"></div>
          <div className="bg-secondary-green color"></div>
          <div className="bg-secondary-blue color"></div>
          <div className="bg-secondary-grey color"></div>
          <div className="bg-ntr-dark-01 color"></div>
          <div className="bg-ntr-dark-02 color"></div>
          <div className="bg-ntr-dark-03 color"></div>
          <div className="bg-ntr-dark-04 color"></div>
          <div className="bg-ntr-light-01 color"></div>
          <div className="bg-ntr-light-02 color"></div>
          <div className="bg-ntr-light-03 color"></div>
          <div className="bg-ntr-light-04 color"></div>
          <div className="bg-ntr-light-05 color"></div>
          <div className="bg-shade-blue color"></div>
          <div className="bg-shade-linear-blue color"></div>
        </div>
      </div>
      <div className="design-section">
        <div className="d-flex align-items-center justify-content-between">
          <div className="g-form-group">
            <Checkbox
              id={"checkbox-1"}
              name={"checkbox"}
              label={"Checkbox Active"}
            />
            <Checkbox
              id={"checkbox-2"}
              label={"Checkbox Disabled"}
              disabled
              checked
              name={"checkbox"}
            />
          </div>
          <div className="g-form-group">
            <InputRadio id={"radio-1"} label={""} name={"radio"} />
            <InputRadio
              id={"radio-2"}
              label={""}
              name={"radio"}
              disabled
              checked
            />
          </div>
          <div className="g-form-group">
            <SwitchButton
              id={"switch-1"}
              name={"switch"}
              label={"Отопление:"}
            />
            <SwitchButton
              id={"switch-2"}
              name={"switch"}
              label={"Лифт:"}
              disabled
              checked
            />
          </div>
        </div>
      </div>
      <div className="design-section">
        <Row>
          <Col md={6}>
            <div className="mb-sm">
              {withFormGroup(InputText, {
                disabled: false,
                placeholder: "Name",
                id: "name",
                label: "Name",
              })}
              {/* <div className="g-form-group disabled">
                <label htmlFor="" className="g-label">
                  Name
                </label>
                <input type="text" className="g-input" placeholder="Name" />
              </div> */}
            </div>
            <div className="g-form-group">
              <label htmlFor="" className="g-label">
                Surname
              </label>
              <input type="text" className="g-input" placeholder="Surname" />
            </div>
            <div className="g-form-group">
              <label htmlFor="" className="g-label">
                Email
              </label>
              <input type="email" className="g-input" placeholder="Surname" />
              <span className="g-caption g-caption__md--medium">Caption</span>
            </div>
            <div className="mt-sm">
              <div className="g-form-group">
                <label htmlFor="" className="g-label">
                  Address
                </label>
                <input type="text" className="g-input" placeholder="Surname" />
                <span className="g-error g-caption__md--medium text-secondary-error">
                  Error
                </span>
              </div>
            </div>
          </Col>
          <Col md={6}>
            <div className="mb-sm">
              <div className="g-form-group">
                <label htmlFor="" className="g-label">
                  Password
                </label>
                <div className="g-password-field">
                  <input className="" type="password" ref={passwordInput} />
                  <button
                    className="password-toggle"
                    onClick={togglePasswordType}
                  >
                    {!isPassword ? <EyeCloseIcon /> : <EyeOpenIcon />}
                  </button>
                </div>
                <span className="g-error g-caption__md--medium text-secondary-error">
                  Error
                </span>
              </div>
            </div>
          </Col>
          <Col md={4}>
            <div className="mt-md">
              <button className="g-btn-primary mr-sm">Отправить</button>
              <button className="g-btn-primary mr-sm mb-sm disabled">
                Отправить
              </button>
              <button className="g-btn-secondary mr-sm">Сохранить</button>
              <button className="g-btn-secondary disabled">Сохранить</button>
              <div className="mt-sm">
                <button className="g-btn-mint mr-sm">
                  Написать в WhatsApp
                </button>
                <button className="g-btn-mint disabled">
                  Написать в WhatsApp
                </button>
              </div>
            </div>
          </Col>
          <Col md={4}>
            <div className="mt-md">
              <label className="g-btn-upload mb-2" htmlFor="upload-btn">
                <input
                  className="visually-hidden"
                  type="file"
                  name=""
                  id="upload-btn"
                />
                <UploadIcon />
                <span>Выберите фотографии</span>
              </label>
              <label className="g-btn-upload disabled" htmlFor="upload-btn-2">
                <input
                  className="visually-hidden"
                  type="file"
                  name=""
                  id="upload-btn-2"
                />
                <UploadIcon />
                <span>Выберите фотографии</span>
              </label>
            </div>
          </Col>
          <Col md={4}>
            <div className="g-select-wrapper">
              <div className="g-form-group">
                <label htmlFor="" className="g-label">
                  Month
                </label>
                <GSelect
                  options={options}
                  instanceId={"customSelect"}
                  placeholder={"Month"}
                />
              </div>
            </div>
          </Col>
          <Col md={8}>
            <div className="my-sm">
              <div className="d-flex align-items-center">
                <Pagination className="g-pagination">
                  <Pagination.Item className="g-pagination__item active">
                    1
                  </Pagination.Item>
                  <Pagination.Item className="g-pagination__item">
                    2
                  </Pagination.Item>
                  <Pagination.Item className="g-pagination__item">
                    3
                  </Pagination.Item>
                  <Pagination.Next className="g-pagination__item g-pagination__controller">
                    Next
                  </Pagination.Next>
                </Pagination>
                <Pagination className="g-pagination ml-sm">
                  <Pagination.Item className="g-pagination__item active disabled">
                    1
                  </Pagination.Item>
                  <Pagination.Item className="g-pagination__item disabled">
                    2
                  </Pagination.Item>
                  <Pagination.Item className="g-pagination__item disabled">
                    3
                  </Pagination.Item>
                  <Pagination.Next className="g-pagination__item disabled g-pagination__controller">
                    Next
                  </Pagination.Next>
                </Pagination>
              </div>
            </div>
          </Col>
          <Col md={4}>
            <a href="" className="g-link g-link__blue mr-sm">
              Заказать съёмку
            </a>
            <a href="" className="g-link g-link__blue disabled">
              Заказать съёмку
            </a>
            <div className="d-flex align-items-center flex-wrap">
              <button className="g-btn-arrow mr-sm">
                <ChevronLeft />
              </button>
              <button className="g-btn-arrow mr-sm">
                <ChevronRight />
              </button>
              <button className="g-btn-count mr-sm">
                <PlusIcon />
              </button>
              <button className="g-btn-count">
                <MinusIcon />
              </button>
            </div>
          </Col>
          <Col md={6}>
            <div className="g-form-group mb-sm">
              <label htmlFor="area-1" className="g-label">
                Comment
              </label>
              <textarea
                name=""
                id="area-1"
                placeholder="Расскажите подробнее о своем агентстве"
                className="g-textarea"
                data-autoresize
              ></textarea>
            </div>
            <div className="g-form-group disabled">
              <label htmlFor="area-2" className="g-label">
                Comment
              </label>
              <textarea
                name=""
                id="area-2"
                placeholder="Расскажите подробнее о своем агентстве"
                className="g-textarea"
                data-autoresize
              ></textarea>
            </div>
          </Col>
        </Row>
      </div>
    </>
  );
};

export default System;
