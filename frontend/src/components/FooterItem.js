import React from "react";
import { Link } from "react-scroll";
import "../css-files/footer.css";

const FooterItem = () => {
  return (
    <footer className="footer-container light-skill-backColor">
      <p className="dark-skill-color">2023</p>
      <ul>
        <li>
          <Link to="main" smooth={true} duration={200}>
            <p>Main</p>
          </Link>
        </li>
        
        <li>
          <Link to="projects" smooth={true} duration={200}>
            <p>Projects</p>
          </Link>
        </li>

        <li>
          <Link to="services" smooth={true} duration={200}>
            <p>Services</p>
          </Link>
        </li>

        <li>
          <Link to="blog" smooth={true} duration={200}>
            <p>Blog</p>
          </Link>
        </li>

        <li>
          <Link to="contacts" smooth={true} duration={200}>
            <p>Contacts</p>
          </Link>
        </li>
      </ul>
    </footer>
  );
};

export default FooterItem;
