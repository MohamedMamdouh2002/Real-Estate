import React from 'react'
import style from './DeveloperDetails.module.css'
import axios from 'axios'
import { useQuery } from 'react-query'

export default function DeveloperDetails() {
  function getDeveloperDetails(){
    return  axios.get(`https://localhost:7203/api/Developer`)
    
  }
  let {data}=useQuery("getDeveloperDetails",()=>getDeveloperDetails())
  let res =data?.data
  console.log(res ,"dev data");
  return<>
  <section>
    
  </section>

  </>
}
