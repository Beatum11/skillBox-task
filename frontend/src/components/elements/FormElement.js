import React from "react";
import { Form, Button } from "react-bootstrap";
import "../../css-files/css-elements/form-element.css";

const FormElement = () => {
  return (
    <div>
      <Form className="form-container">
        <Form.Group className="mb-3" controlId="Name">
          <Form.Label>Name</Form.Label>
          <Form.Control type="text" placeholder="Your Name" />
        </Form.Group>
        
        <Form.Group className="mb-3" controlId="Number">
          <Form.Label>Phone Number</Form.Label>
          <Form.Control type="number" placeholder="+1234" />
        </Form.Group>
        
        <Form.Group className="mb-3" controlId="Email">
          <Form.Label>Email address</Form.Label>
          <Form.Control type="email" placeholder="name@example.com" />
        </Form.Group>
        
        <Form.Group className="mb-3" controlId="Message">
          <Form.Label>Message</Form.Label>
          <Form.Control as="textarea" rows={3} />
        </Form.Group>

        <Form.Group className="mb-3">
          <Button className="dark-skill-backColor border-view" type="submit">
            Submit a request
          </Button>
        </Form.Group>
      </Form>
    </div>
  );
};

export default FormElement;
