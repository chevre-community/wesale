import React from "react";

import { CustomImage } from "@/components";

import classNames from "classnames";

import { FaTimes } from "react-icons/fa";

const UploadedImage = ({ image, isMain, alt }) => {
  return (
    <div
      className={classNames("uploaded-image", {
        "--main": isMain,
      })}
    >
      {isMain && <div className="uploaded-image__main">Главная</div>}
      <CustomImage src={image} alt={alt} width={146} height={119} />
      <button className="uploaded-image__remove">
        <FaTimes />
      </button>
    </div>
  );
};

export default UploadedImage;
