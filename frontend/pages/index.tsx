import Head from 'next/head'
import Image from 'next/image'
import styles from '../styles/Home.module.css'
import TauHeader ,{ LinkProps} from "../components/Header/Header"
import Roadmap from "../components/Roadmap/Roadmap"
import IconSquare from '../components/IconSquare/IconSquare'
import {CiWallet} from "react-icons/ci"
import FeatureCard from '../components/FeatureCard/FeatureCard'

export default function Home() {
  let link : LinkProps[] = [{link:"www.google",label:"Dashboard"},
  {link:"www.google.com",label:"Roadmap"},{link:"s",label:"Team"},{link:"b",label:"Goal"}];
  return (
    <>
    <TauHeader links={link}></TauHeader>
    <div style={{height:"100px"}}></div>
    <div style={{width:"100%",padding:"0 30px"}}>
    <FeatureCard headerText='zartirizortzort' content='xort zortafsa asfasfas asfasfwqfw asf safsaf wqf asdasd asdsa' icon={<CiWallet color='#efefef' size={40}/>}></FeatureCard>
    </div>
    <Roadmap></Roadmap>
    </>
  )
}
