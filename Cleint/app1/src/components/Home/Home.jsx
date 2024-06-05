import React from 'react'
import photo from '../../Assets/headerPhoto1.png'
import specialOffers from '../../Assets/specialOffers.png'
import MainSlider from '../MainSlider/MainSlider'
import  style from'./Home.module.css'
import Search from '../Search/Search'
import DeveloperSlider from '../DeveloperSlider/DeveloperSlider'
// import BackgroundColor from '../Bg'


export default function Home() {
  // const  Bg=BackgroundColor(Search,"red","5px")
  return   <>
  <header className='pt-16'>
    <div className={style.bgheader}>
      <div className="h-full flex justify-start items-center ">
        <div className=" bg-slate-700 bg-opacity-50 rounded-e-md  p-5 ">

        <h1 className='font-bold md:text-3xl  ms-6 text-white '>Find Your New Home</h1>
        <h1 className='font-bold md:text-md text-sm ms-6 text-white line-count mt-4 '>We will help you find your new apartment anywhere you want at very special prices. <p>
           Just browse now
          </p>
           </h1>
        </div>
      </div>
      </div> 
  </header>

  <section className='mt-10'>
    <div className=" bg-slate-700 bg-opacity-90 w-2/3 m-auto p-4 rounded-lg flex items-center gap-2">

      <img
        className='w-48 rounded-md md:block hidden'
       src={specialOffers}
       alt="" />
       <div className="text-white  ms-5">

       <h2 className='font-medium md:text-4xl mb-2'>Limited Time 
        <span className='text-orange-600 ms-2'>
          Offers
        </span>
        </h2>
       <h2 className='font-medium text-lg'>Reserve Your Unit Now</h2>
       </div>

    </div>
  </section>
  <MainSlider />
  <DeveloperSlider/>
  
  </>
}
