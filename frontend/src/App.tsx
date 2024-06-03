import { Outlet } from 'react-router';
import './App.css';
import "react-toastify/dist/ReactToastify.css";
import Navbar from './Components/Navbar/Navbar';
import { ToastContainer } from 'react-toastify';
import { UserProvider } from './Context/useAuth'; // App only works when user is logged in, hence the UserProvider wrapper


function App() {
  return (
    <>
      <UserProvider>
        <Navbar /> 
        <Outlet />
        <ToastContainer />
      </UserProvider>
    </>
  );
}

export default App;
