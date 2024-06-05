import React from 'react'
  
export default function BackgroundColor(Component ,backgroundColor,borderRadius) {
  
  return function Bg(props){
return <>
<div style={{backgroundColor:backgroundColor,borderRadius:borderRadius}}>
<Component {...props}/>
</div>

</>

  }
}

