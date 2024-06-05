import logo from './logo.svg';
import './App.css';
import Layout from './components/Layout/Layout';
import Login from './components/Login/Login';
import Register from './components/Register/Register';
import Home from './components/Home/Home';
import ContactUs from './components/ContactUs/ContactUs';
import AboutUs from './components/AboutUs/AboutUs';
import Notfound from './components/Notfound/Notfound';
import WishList from './components/WishList/WishList';
import Search from './components/Search/Search';
import { RouterProvider, createBrowserRouter } from 'react-router-dom';
import UserContextProvider from './Context/UserContext';
import Gurad from './components/Gurad/Gurad';
import CompoundDetails from './components/CompoundDetails/CompoundDetails';

const routers=createBrowserRouter([
  {path:"",element:<Layout/>,children:[
    {index:true,element:<Gurad><Home/></Gurad>},
    {path:'aboutUs',element:<Gurad><AboutUs/></Gurad>},
    {path:'compoundDetails/:id',element:<Gurad><CompoundDetails/></Gurad>},
    {path:'contactUs',element:<Gurad><ContactUs/></Gurad>},
    {path:'wishList',element:<Gurad><WishList/></Gurad>},
    {path:'search',element:<Gurad><Search/></Gurad>},
    {path:'register',element:<Register/>},
    {path:'login',element:<Login/>},
    {path:'*',element:<Notfound/>},
  ]}
])
function App() {
  return <>
  <UserContextProvider>

<RouterProvider router={routers}/>

  </UserContextProvider>
  </>
}

export default App;
