import React, { JSXElementConstructor, useEffect, useRef, useState } from 'react'
import styles from "./LoginCard.module.scss"
import ReactDOM from "react-dom"
import Login from "./Login/Login"
import Register from './Register/Register'
import { styled } from '@stitches/react'

interface LoginCardProps
{
    onClose:() => any
    isShow:boolean
}



const LoginCard = ({onClose,isShow}:LoginCardProps) => {
    const spanRef = useRef<HTMLSpanElement>(null);
    const cardRef = useRef<HTMLDivElement>(null);
    const[isLogin,setIsLogin] = useState(true);
    const loginHandler = () =>
    {
      if(spanRef.current?.classList.contains(styles["register"]))
      {
        spanRef.current?.classList.remove(styles["register"]);
        cardRef.current?.classList.remove(styles["registerCard"])
        setIsLogin(true);
      }
    }
  
    const registerHandler = () =>
    {
      if(!spanRef.current?.classList.contains(styles["register"]))
      {
        spanRef.current?.classList.add(styles["register"]);
        cardRef.current?.classList.add(styles["registerCard"])
        setIsLogin(false);
      }
    }
    
    const closeHandler = (e:React.MouseEvent<HTMLElement>) => 
    {
        // @ts-expect-error
        if(e.target.id == "outside")
        {
            onClose()
            setIsLogin(true)
        }
    }
  const ref = useRef<Element | null>(null)
  useEffect(() => {
    ref.current = document.querySelector<HTMLElement>("#modal-root")
  }, [])
  let LoginModal = isShow ? (
    <div onClick={closeHandler} id="outside" className={styles["container"]}>
        <div ref={cardRef} className={styles["card"]}>
            <div className={styles["bgholder"]}></div>
            <div className={styles["top-side"]}>
                <img className={styles["logo"]} src="/icon.png" alt="Logo"></img>
                <div className={styles["comp-name"]}>Axo Token</div>
                <div className={styles["login-register-container"]}>
                    <div className={styles["login-register-mini-container"]}>
                        <div style={{cursor:"pointer",color:"white"}} onClick={loginHandler}>Login</div>
                        <span className={styles["login-register-border"]}></span>
                        <div  style={{cursor:"pointer",color:"white"}} onClick={registerHandler}>Register</div>
                    </div>
                    <span ref={spanRef}></span>
                </div>
            </div>
            <div className={styles["bottom-side"]}>
                { isLogin ? <Login onClose={onClose}></Login> : <Register></Register> }
            </div>
        </div>
    </div>
  ) : (<></>)

  if(ref.current)
    return ReactDOM.createPortal(LoginModal,ref.current)   

  return <></>
}

export default LoginCard