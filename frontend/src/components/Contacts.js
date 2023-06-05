import React from "react";
import telegramImg from "../icons/telegram.png";
import pinterestImg from "../icons/pinterest.png";
import youtubeImg from "../icons/youtube.png";
import Headline from "./elements/Headline";
import "../css-files/contacts.css";

const Contacts = () => {
  return (
    <>
      <Headline text={"Contacts:"} />
      <div className="contacts-container">
        <div className="contacts-left-part">
          <p className="dark-skill-color">
            Novel Ideas Inc. 123
            <br />
            Imagination Lane Creativity City,
            <br />
            45678 Fantasy Country
          </p>
          <ul className="socials">
            <li>
              <img alt="telegram" src={telegramImg} />
            </li>
            <li>
              <img alt="pinterest" src={pinterestImg} />
            </li>
            <li>
              <img alt="youtube" src={youtubeImg} />
            </li>
          </ul>
        </div>
        <img
          className="contacts-img"
          alt="map"
          src="https://images.unsplash.com/photo-1476973422084-e0fa66ff9456?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1441&q=80"
        />
      </div>
    </>
  );
};

export default Contacts;
