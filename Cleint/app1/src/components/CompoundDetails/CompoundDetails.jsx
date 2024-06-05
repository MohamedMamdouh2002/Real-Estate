import React, { useEffect } from 'react'
import style from './CompoundDetails.module.css'
import { useParams } from 'react-router-dom'
import axios from 'axios'
import { useQuery } from 'react-query'
import { CirclesWithBar } from 'react-loader-spinner'
import logo from '../../Assets/login-right.png'
import DeveloperDetails from '../DeveloperDetails/DeveloperDetails'

export default function CompoundDetails() {
  let {id}=useParams()
  function getCompoundDetails(id){
 return axios.get(`https://localhost:7203/api/Compound/${id}/GetById`)
//  console.log(data ,'data');
}
let {isLoading,data ,isError}=useQuery("getCompoundDetails",()=>getCompoundDetails(id))
let  res=data?.data
 console.log(res ,'data');
  return  <>
  {
    isLoading?
    <div className='flex justify-center items-center h-screen'>
    <CirclesWithBar
    height="300"
    width="300"
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
    :<>
    <section className="mt-20 pt-10  md:grid grid-cols-3 gap-1 mx-2">
      <div className="col-span-1 mx-auto ">
       <img src={res.masterPlanURL} className='w-96 h-96' alt="" />
      </div>
      <div className="col-span-2 mr-10 mt-2">
        <h1 className='text-2xl font-bold text-sky-900'>{res.name} |in {res.area} | By {res.developerName}</h1>
        <p className='my-8 text-lg font-medium w-5/6'>{res.description}</p>
        <div className="flex items-center gap-5">

        <img src={res.developerLogo} className='w-14 h-14 rounded-full border-gray-800 border-2' alt="" />
        <div className="">
          <p className=' text-lg font-bold'>
            {res.goverment}
          </p>
          <span className='text-xs text-sky-900 '>Prices Start From</span>
          <p className='font-bold -mt-1 text-xl'>{res.minPrice}554150 &emsp; &emsp; &emsp; 
            <span className='text-lg font-normal' >
            Max Price : 
            </span> 502121
            {res.maxPrice}
          
          </p>
        </div>
        </div>
        <div className=" mt-5">
          <h1 className='text-xl font-bold text-sky-900'>Amenities</h1>

          <div className="md:flex gap-3">
            {
              res.amenities.map((amenitie)=><>
                  <div key={amenitie.id} className="bg-white flex justify-start items-center gap-3  p-3 rounded-lg my-2">
                    <img src={amenitie.imgURL} className='w-6 h-6' alt="" />
                    <p className='text-xs'>{amenitie.name}</p>
                  </div>
              </>)
            }
          </div>
        </div>
        <div className=" payment mt-5">
          <h1 className='text-xl font-bold text-sky-900'>Payment Plans</h1>
          <div className="flex gap-4">
            {res.paymentPlans.map((pay)=><>

            <div key={pay.id} className="bg-white rounded-lg my-5 p-5 w-32 h-36 text-center  ">
              <p className='text-lg font-bold text-sky-900'>{pay.percentage}%</p>
              <p className="text-xs text-slate-500"> Down Payment</p>
              <p  className='text-lg'> {pay.years} Years</p>
              <p className="text-xs text-sky-900">Original Plan</p>
            </div>
            </>)}
          </div>
        </div>
        <DeveloperDetails/>

      </div>
  
    </section>

    </>
  }
  </>
}
