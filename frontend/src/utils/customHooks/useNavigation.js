import { useNavigate } from "react-router-dom";

const UseNavigation = (destination) => {

    const navigate = useNavigate();
  
    const onNavigateHandler = () => {
      navigate(destination);
    }
  
    return { onNavigateHandler };
  }
  
  export default UseNavigation;