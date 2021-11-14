import React, { useState } from "react";

import { Tabs, Tab } from "react-bootstrap";

import { FilterFormHome, FilterFormObject } from "@/components";

const FilterForm = () => {
  const [key, setKey] = useState("home");

  const options = [
    {
      label: "Купить",
      value: "Купить",
    },
  ];

  const options2 = [
    {
      label: "Квартиру",
      value: "Квартиру",
    },
  ];
  return (
    <div className="filter-form-tabs">
      <Tabs
        id="filter-form-tabs"
        activeKey={key}
        onSelect={(k) => setKey(k)}
        transition={true}
      >
        <Tab.Pane eventKey="home" title="Дом">
          <FilterFormHome
            colors={{
              icon: "white",
            }}
            options={options}
            options2={options2}
          />
        </Tab.Pane>
        <Tab.Pane eventKey="profile" title="Объект">
          <FilterFormObject
            colors={{
              icon: "white",
            }}
            options={options}
            options2={options2}
          />
        </Tab.Pane>
      </Tabs>
    </div>
  );
};

export default FilterForm;
