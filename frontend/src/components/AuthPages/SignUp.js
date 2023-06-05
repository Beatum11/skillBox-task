import React, { useState } from "react";
import Form from "react-bootstrap/Form";
import { Button } from "react-bootstrap";
import Headline from "../elements/Headline";
import { useSignUpUserMutation } from "../../store/apiSlices/signUpApi";
import { useNavigate } from 'react-router-dom';
import "../../css-files/css-auth-pages/sign-up.css";

const SignUp = () => {

  const [signUpUser] = useSignUpUserMutation();
  const navigate = useNavigate();

  const [newUser, setNewUser] = useState({
    UserName: "",
    Email: "",
    Password: "",
    ConfirmPassword: "",
  });

  const handleChange = (e) => {
    setNewUser({
      ...newUser,
      [e.target.id]: e.target.value,
    });
  };


  const handleSubmit = async (e) => {

    e.preventDefault();
    try {
      const response = await signUpUser(newUser);
      if (response) {
        navigate('/', {state: {
          signedUp: true,
          name: response.data.name
        }});
      }
    } catch (error) {
      console.log(error);
    }
  };
  
 

 
  return (
    <>
      <Headline text={"Create an account"} />
      <div className="signUp-container con-size">
        <Form onSubmit={handleSubmit}>
          <Form.Group className="mb-3">
            <Form.Label>Name: </Form.Label>
            <Form.Control
              id="UserName"
              type="text"
              placeholder="Some name"
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Email address: </Form.Label>
            <Form.Control
              id="Email"
              type="email"
              placeholder="name@example.com"
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Your password: </Form.Label>
            <Form.Control
              id="Password"
              type="password"
              onChange={handleChange}
            />
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Confirm password: </Form.Label>
            <Form.Control
              id="ConfirmPassword"
              type="password"
              onChange={handleChange}
            />
          </Form.Group>
          <Button type="submit" className="signUp-button">Submit</Button>
        </Form>
      </div>
    </>
  );
};

export default SignUp;
