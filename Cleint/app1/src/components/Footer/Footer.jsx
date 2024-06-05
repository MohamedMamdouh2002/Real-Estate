import React, { useContext } from 'react'
import { UserContext } from '../../Context/UserContext'

export default function Footer() {
 let {userToken,setUserToken}= useContext(UserContext)
  return   <>
  {userToken? 
  <h1>Footer</h1>
  :""}
  </>
}
