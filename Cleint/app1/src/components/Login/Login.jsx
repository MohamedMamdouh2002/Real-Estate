import React, { useContext, useState } from 'react'
import { useFormik } from 'formik'
import  axios from "axios";
import * as Yup from "yup";
import { RotatingLines } from 'react-loader-spinner';
import toast, { Toaster } from 'react-hot-toast';
import { Link, useNavigate } from 'react-router-dom';
import { UserContext } from '../../Context/UserContext';
import loginPhoto from '../../Assets/login.png'
import { Tab } from '@headlessui/react'
import  classNames  from 'classnames'
import Register from '../Register/Register';

export default function Login() {
 let navigate =useNavigate()
 let{setUserToken}=useContext(UserContext)
  let [isLoading,setIsLoading]=useState(false)
  // let [err,seterr]=useState(null)
  async function sendData(values){
    setIsLoading(true)  
    console.log("values",values);
    // const formData = new FormData();
    // formData.append("email",values.email)
    // formData.append("password",values.password)

    let {data}= await axios.post(`https://localhost:7203/api/Auth/token`,values)
    .catch((err)=>
    {
      toast(err.response.data
        ,
    {
      icon: '❌',
      style: {
        borderRadius: '10px',
        background: '#333',
        color: '#fff',
      },
    }
  );      console.log("err",  )
      setIsLoading(false)
      
    }
      )
      if(data.message==="sign in success"){
        localStorage.setItem("userToken",data.token)
        setUserToken(data.token)
        toast(`✅ ${data.message}`)
        setIsLoading(false)
        console.log("response",data);
        navigate("/")
      }
    
  }
  let validationSchema=Yup.object({
    email:Yup.string().email("Email Format is not valid").required("Email is required"),
    password:Yup.string().matches(/^[A-Z][a-z0-9]{5,20}/,"password format not valid").required("Password is required")
    // repassword:Yup.string().oneOf([Yup.ref("password")]).required("rePassword is required")
  })
 let formik =useFormik({
  initialValues:{
     
      email: "",
      password: ""
   
    
  },
  validationSchema,
  onSubmit:sendData
 })
  return   <>
  <Toaster/>

   <div className="bg-white w-screen h-screen  ">
    <div className="grid grid-cols-8">
      <div className=" hidden sm:block col-span-3 ">
      <img src={loginPhoto} alt="loginPhoto" className='w-full h-screen p-2 rounded-3xl' />
        
      </div>
      <div className="   w-full col-span-4 flex flex-col  ">

        <div className=" px-2 py-2 sm:px-0"> 
            <div className='mt-28 sm:w-full w-72 sm:ms-0 sm:px-3 ms-3 '>
              <div className="rounded-xl h-96 pt-5 ">
              
                    <div className="md:ms-20" > 
                    <div className="">

                      <h6 className='mb-2 mt-6  sm:text-4xl font-semibold ml-5 sm:ml-0  w-52 sm:w-full text-center '>Log<span className='text-slate-500'>in</span></h6>
                        </div>
                      <form onSubmit={formik.handleSubmit}>  
                      <div className="logEmail mb-5 sm:px-7 px-2 ">
                        <label htmlFor="email" className='sm:font-semibold block sm:text-lg text-sm mb-2'>Email </label>
                        <input type="text"
                        className='md:w-full w-64 outline-none  sm:p-1 p-0   border border-l-0 border-b-2 border-t-0 border-r-0 border-gray-500 bg-transparent  '
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur} 
                        value={formik.values.email}
                        name='email'
                        id='email'/>
                        {formik.errors.email&&formik.touched.email? <div className='text-red-600 w-48'>{formik.errors.email}*</div>:""}

                      </div>
                        

                      <div className="logPass mb-6 sm:px-7 px-2">

                        <label htmlFor="password "className='sm:font-semibold block sm:text-lg text-sm mb-2' >password </label>
                        <input type="text"
                        className='md:w-full w-64 outline-none  sm:p-1 p-0     border border-l-0 border-b-2 border-t-0 border-r-0 border-gray-500 bg-transparent  '
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur} 
                        value={formik.values.password}
                        name='password'
                        id='password'/>
                        {formik.errors.password &&formik.touched.password? <div className='text-red-600 w-48'>{formik.errors.password}*</div>:""}
                        <Link>
                        <h2 className="text-right md:ms-12 text-blue-600">Forgot your password?</h2>
                        </Link>
                        </div>

                        {isLoading?
                        <div className="flex justify-center sm:w-full w-72">

                          <button type='submit' className='border  px-8 py-2 text-white  bg-black rounded-lg'>

                      <RotatingLines
                        strokeColor="grey"
                        strokeWidth="5"
                        animationDuration="0.75"
                        width="50"
                        visible={true}
                        />
                      </button>
                        </div>
                        :
                        <div className="sm:flex sm:justify-center pl-16 sm:w-full  w-72 ">

                        
                        <button type='submit' className='border px-12 py-3   sm:px-11 sm:py-4 text-white  bg-slate-500 hover:bg-slate-900 hover:rounded-xl duration-150 rounded-md '>Log in</button>
                        
                        </div>
                      }
                      <h1 className='text-center md:ms-12 mt-4'>
                      Not a member yet?
                      <Link to="/register" className='ms-1 text-blue-600'>
                        Register
                     </Link>
                      </h1> 
                      </form>
              
                    </div>
              </div>
            </div>
        </div>
      </div>
      
    </div>
   </div>
  
  </>
}
