import React from "react";
import Accordion from "react-bootstrap/Accordion";
import { useGetServicesQuery } from "../../store/apiSlices/servicesApi";
import Headline from "../elements/Headline";
import '../../css-files/css-services/services.css';


const ServicesPart = () => {
  const { data: services, isLoading, isError, error } = useGetServicesQuery();

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>{error.message}</div>;
  }

  const finalServices = services.map((service) => {
    return (
      <Accordion.Item eventKey={service.id}>
        <Accordion.Header>{service.title}</Accordion.Header>
        <Accordion.Body className="my-accordion-body">{service.description}</Accordion.Body>
      </Accordion.Item>
    );
  });

  return (
    <div className="services-container con-size small-con">
      <Headline text={'Our Services:'}/>
      <Accordion defaultActiveKey="0">{finalServices}</Accordion>
    </div>
  );
};

export default ServicesPart;
