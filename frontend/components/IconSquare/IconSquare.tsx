import React from 'react'
import styles from "./IconSquare.module.scss"

interface IconSquareProps
{
    leftColor?:string,
    rightColor?:string,
    icon:JSX.Element
}

const IconSquare = ({leftColor,rightColor,icon}:IconSquareProps) => {
  
    let _leftColor = leftColor || "#004BD2";
    let _rightColor = rightColor || "#009AE8";
    return (
    <div style={{ "--lColor": _leftColor,"--rColor":_rightColor} as React.CSSProperties} className={styles["container"]}>
        <div className={styles["icon"]}>
        </div>
        <div className={styles["glass"]}>
            <i>
            {icon}
            </i>
        </div>
        
    </div>
  )
}

export default IconSquare