import React from "react";
import { useLocation } from "react-router-dom";
import Menu from "../MenuPart/Menu";
import "../../css-files/css-blog/open-blog.css";
import Headline from "../elements/Headline";


const OpenBlog = () => {

  const location = useLocation();
  const { title, img, text, date } = location.state;

  return (
    <>
      <Menu />
      <Headline text={title}/>
      <div className="openBlog-container">
        <div className="openBlog-left">
            <p className="openBlog-date">{date}</p>
        </div>
        <div className="openBlog-right">
              <img alt="blog part" src={img}/>
              <p className="small-text">{text}</p>
        </div>
      </div>
    </>
  );
};

export default OpenBlog;
