import { Button } from '@mantine/core'
import React from 'react'
import styles from "./HomeBanner2.module.scss"

const HomeBanner2 = () => {
  return (
    <div className={styles["container"]}>
    <div className={styles["content"]}>
      <h1>Invest In Cryptocoin Way To Trade</h1>
      <span>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Nobis officia cumque tempore voluptatem aliquid debitis voluptates adipisci quod saepe. Sint, reprehenderit repudiandae tenetur repellat odio cum accusamus? Sequi maxime quod eligendi vitae reprehenderit harum pariatur ut neque, soluta aliquam error fugiat suscipit quos incidunt hic repellendus cumque culpa alias earum?</span>
      <Button></Button>
    </div>
    <img className={styles["img"]} src={`/banner-img.png`}></img>
    
  </div>  )
}

export default HomeBanner2