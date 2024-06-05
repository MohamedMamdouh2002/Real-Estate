// import React, { useState } from 'react'
// import { useFormik } from 'formik'
// import  axios from "axios";
// import * as Yup from "yup";
// import { RotatingLines } from 'react-loader-spinner';
// import toast, { Toaster } from 'react-hot-toast';
// import { useNavigate } from 'react-router-dom';

// export default function Register() {
//   let [err,seterr]=useState(null)
//  let navigate =useNavigate()
//   let [isLoading,setIsLoading]=useState(false)
//   async function sendData(values){
//     setIsLoading(true)
//     console.log("values222",values);
//     // const formData = new FormData();
//     // formData.append("FullName",values.FullName)
//     // formData.append("UserName",values.UserName)
//     // formData.append("Email",values.Email)
//     // formData.append("Password",values.Password)
//     // formData.append("PhoneNumber",values.PhoneNumber)
//     // formData.append("Age",values.Age)
//     let {data}= await axios.post(`https://localhost:7203/api/Auth/register`,values)
//     .catch((err)=>
//     {
//       setIsLoading(false)
//       toast(err.response.data
//         ,
//         {
//           icon: '❌',
//           style: {
//             borderRadius: '10px',
//             background: '#333',
//             color: '#fff',
//           },
//         }
//         );
//         console.log("values22258",values);
//       console.log("err",err.response.data)
      
//     }
//     )
//       if(data.messAge==="Sign up is succseded"){
//         console.log("values1",values);
//         toast(`✅ ${data.messAge}`)
//         setIsLoading(false)
//         navigate("/login")
//         console.log("response",data );
//       }
    
//   }
//   const phoneRegExp = /^((\\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/
//   let validationSchema=Yup.object({
//     FullName:Yup.string().required("Required ").max(100,"Less than 100").min(10,"Greater than 10"),
//     UserName:Yup.string().max(20,"Less than 3").min(3,"Greater than 3").required("Required "),
//     Email:Yup.string().email("Email is not valid").required("Required"),
//     PhoneNumber:Yup.string().matches(phoneRegExp,'Phone is not valid').required("Required"),
//     Password:Yup.string().matches(/^[A-Z][a-z0-9]{5,20}/,"Password format not valid").required("Required"),
//     Age:Yup.number().min(21,'Greater than 20').max(90,'Greater than 90').required("Required")
//   })
//  let formik =useFormik({
//   initialValues:{
//       FullName: "",
//       UserName: "",
//       Email: "",
//       Password: "",
//       PhoneNumber: "",
//       Age: ''
    
//   },
//   validationSchema,
//   onSubmit:sendData
//  })
//   return   <>
//   <Toaster/>
//       <div className="h-full bg-white py-2">
        
//         <h6 className=' sm:mt-6 sm:text-4xl text-xl ml-5 sm:ml-0  w-52 sm:w-full text-center'><span className=' font-semibold'>Welcome back</span> ,join us to ..... </h6>
//         <form onSubmit={formik.handleSubmit}>
//           <div className=" sm:grid sm:grid-cols-2 flex justify-between gap-2 mb-1x ">



//             <div className="sm:pl-12">
//               <label className='sm:font-semibold block sm:text-lg text-sm ' htmlFor="FullName">FullName :</label>
//               <input type="text"
//               className='md:w-full w-44 outline-none sm:p-1 p-0 rounded-md border'
//               onChange={formik.handleChange}
//               onBlur={formik.handleBlur} 
//               value={formik.values.FullName}
//               name='FullName'
//               id='FullName'/>
//               {formik.errors.FullName &&formik.touched.FullName? <div className='text-red-600 w-12/12 text-sm font-light'>{formik.errors.FullName}*</div>:""}
//             </div>
//             <div className=" sm:pe-12 pl-3   px-3  ">
//               <label className='sm:font-semibold block sm:text-lg text-sm' htmlFor="Age">Age :</label>
//               <input 
//               className='md:w-full w-12 outline-none  sm:p-1 p-0 rounded-md border  '
//               onChange={formik.handleChange}
//               onBlur={formik.handleBlur} 
//               value={formik.values.Age}
//               name='Age'
//               type="number"
//               id='Age'/>
//               {formik.errors.Age &&formik.touched.Age? <div className='text-red-600 sm:w-28 w-20 h-8 text-sm font-thin'>{formik.errors.Age}*</div>:""}
//             </div>
//           </div>

    

        
//             <div className="sm:px-12   ">
//               <label className='sm:font-semibold block sm:text-lg text-sm mb-1' htmlFor="UserName">UserName :</label>
//               <input type="text"
//               className='md:w-full w-64 outline-none  sm:p-1 p-0 rounded-md border  '
//               onChange={formik.handleChange}
//               onBlur={formik.handleBlur} 
//               value={formik.values.UserName}
//               name='UserName'
//               id='UserName'/>{formik.errors.UserName &&formik.touched.UserName? <div className='text-red-600 w-11/12 text-sm font-light'>{formik.errors.UserName}*</div>:""}
//             </div>


//             <div className="sm:px-12  ">
//               <label className='sm:font-semibold block sm:text-lg text-sm  mb-1' htmlFor="PhoneNumber">phone:</label>
//               <input type="text"
//               className='md:w-full w-64 outline-none  sm:p-1 p-0 rounded-md border  '
//               onChange={formik.handleChange}
//               onBlur={formik.handleBlur} 
//               value={formik.values.PhoneNumber}
//               name='PhoneNumber'
//               id='PhoneNumber'/>
//               {formik.errors.PhoneNumber &&formik.touched.PhoneNumber? <div className='text-red-600 w-12/12 text-sm font-light'>{formik.errors.PhoneNumber}*</div>:""}
//             </div>
//             <div className="sm:px-12  ">
//               <label className='sm:font-semibold block sm:text-lg text-sm ' htmlFor="Email">Email :</label>
//               <input type="text"
//               className='md:w-full w-64 outline-none  sm:p-1 p-0rounded-md border  '
//               onChange={formik.handleChange}
//               onBlur={formik.handleBlur} 
//               value={formik.values.Email}
//               name='Email'
//               id='Email'/>
//               {formik.errors.Email &&formik.touched.Email? <div className='text-red-600 w-52 text-sm font-light'>{formik.errors.Email}*</div>:""}
//             </div>

//             <div className="sm:px-12  ">
//               <label className='sm:font-semibold block sm:text-lg text-sm ' htmlFor="Password">Password :</label>
//               <input type="text"
//               className='md:w-full w-64 outline-none  sm:p-1 p-0 rounded-md border mt-1 '
//               onChange={formik.handleChange}
//               onBlur={formik.handleBlur} 
//               value={formik.values.Password}
//               name='Password'
//               id='Password'/>
//               {formik.errors.Password &&formik.touched.Password? <div className='text-red-600 w-52 text-sm font-light'>{formik.errors.Password}*</div>:""}
//             </div>

//           {isLoading?
//           <div className="flex justify-center sm:w-full w-64 mt-3">

//             <button type='submit' className='border px-12 py-3  sm:px-16 sm:py-4 text-white  bg-black rounded-lg'>

//             <RotatingLines
//               strokeColor="grey"
//               strokeWidth="5"
//               animationDuration="0.75"
//               width="50"
//               visible={true}
//               />
//             </button>
//           </div>

//           :
//           <div className="flex justify-center sm:w-full w-64 mt-3 ">

//           <button type='submit' className='border  px-12  py-3  sm:px-16 sm:py-4 text-white  bg-black rounded-lg'>Register</button>
//           </div>
//         }

//         </form>
//       </div>
 


//   </>
// }
import React, { useState } from 'react';
import { useFormik } from 'formik';
import axios from "axios";
import * as Yup from "yup";
import { RotatingLines } from 'react-loader-spinner';
import toast, { Toaster } from 'react-hot-toast';
import { NavLink, useNavigate } from 'react-router-dom';

export default function Register() {
  const [isLoading, setIsLoading] = useState(false);
  const nav = useNavigate();


  async function sendData(values) {
    setIsLoading(true);
    console.log("values222", values);

    try {
      const { data } = await axios.post(`https://localhost:7203/api/Auth/register`, values);
      console.log("response", data);

      if (data.message === "Sign up is succseded") {
      navigator(`/login`);
        // toast.success(`✅ ${data.message}`);
        setIsLoading(false);
      }
    } catch (err) {
      setIsLoading(false);
      toast.error(err.response.data, {
        icon: '❌',
        style: {
          borderRadius: '10px',
          background: '#333',
          color: '#fff',
        },
      });
      console.log("err", err.response.data);
    }
  }

  const phoneRegExp = /^((\\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/;
  const validationSchema = Yup.object({
    FullName: Yup.string().required("Required ").max(100, "Less than 100").min(10, "Greater than 10"),
    UserName: Yup.string().max(20, "Less than 3").min(3, "Greater than 3").required("Required "),
    Email: Yup.string().email("Email is not valid").required("Required"),
    PhoneNumber: Yup.string().matches(phoneRegExp, 'Phone is not valid').required("Required"),
    Password: Yup.string().matches(/^[A-Z][a-z0-9]{5,20}/, "Password format not valid").required("Required"),
    Age: Yup.number().min(21, 'Greater than 20').max(90, 'Greater than 90').required("Required")
  });

  const formik = useFormik({
    initialValues: {
      FullName: "",
      UserName: "",
      Email: "",
      Password: "",
      PhoneNumber: "",
      Age: ''
    },
    validationSchema,
    onSubmit: sendData
  });

  return (
    <>
      <Toaster />
      <div className="h-full bg-white py-2">
        <h6 className='sm:mt-6 sm:text-4xl text-xl ml-5 sm:ml-0 w-52 sm:w-full text-center'>
          <span className='font-semibold'>Welcome back</span>, join us to .....
        </h6>
        <form onSubmit={formik.handleSubmit}>
          <div className="sm:grid sm:grid-cols-2 flex justify-between gap-2 mb-1x">
            <div className="sm:pl-12">
              <label className='sm:font-semibold block sm:text-lg text-sm' htmlFor="FullName">FullName :</label>
              <input
                type="text"
                className='md:w-full w-44 outline-none sm:p-1 p-0 rounded-md border'
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                value={formik.values.FullName}
                name='FullName'
                id='FullName'
              />
              {formik.errors.FullName && formik.touched.FullName ? (
                <div className='text-red-600 w-12/12 text-sm font-light'>{formik.errors.FullName}*</div>
              ) : ""}
            </div>
            <div className="sm:pe-12 pl-3 px-3">
              <label className='sm:font-semibold block sm:text-lg text-sm' htmlFor="Age">Age :</label>
              <input
                className='md:w-full w-12 outline-none sm:p-1 p-0 rounded-md border'
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                value={formik.values.Age}
                name='Age'
                type="number"
                id='Age'
              />
              {formik.errors.Age && formik.touched.Age ? (
                <div className='text-red-600 sm:w-28 w-20 h-8 text-sm font-thin'>{formik.errors.Age}*</div>
              ) : ""}
            </div>
          </div>
          <div className="sm:px-12">
            <label className='sm:font-semibold block sm:text-lg text-sm mb-1' htmlFor="UserName">UserName :</label>
            <input
              type="text"
              className='md:w-full w-64 outline-none sm:p-1 p-0 rounded-md border'
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              value={formik.values.UserName}
              name='UserName'
              id='UserName'
            />
            {formik.errors.UserName && formik.touched.UserName ? (
              <div className='text-red-600 w-11/12 text-sm font-light'>{formik.errors.UserName}*</div>
            ) : ""}
          </div>
          <div className="sm:px-12">
            <label className='sm:font-semibold block sm:text-lg text-sm mb-1' htmlFor="PhoneNumber">phone:</label>
            <input
              type="text"
              className='md:w-full w-64 outline-none sm:p-1 p-0 rounded-md border'
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              value={formik.values.PhoneNumber}
              name='PhoneNumber'
              id='PhoneNumber'
            />
            {formik.errors.PhoneNumber && formik.touched.PhoneNumber ? (
              <div className='text-red-600 w-12/12 text-sm font-light'>{formik.errors.PhoneNumber}*</div>
            ) : ""}
          </div>
          <div className="sm:px-12">
            <label className='sm:font-semibold block sm:text-lg text-sm' htmlFor="Email">Email :</label>
            <input
              type="text"
              className='md:w-full w-64 outline-none sm:p-1 p-0rounded-md border'
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              value={formik.values.Email}
              name='Email'
              id='Email'
            />
            {formik.errors.Email && formik.touched.Email ? (
              <div className='text-red-600 w-52 text-sm font-light'>{formik.errors.Email}*</div>
            ) : ""}
          </div>
          <div className="sm:px-12">
            <label className='sm:font-semibold block sm:text-lg text-sm' htmlFor="Password">Password :</label>
            <input
              type="text"
              className='md:w-full w-64 outline-none sm:p-1 p-0 rounded-md border mt-1'
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              value={formik.values.Password}
              name='Password'
              id='Password'
            />
            {formik.errors.Password && formik.touched.Password ? (
              <div className='text-red-600 w-52 text-sm font-light'>{formik.errors.Password}*</div>
            ) : ""}
          </div>
          {isLoading ? (
            <div className="flex justify-center sm:w-full w-64 mt-3">
              <button type='submit' className='border px-12 py-3 sm:px-16 sm:py-4 text-white bg-black rounded-lg'>
                <RotatingLines
                  strokeColor="grey"
                  strokeWidth="5"
                  animationDuration="0.75"
                  width="50"
                  visible={true}
                />
              </button>
            </div>
          ) : (
            <div className="flex justify-center sm:w-full w-64 mt-3">
              <button type='submit' className='border px-12 py-3 sm:px-16 sm:py-4 text-white bg-black rounded-lg'>Register</button>
            </div>
          )}
        </form>
      </div>
    </>
  );
}
