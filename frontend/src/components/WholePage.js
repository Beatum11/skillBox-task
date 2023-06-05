import React from "react";
import Menu from "./MenuPart/Menu";
import Main from "./Main";
import ProjectPart from "./projects/ProjectPart";
import ServicesPart from "./services/ServicesPart";
import BlogPart from "./blog/BlogPart";
import Contacts from "./Contacts";
import FooterItem from "./FooterItem";
import { Element } from "react-scroll";
import GuestMenu from '../components/MenuPart/GuestMenu';
import { useLocation } from "react-router-dom";

const WholePage = () => {

  const {state} = useLocation();
  const signedUp = state?.signedUp ?? false;
  const name = state?.name ?? '';
  return (
    <>
      {signedUp ? <GuestMenu name={name}/> : <Menu/>}

      <Element name="main">
        <Main />
      </Element>

      <Element name="projects">
        <ProjectPart />
      </Element>

      <Element name="services">
        <ServicesPart />
      </Element>

      <Element name="blog">
        <BlogPart />
      </Element>

      <Element name="contacts">
        <Contacts />
      </Element>

      <FooterItem />
    </>
  );
};

export default WholePage;
