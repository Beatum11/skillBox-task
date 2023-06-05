import React from "react";
import { useLocation } from "react-router-dom";
import Menu from "../MenuPart/Menu";
import "../../css-files/css-projects/open-project.css";

const OpenProject = () => {
  const location = useLocation();
  const { title, img, description } = location.state;

  return (
    <>
      <Menu />
      <div className="openProject-container">
        <div className="openProject-upper-part">
          <h1 className="dark-skill-color">{title}</h1>
          <img alt="project logo" src={img} />
        </div>
        <div className="openProject-lower-part">
          <p className="small-text">{description}</p>
        </div>
      </div>
    </>
  );
};

export default OpenProject;
