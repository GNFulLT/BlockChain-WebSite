import React from "react"

export interface NavCompProps
{
  str:string
}


const NavComp = ({str}:NavCompProps) => {
  return (
    <div>{str}</div>
  )
}

export default NavComp