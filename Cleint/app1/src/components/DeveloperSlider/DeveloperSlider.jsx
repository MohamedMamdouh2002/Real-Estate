import React, { useState } from 'react'
import axios from 'axios'
import { useQuery } from 'react-query'
import { Swiper, SwiperSlide } from 'swiper/react';
import { Autoplay,Navigation, Pagination, Scrollbar} from 'swiper/modules';
import 'swiper/css';
import 'swiper/css/navigation';
import 'swiper/css/pagination';
import 'swiper/css/scrollbar';
import { CirclesWithBar } from 'react-loader-spinner';
import { Link } from 'react-router-dom';
export default function DeveloperSlider() {
  function getDeveloperSlider(){
    return axios.get(`https://localhost:7203/api/Developer`)
  }
  let{data}=useQuery("getDeveloperSlider",()=>getDeveloperSlider())
  console.log(data?.data ,"sssssslll");
  let response=data?.data
  return   <>


    <div className=" w-11/12 m-auto mt-10">
      <h2 className='my-3 text-xl font-bold'>Developers
</h2>
         <Swiper
        //  className=' flex '
      modules={[Autoplay,Navigation, Pagination, Scrollbar]}
      spaceBetween={50}
      slidesPerView={4}
      slidePrevClass='2'
      autoplay={{stopOnLastSlide:false}}
      navigation
      scrollbar={{ draggable: true}}
      // onSlideChange={() => console.log('slide change')}
      // onSwiper={(swiper) => console.log(swiper)}
    >
      {response?.map((com)=><>
      <SwiperSlide key={com.id} className='relative '>
      <Link to={`compoundDetails/${com.id}`}>
          <img  src={com.logoURL} className=' mb-6 w-80 h-40 rounded-md ' alt="" />
          <div className="lay absolute bottom-0 right-0 top-28 left-0 bg-gradient-to-t bg-black bg-opacity-30 mb-6  rounded-md flex justify-center items-center hover:bg-slate-700 hover:bg-opacity-50">
          <h2 className='text-lg text-center font-bold text-white'>{com.name}</h2>
          </div>
      

      </Link>
      </SwiperSlide>
   
      
      
      </>)}
    </Swiper>
    </div>

  
  </>
}
