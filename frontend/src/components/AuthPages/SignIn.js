import React from "react";
import Form from "react-bootstrap/Form";
import { Button } from "react-bootstrap";
import Headline from "../elements/Headline";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import {useSignInUserMutation} from '../../store/apiSlices/signInApi';
import "../../css-files/css-auth-pages/sign-in.css";
import "../../css-files/css-auth-pages/sign-up.css";

const SignIn = () => {

  const [signInUser] = useSignInUserMutation();
  const navigate = useNavigate();
  const [newUser, setNewUser] = useState({
    Email: "",
    Password: "",
    RememberMe: false,
  });

  const handleChange = (e) => {
    const value = e.target.id === 'RememberMe' ? e.target.checked : e.target.value;
    setNewUser({
      ...newUser,
      [e.target.id]: value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    console.log(newUser);
    try {
      const response = await signInUser(newUser);
      console.log(response);
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
      <Headline text={"SignIn to your account"} />
      <div className="signUp-container con-size">
        <Form onSubmit={handleSubmit}>
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

          <Form.Group className="mb-3 signIn-remember">
            <Form.Label>Remember me:</Form.Label>
            <Form.Check
              id="RememberMe"
              aria-label="option 1"
              onChange={handleChange}
              checked={newUser.RememberMe}
            />
          </Form.Group>
          <Button type="submit" className="signUp-button">Submit</Button>
        </Form>
      </div>
    </>
  );
};

export default SignIn;
