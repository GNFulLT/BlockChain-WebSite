import React from 'react'
import IconSquare from '../IconSquare/IconSquare'
import styles from "./FeatureCard.module.scss"

interface FeatureCardProps
{
    headerText:string,
    content:string,
    icon:JSX.Element
}

const FeatureCard = ({headerText,content,icon}:FeatureCardProps) => {
  return (
    <div className={styles["container"]}>
        <div className={styles["mini-container"]}>
            <div className={styles["icon-box"]}>
                <IconSquare icon={icon}></IconSquare>
            </div>
            <div className={styles["content-box"]}>
                <h3>{headerText}</h3>
                <p>{content}</p>
            </div>
        </div>
    </div>
  )
}

export default FeatureCard