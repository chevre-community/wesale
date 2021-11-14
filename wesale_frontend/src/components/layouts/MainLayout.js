import React, { useEffect, useRef, useState } from "react";

import { CSSTransition } from "react-transition-group";

import { Navbar, Footer, FilterFormWrapper } from "@/components";

import { useMain } from "@/context/providers/main-context";

const MainLayout = ({ children }) => {
  const { mainState, mainDispatch } = useMain();
  const navRef = useRef("");

  const transitionClasses = {
    enter: "animate__animated animate__faster",
    enterActive: "animate__fadeInDown animate__faster",
    exit: "animate__animated animate__faster",
    exitActive: "animate__fadeOutUp animate__faster",
  };

  return (
    <>
      <Navbar ref={navRef} mainState={mainState} mainDispatch={mainDispatch} />
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
      <div className="g-container">{children}</div>
      <Footer />
    </>
  );
};

export default MainLayout;
