import React, { useState } from 'react'
import axios from 'axios'
import { useQuery } from 'react-query'
import { Swiper, SwiperSlide } from 'swiper/react';
import { Autoplay,Navigation, Pagination, Scrollbar,breakpoints} from 'swiper/modules';
import 'swiper/css';
import 'swiper/css/navigation';
import 'swiper/css/pagination';
import 'swiper/css/scrollbar';
import { CirclesWithBar } from 'react-loader-spinner';
import { Link } from 'react-router-dom';

export default function MainSlider() {
//  const[isLoading,setIsLoading]=useState(false)
  function getCompound(){
   return axios.get('https://localhost:7203/api/Compound/GetAll')
  }
  var{data,isLoading}=useQuery('getCompound',()=>getCompound())
  let response=data?.data
  // console.log(isLoading,"sss");

  console.log(response);
  // function getCompoundId(id){
  //  return axios.get(`https://localhost:7203/api/Compound/${id}/GetById`)
  // }
  // var{data}=useQuery('getCompound',()=>getCompoundId())
  // let s=data?.data

  // console.log(s,"ss");
  
  return   <>
  {isLoading?
  <div className='flex justify-center mt-5 '>

  <CirclesWithBar
  height="100"
  width="100"
  color="#4fa94d"
  outerCircleColor="#4fa94d"
  innerCircleColor="#4fa94d"
  barColor="#4fa94d"
  ariaLabel="circles-with-bar-loading"
  wrapperStyle={{}}
  wrapperClass=""
  visible={true}
  />
  </div>
  :
    <div className=" w-11/12 m-auto mt-10">
      <h2 className='my-3 text-xl font-bold'>Top Compounds
</h2>
         <Swiper
        //  className=' flex '
      modules={[Autoplay,Navigation, Pagination, Scrollbar]}
      spaceBetween={10}
      slidesPerView={4}
      slidePrevClass='2'
      autoplay={{stopOnLastSlide:false}}
      navigation
      scrollbar={{ draggable: true}}
      breakpoints={{
        0:{
          slidesPerView:1,
        },
        300:{
          slidesPerView:2,
        },
        520:{
          slidesPerView:3,
        },
        920:{
          slidesPerView:5,
        },
      }}
      // onSlideChange={() => console.log('slide change')}
      // onSwiper={(swiper) => console.log(swiper)}
    >
      {response?.map((com)=><>
      <SwiperSlide key={com.id} className='relative '>
      <Link to={`compoundDetails/${com.id}`}>
          <img  src={com.masterPlanURL} className=' mb-6 w-80 h-40 rounded-md ' alt="" />
          <div className="lay absolute bottom-0 right-0 top-28 left-0 bg-gradient-to-t bg-black bg-opacity-30 mb-6  rounded-md flex justify-center items-center hover:bg-slate-700 hover:bg-opacity-50">
          <h2 className='text-lg text-center font-bold text-white'>{com.name}</h2>
          </div>
      

      </Link>
      </SwiperSlide>
   
      
      
      </>)}
    </Swiper>
    </div>

  }
  </>
}



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
