import React from 'react'
import styles from "./Features.module.scss"
import FeatureCard from "../FeatureCard/FeatureCard"
import { styled } from '@stitches/react'


export interface FeatureType
{
    text:string,
    icon:JSX.Element,
    key:string
}

interface FeaturesProps
{
    features:FeatureType[]
}

const BgHolder = styled("div",{
    width:"2400px",
    height:"836px",    
    opacity:"0.8",
    backgroundImage:`url("/images/bg2-nobgg.jpg")`,
    backgroundSize:"cover",
    backgroundRepeat:   "no-repeat",
    backgroundPosition: "center center",
    position:"absolute",
    zIndex:"-999"
})

const Features = ({features}:FeaturesProps) => {
  
    const list = features.map(feature => {
        return(
            <FeatureCard key={feature.key}  headerText={feature.text} icon={feature.icon}></FeatureCard>

        )
    });
    return (
        <div className={styles["container"]}>
            {list}
       </div> 
  )
}

export default Features