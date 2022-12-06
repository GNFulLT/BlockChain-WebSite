import Image from 'next/image'
import React, { useEffect, useState } from 'react'
import styles from "./HomeBanner.module.scss"

interface Image
{
  path:string
}

let images : Image[] = [{path:"/emoji-img3.png"},{path:"/emoji-img2.png"},{path:"/emoji-img1_1.png"}]
let nextImage = 1;

const HomeBanner = () => {

  return (
    <div className={styles["container"]}>
      <div className={styles["images"]}>
        <img className={styles["img"]} src={`/mimg10.png`}></img>
        <img className={styles["icon"]}  src="/icon.png"></img>
      </div>
      <div style={{maxWidth:"50%"}}>
        Lorem, ipsum dolor sit amet consectetur adipisicing elit. Nobis officia cumque tempore voluptatem aliquid debitis voluptates adipisci quod saepe. Sint, reprehenderit repudiandae tenetur repellat odio cum accusamus? Sequi maxime quod eligendi vitae reprehenderit harum pariatur ut neque, soluta aliquam error fugiat suscipit quos incidunt hic repellendus cumque culpa alias earum?
      </div>
    </div>
  )
}

export default HomeBanner