import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import WholePage from "./components/WholePage";
import OpenProject from "./components/projects/OpenProject";
import OpenBlog from './components/blog/OpenBlog';
import SignIn from './components/AuthPages/SignIn';
import SignUp from './components/AuthPages/SignUp';
import AdminPanel from "./components/adminPart/AdminPanel";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route exact path="/" element={<WholePage />} />
        <Route exact path="/project" element={<OpenProject/>} />
        <Route exact path="/blogPost" element={<OpenBlog/>} />
        <Route exact path="/signIn" element={<SignIn/>} />
        <Route exact path="/signUp" element={<SignUp/>} />
        <Route exact path="/adminPanel" element={<AdminPanel/>} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
