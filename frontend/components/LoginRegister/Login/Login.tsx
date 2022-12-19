import React, { useRef, useState } from 'react'
import { PasswordInput, TextInput } from '@mantine/core';
import { Button } from '@mantine/core';
import styles from "./Login.module.scss"
import { useMdQuery } from '../../../lib/hooks/Query';
import { useAuth } from '../../../lib/hooks/Auth';
import Router from 'next/router';
import { createTheme, LinearProgress, ThemeProvider } from '@mui/material';

interface LoginProps
{
  onClose:() => any
}

const progressTheme = createTheme({
  components:
  {
    MuiLinearProgress:{
      styleOverrides:{
        barColorPrimary:{
          backgroundColor:"rgb(204,81,249)"
        }
      }
    }
  }
})

const Login = ({onClose}:LoginProps) => {
    const {auth,signIn,signOut} = useAuth();
    const [isSigning,setIsSigning] = useState(0);
    const { mdQuery } =  useMdQuery();
    const emailRef = useRef(null);
    const passRef = useRef(null);
    const submitHandler = async (e:React.FormEvent<HTMLFormElement>) => {
      e.preventDefault();
      setIsSigning(1);
      // @ts-expect-error
      const email = emailRef.current.value;
      // @ts-expect-error
      const password = passRef.current.value;
      signIn(email,password)
      .then(() => {
        Router.push("/");
        onClose();
      })
      .catch((ex:any) => {
      })
      .finally(() => {
        setIsSigning(0);
        setTimeout(() => {
        },2000)
      })
    }

  return (
    <form onSubmit={submitHandler} className={styles["container"]}>
      <TextInput ref={emailRef} styles={{
              root:
              {                
                width:`${mdQuery ? "225px" : "150px"}`,
                    minHeight:`${mdQuery ? "40px" : "25px"}`,
                    height:`${mdQuery ? "40px" : "25px"}`,
              },
              wrapper:
              { 
                width:`${mdQuery ? "225px" : "150px"}`,
                    minHeight:`${mdQuery ? "40px" : "25px"}`,
                    height:`${mdQuery ? "40px" : "25px"}`,
              },
              input:
              {
                width:`${mdQuery ? "225px" : "150px"}`,
                    minHeight:`${mdQuery ? "40px" : "25px"}`,
                    height:`${mdQuery ? "40px" : "25px"}`,
              },             
              label:
              {
                fontSize:`${mdQuery ? "12px" : "10px"}`,               
              }
            }} type='email' size="xs" label="Email" mb={mdQuery ? 10 : 0}></TextInput>
            <PasswordInput
            ref={passRef}
            mt={20}
            styles={{
                root:
                {                
                    width:`${mdQuery ? "225px" : "150px"}`,
                    minHeight:`${mdQuery ? "40px" : "25px"}`,
                    height:`${mdQuery ? "40px" : "25px"}`,
                },
                wrapper:
                { 
                    width:`${mdQuery ? "225px" : "150px"}`,
                    minHeight:`${mdQuery ? "40px" : "25px"}`,
                    height:`${mdQuery ? "40px" : "25px"}`,
                },
                input:
                {
                    width:`${mdQuery ? "225px" : "150px"}`,
                    minHeight:`${mdQuery ? "40px" : "25px"}`,
                    height:`${mdQuery ? "40px" : "25px"}`,
                },             
                label:
                {
                  fontSize:`${mdQuery ? "12px" : "10px"}`,               
                },
              innerInput:
              {
                width:`${mdQuery ? "225px" : "150px"}`,
                minHeight:`${mdQuery ? "30px" : "25px"}`,
                height:`${mdQuery ? "37.5px" : "25px"}`,
                fontSize:`${mdQuery ? "12px" : "10px"}`,               
                "::placeholder":{
                    fontSize:`${mdQuery ? "12px" : "10px"}`,               
                } 
              },
             
            }}
            label="Password"
            />
      <ThemeProvider theme={progressTheme}>
        <LinearProgress sx={{
          width:"100px",
          marginTop:`${mdQuery ? "45px" : "40px"}`,
          marginBottom:`${mdQuery ? "12px" : "8px"}`,
          backgroundColor:"transparent",
          opacity:isSigning
        }}  />
      </ThemeProvider>
      <Button type='submit' sx={{
    width:`${mdQuery ? "250px":"175px"}`,
    height:`${mdQuery ? "40px":"25px"}`,
  }}  styles={{
    label:{
        padding:`${mdQuery ? "0" : "0 0 2.5px 0"}`,
        fontSize:`${mdQuery ? "15px" : "12px"}`,

    }
  }}>
            Login
      </Button>
    </form>
  )
}

export default Login