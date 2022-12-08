import { Timeline, TimelineConnector, TimelineDot, TimelineItem, TimelineSeparator } from '@mui/lab'
import { createTheme, makeStyles, Paper, Typography } from '@mui/material'
import { styled } from '@stitches/react'
import React from 'react'
import {IoBuildOutline} from "react-icons/io5"
import TimelineContent from '@mui/lab/TimelineContent';
import {FcSalesPerformance,FcCurrencyExchange,FcIdea,FcWorkflow} from "react-icons/fc"
import Image from 'next/image'
import redFlag from "../../public/flag-48.png"
import styles from "./Roadmap.module.scss"



const TimeContainer = styled("div",{
    width:"100%",
    margin:"92px 0 0 auto",
    height:"660px",
    display:"flex",
    justifyContent:"center"
})

const BgHolder = styled("div",{
    width:"2400px",
    height:"836px",    
    opacity:"0.8",
    backgroundImage:`url("/home-banner-bg.png")`,
    backgroundSize:"cover",
    backgroundRepeat:   "no-repeat",
    backgroundPosition: "center center",
    top:"0px",
    zIndex:"-999",
    position:"fixed"
})

const TimeText = ({children}:any) =>
{
    return (
        <div  style={{ display: "inline-block",
        transform: "rotate(90deg)",
        textAlign: "center",
        minWidth: 50,
        backgroundColor:"transparent"}}>
            <Typography>{children}</Typography>
        </div>
    )
}


const Roadmap = () => {
    
  return (
    <TimeContainer>
        <BgHolder className={styles["anim"]}></BgHolder>
        <Timeline sx={{gap:"10px",flexDirection:"row",justifyContent:"center"}} position='alternate' >
            <TimelineItem sx={{flexDirection:"column",justifyContent:"center"}}>
                <TimelineSeparator sx={{gap:"10px",flexDirection:"row",width:"100%",justifyContent:"center",alignItems:"center"}}>
                    <TimelineConnector sx={{height:"2px",width:"19px"}}/>
                        <TimelineDot  variant="outlined" sx={{margin:"auto auto",backgroundColor:"white",borderColor:"transparent"}}   >
                            <FcIdea></FcIdea>
                        </TimelineDot>
                </TimelineSeparator>
                <TimelineContent sx={{textAlign: "left"}}>
                    
                </TimelineContent>
            </TimelineItem>

            <TimelineItem sx={{flexDirection:"column !important",justifyContent:"center"}}>
                <TimelineSeparator sx={{gap:"10px",flexDirection:"row",width:"100%",justifyContent:"center",alignItems:"center"}}>
                    <TimelineConnector sx={{height:"2px",width:"19px"}}/>
                        <TimelineDot  variant="outlined" sx={{margin:"auto auto",backgroundColor:"white",borderColor:"transparent"}}   >
                            <FcWorkflow></FcWorkflow>
                        </TimelineDot>
                </TimelineSeparator>
                <TimelineContent sx={{textAlign: "left"}}>
                    
                </TimelineContent>
            </TimelineItem>

            <TimelineItem sx={{flexDirection:"column !important",justifyContent:"center"}}>
                <TimelineSeparator sx={{gap:"10px",flexDirection:"row",width:"100%",justifyContent:"center",alignItems:"center"}}>
                    <TimelineConnector sx={{height:"2px",width:"19px"}}/>
                        <TimelineDot  variant="outlined" sx={{margin:"auto auto",backgroundColor:"white",borderColor:"transparent"}}   >
                            <FcSalesPerformance></FcSalesPerformance>
                        </TimelineDot>
                </TimelineSeparator>
                <TimelineContent sx={{textAlign: "left"}}>
                    
                </TimelineContent>
            </TimelineItem>

            <TimelineItem sx={{flexDirection:"column !important",justifyContent:"center"}}>
                <TimelineSeparator sx={{gap:"10px",flexDirection:"row",width:"100%",justifyContent:"center",alignItems:"center"}}>
                    <TimelineConnector sx={{height:"2px",width:"19px"}}/>
                        <TimelineDot  variant="outlined" sx={{margin:"auto auto",backgroundColor:"white",borderColor:"transparent"}}   >
                            <FcCurrencyExchange></FcCurrencyExchange>
                        </TimelineDot>
                </TimelineSeparator>
                <TimelineContent sx={{textAlign: "left"}}>
                    
                </TimelineContent>
            </TimelineItem>
            <TimelineItem sx={{flexDirection:"column !important",justifyContent:"center"}}>
                <TimelineSeparator sx={{gap:"10px",flexDirection:"row",width:"100%",justifyContent:"center",alignItems:"center"}}>
                    <TimelineConnector sx={{height:"2px",width:"19px"}}/>
                        <TimelineDot  variant="outlined" sx={{margin:"auto auto",backgroundColor:"white",borderColor:"transparent"}}   >
                        <Image src={redFlag} alt="redflag" width={16} height={16}></Image>
                        </TimelineDot>
                </TimelineSeparator>
                <TimelineContent sx={{textAlign: "left"}}>
                    
                </TimelineContent>
            </TimelineItem>
        </Timeline>
    </TimeContainer>
  )
}

export default Roadmap