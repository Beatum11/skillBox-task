import React from "react";
import { Navbar, Nav } from "react-bootstrap";
import Button from "react-bootstrap/Button";
import { Link } from "react-scroll";
import { useNavigate } from "react-router-dom";
import { useSignOutUserMutation } from "../../store/apiSlices/signOutApi";
import "../../css-files/menu.css";

const GuestMenu = ({ name }) => {
  const [signOutUser] = useSignOutUserMutation();
  const navigate = useNavigate();

  const onSignOutHandler = async (e) => {
    e.preventDefault();
    try {
      var response = await signOutUser();
      if (response) {
        navigate("/adminPanel", {
          state: {
            signedUp: false,
          },
        });
      }
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <Navbar className="side-padding" bg="light" expand="lg" variant="light">
      <Navbar.Brand className="brand large-text" href="https://example.com">
        Skill-Prof.
      </Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="ms-auto side-padding">
          <Nav.Link className="small-text" href="https://example.com">
            <Link to="main" smooth={true} duration={200}>
              Main
            </Link>
          </Nav.Link>

          <Nav.Link className="small-text" href="https://example.com">
            <Link to="projects" smooth={true} duration={200}>
              Projects
            </Link>
          </Nav.Link>

          <Nav.Link className="small-text" href="https://example.com">
            <Link to="services" smooth={true} duration={200}>
              Services
            </Link>
          </Nav.Link>

          <Nav.Link className="small-text" href="https://example.com">
            <Link to="blog" smooth={true} duration={200}>
              Blog
            </Link>
          </Nav.Link>

          <Nav.Link className="small-text" href="https://example.com">
            <Link to="contacts" smooth={true} duration={200}>
              Contacts
            </Link>
          </Nav.Link>

          <Nav.Link className="small-text" href="https://example.com">
            <Link to="contacts" smooth={true} duration={200}>
              Contacts
            </Link>
          </Nav.Link>

          <Nav.Link className="small-text">
            <Button
              onClick={onSignOutHandler}
              className="menu-button"
              size="sm">
              Sign Out
            </Button>
          </Nav.Link>
        </Nav>
      </Navbar.Collapse>
    </Navbar>
  );
};

export default GuestMenu;
