import TauHeader ,{ LinkProps} from "../components/Header/Header"
import Roadmap from "../components/Roadmap/Roadmap"
import {CiWallet,CiMoneyBill} from "react-icons/ci"
import Features, { FeatureType } from '../components/Features/Features'
import {GiRecycle} from "react-icons/gi"
import {FaExpeditedssl} from "react-icons/fa"
import {FiClock} from "react-icons/fi"
import {AiOutlineSafety} from "react-icons/ai"
import {HiOutlineTicket} from "react-icons/hi"
import {RiSecurePaymentLine} from "react-icons/ri"
import HomeBanner from "../components/HomeBanner/HomeBanner"
import HomeBanner2 from "../components/HomeBanner2/HomeBanner2"

export default function Home() {
  let link : LinkProps[] = [{link:"www.google",label:"Dashboard"},
  {link:"www.google.com",label:"Roadmap"},{link:"s",label:"Team"},{link:"b",label:"Goal"}];

  let features : FeatureType[] = [{key:"0",text:"Create your own wallet",icon:<CiWallet color='#efefef'/>},
  {key:"1",text:"Make a contribution to recycling",icon:<GiRecycle color='#efefef'/>},
  {key:"2",text:"Quick withdrawals",icon:<CiMoneyBill  color='#efefef'/>},
  {key:"3",text:"SSL protection of your data",icon:<svg id="Layer_1" data-name="Layer 1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 113.22 122.88"><title>encrypted-file</title><path fill="#EFEFEF" d="M70.53,92.26h4.11V86.6a16.92,16.92,0,0,1,5-12h0a16.91,16.91,0,0,1,24,0h0a17,17,0,0,1,5,12v5.66h3.26a1.35,1.35,0,0,1,1.33,1.33v28a1.34,1.34,0,0,1-1.33,1.33H70.52a1.34,1.34,0,0,1-1.34-1.33v-28a1.36,1.36,0,0,1,1.35-1.31ZM19.2,33.06a5,5,0,0,1-2.38-.51,3.14,3.14,0,0,1-1.42-1.46,5.12,5.12,0,0,1-.46-2.28V21.65a5.37,5.37,0,0,1,.49-2.43,3.44,3.44,0,0,1,1.46-1.51,5,5,0,0,1,2.33-.51h3.41a4.51,4.51,0,0,1,2.23.51,3.4,3.4,0,0,1,1.39,1.51,5.66,5.66,0,0,1,.47,2.43v7.16a4.35,4.35,0,0,1-1.06,3.11,4,4,0,0,1-3.05,1.14Zm-.08,72.66a5,5,0,0,1-2.38-.5,3.19,3.19,0,0,1-1.42-1.46,5.18,5.18,0,0,1-.46-2.28V94.32a5.41,5.41,0,0,1,.49-2.44,3.36,3.36,0,0,1,1.46-1.5,5,5,0,0,1,2.33-.51h3.41a4.51,4.51,0,0,1,2.23.51,3.32,3.32,0,0,1,1.39,1.5,5.71,5.71,0,0,1,.47,2.44v7.16a4.36,4.36,0,0,1-1.06,3.11,4,4,0,0,1-3,1.13Zm1-3.65h1.26a1.26,1.26,0,0,0,.87-.28,1.22,1.22,0,0,0,.31-.94V94.74a1.23,1.23,0,0,0-.3-1,1.07,1.07,0,0,0-.71-.24H20a1,1,0,0,0-.79.29,1.41,1.41,0,0,0-.26.93v6.09a1,1,0,0,0,1.2,1.24ZM32,105.6V93.73H29.52v-2.6l2.94-1.26h3.61V105.6Zm11.7.12a5.06,5.06,0,0,1-2.39-.5,3.16,3.16,0,0,1-1.41-1.46,5.18,5.18,0,0,1-.47-2.28V94.32a5.41,5.41,0,0,1,.5-2.44,3.31,3.31,0,0,1,1.46-1.5,4.92,4.92,0,0,1,2.33-.51h3.4a4.55,4.55,0,0,1,2.24.51,3.25,3.25,0,0,1,1.38,1.5,5.56,5.56,0,0,1,.48,2.44v7.16a4.41,4.41,0,0,1-1.06,3.11,4,4,0,0,1-3.06,1.13Zm1-3.65H46a1.3,1.3,0,0,0,.87-.28,1.26,1.26,0,0,0,.3-.94V94.74a1.27,1.27,0,0,0-.29-1,1.12,1.12,0,0,0-.72-.24H44.56a1,1,0,0,0-.8.29,1.42,1.42,0,0,0-.25.93v6.09a1,1,0,0,0,1.2,1.24ZM17.26,81.38V69.51H14.78V66.9l2.94-1.26h3.61V81.38ZM29,81.5a5.16,5.16,0,0,1-2.39-.5,3.23,3.23,0,0,1-1.42-1.46,5.33,5.33,0,0,1-.46-2.28V70.1a5.41,5.41,0,0,1,.5-2.44,3.26,3.26,0,0,1,1.46-1.5A4.8,4.8,0,0,1,29,65.64h3.4a4.45,4.45,0,0,1,2.24.52A3.25,3.25,0,0,1,36,67.66a5.56,5.56,0,0,1,.48,2.44v7.16a4.38,4.38,0,0,1-1.07,3.11,4,4,0,0,1-3,1.13Zm1-3.65h1.26a1.26,1.26,0,0,0,.88-.29,1.24,1.24,0,0,0,.3-.93V70.52a1.27,1.27,0,0,0-.29-1,1.12,1.12,0,0,0-.72-.24H29.82a1,1,0,0,0-.8.29,1.42,1.42,0,0,0-.25.93v6.09A1,1,0,0,0,30,77.85Zm11.87,3.53V69.51H39.35V66.9l2.94-1.26h3.62V81.38Zm11.7.12a5.12,5.12,0,0,1-2.38-.5,3.23,3.23,0,0,1-1.42-1.46,5.18,5.18,0,0,1-.46-2.28V70.1a5.41,5.41,0,0,1,.49-2.44,3.36,3.36,0,0,1,1.46-1.5,4.8,4.8,0,0,1,2.33-.52H57a4.42,4.42,0,0,1,2.24.52,3.32,3.32,0,0,1,1.39,1.5,5.71,5.71,0,0,1,.47,2.44v7.16A4.38,4.38,0,0,1,60,80.37a4,4,0,0,1-3.06,1.13Zm1-3.65H55.8a1.22,1.22,0,0,0,.87-.29,1.24,1.24,0,0,0,.31-.93V70.52a1.23,1.23,0,0,0-.3-1A1.07,1.07,0,0,0,56,69.3H54.39a1,1,0,0,0-.8.29,1.48,1.48,0,0,0-.25.93v6.09a1.26,1.26,0,0,0,.3,1,1.23,1.23,0,0,0,.9.29ZM19.28,57.28a5.14,5.14,0,0,1-2.38-.5,3.23,3.23,0,0,1-1.42-1.46A5.18,5.18,0,0,1,15,53V45.87a5.4,5.4,0,0,1,.49-2.43A3.36,3.36,0,0,1,17,41.94a4.83,4.83,0,0,1,2.33-.52h3.41a4.41,4.41,0,0,1,2.23.52,3.32,3.32,0,0,1,1.39,1.5,5.54,5.54,0,0,1,.47,2.43V53a4.38,4.38,0,0,1-1.06,3.11,4,4,0,0,1-3,1.13Zm1-3.66h1.26a1.21,1.21,0,0,0,.87-.28,1.2,1.2,0,0,0,.31-.93V46.29a1.21,1.21,0,0,0-.3-1,1.07,1.07,0,0,0-.71-.24H20.14a1,1,0,0,0-.79.29,1.38,1.38,0,0,0-.26.92v6.1a1.27,1.27,0,0,0,.3,1,1.25,1.25,0,0,0,.9.28Zm11.87,3.53V45.29H29.68V42.68l2.94-1.26h3.61V57.15Zm11.7.13a5.19,5.19,0,0,1-2.39-.5,3.21,3.21,0,0,1-1.41-1.46A5.18,5.18,0,0,1,39.59,53V45.87a5.39,5.39,0,0,1,.5-2.43,3.31,3.31,0,0,1,1.46-1.5,4.8,4.8,0,0,1,2.33-.52h3.4a4.45,4.45,0,0,1,2.24.52,3.32,3.32,0,0,1,1.39,1.5,5.69,5.69,0,0,1,.47,2.43V53a4.42,4.42,0,0,1-1.06,3.11,4,4,0,0,1-3.06,1.13Zm1-3.66h1.26a1,1,0,0,0,1.17-1.21V46.29a1.21,1.21,0,0,0-.29-1,1.12,1.12,0,0,0-.72-.24H44.72a1,1,0,0,0-.8.29,1.39,1.39,0,0,0-.25.92v6.1a1.32,1.32,0,0,0,.29,1,1.27,1.27,0,0,0,.91.28Zm11.86,3.53V45.29H54.26V42.68l2.94-1.26h3.61V57.15Zm11.7.13a5.14,5.14,0,0,1-2.38-.5,3.23,3.23,0,0,1-1.42-1.46A5.18,5.18,0,0,1,64.17,53V45.87a5.4,5.4,0,0,1,.49-2.43,3.36,3.36,0,0,1,1.46-1.5,4.83,4.83,0,0,1,2.33-.52h3.41a4.38,4.38,0,0,1,2.23.52,3.27,3.27,0,0,1,1.39,1.5A5.54,5.54,0,0,1,76,45.87V53a4.38,4.38,0,0,1-1.06,3.11,4,4,0,0,1-3,1.13Zm1-3.66H70.7a1.21,1.21,0,0,0,.87-.28,1.2,1.2,0,0,0,.31-.93V46.29a1.21,1.21,0,0,0-.3-1,1.07,1.07,0,0,0-.71-.24H69.3a1,1,0,0,0-.8.29,1.38,1.38,0,0,0-.26.92v6.1a1,1,0,0,0,1.2,1.23ZM66.92.65A2.49,2.49,0,0,0,65.29,0a1.29,1.29,0,0,0-.39,0H5.42a5.45,5.45,0,0,0-3.83,1.6A5.33,5.33,0,0,0,0,5.46v112a5.43,5.43,0,0,0,5.42,5.42h54.3a11.73,11.73,0,0,1-.08-1.33v-5.76h-52a.47.47,0,0,1-.39-.17.63.63,0,0,1-.17-.39V7.69a.4.4,0,0,1,.17-.38.55.55,0,0,1,.39-.18H61.3V26.67a8.77,8.77,0,0,0,2.15,5.77,10.17,10.17,0,0,0,6.19,2.43H88.93V60.21a27,27,0,0,1,2.71-.14,25.7,25.7,0,0,1,4.32.36V31.62a2.42,2.42,0,0,0,.09-.6,2.63,2.63,0,0,0-.82-1.85L67.22.82A.63.63,0,0,0,67,.65Zm.78,25.47V8.82L87.23,28.61h-17a2.6,2.6,0,0,1-1.76-.73,2.53,2.53,0,0,1-.73-1.76ZM20.21,29.4h1.26a1.05,1.05,0,0,0,1.18-1.22V22.07a1.21,1.21,0,0,0-.3-1,1,1,0,0,0-.71-.25H20.06a1,1,0,0,0-.79.3,1.37,1.37,0,0,0-.26.92v6.09a1.28,1.28,0,0,0,.3,1,1.23,1.23,0,0,0,.9.28Zm11.87,3.53V21.06H29.6v-2.6l2.94-1.26h3.61V32.93Zm11.7.13a5.06,5.06,0,0,1-2.39-.51A3.12,3.12,0,0,1,40,31.09a5.12,5.12,0,0,1-.47-2.28V21.65a5.36,5.36,0,0,1,.5-2.43,3.38,3.38,0,0,1,1.46-1.51,4.92,4.92,0,0,1,2.33-.51h3.4a4.55,4.55,0,0,1,2.24.51,3.32,3.32,0,0,1,1.38,1.51,5.51,5.51,0,0,1,.48,2.43v7.16a4.39,4.39,0,0,1-1.06,3.11,4,4,0,0,1-3.06,1.14Zm1-3.66h1.26a1,1,0,0,0,1.17-1.22V22.07a1.24,1.24,0,0,0-.29-1,1.07,1.07,0,0,0-.72-.25H44.64a1,1,0,0,0-.8.3,1.37,1.37,0,0,0-.25.92v6.09a1.33,1.33,0,0,0,.29,1,1.27,1.27,0,0,0,.91.28Zm34.48,75.36a1,1,0,1,1,2.07,0v1.34l1.11-.74a1,1,0,1,1,1.15,1.71l-1.43,1,1.43,1a1,1,0,0,1-1.14,1.73L81.34,110v1.35a1,1,0,0,1-2.07,0V110l-1.11.74A1,1,0,0,1,77,109l1.43-.95-1.43-1a1,1,0,1,1,1.14-1.72l1.12.74v-1.34Zm21.79,0a1,1,0,1,1,2.07,0v1.34l1.11-.74a1,1,0,1,1,1.15,1.71L104,108l1.44,1a1,1,0,1,1-1.15,1.73l-1.12-.75v1.35a1,1,0,0,1-2.07,0V110l-1.11.74a1,1,0,0,1-1.43-.28A1,1,0,0,1,98.8,109l1.43-.95-1.43-1a1,1,0,1,1,1.14-1.72l1.12.74v-1.34Zm-10.89,0a1,1,0,1,1,2.07,0v1.34l1.11-.74a1,1,0,0,1,1.15,1.71l-1.44,1,1.44,1a1,1,0,0,1-1.14,1.73L92.24,110v1.35a1,1,0,0,1-2.07,0V110l-1.12.74A1,1,0,0,1,87.9,109l1.44-.95-1.44-1a1,1,0,0,1-.29-1.43,1,1,0,0,1,1.43-.29l1.13.74v-1.34Zm-8.94-12.5H102V86.49A10.35,10.35,0,0,0,99,79.16h0a10.4,10.4,0,0,0-17.73,7.33v5.77Z"/></svg>},
  {key:"4",text:"24/7 support for our clients",icon:<FiClock color='#efefef'/>},
  {key:"5",text:"Safe & Secure",icon:<AiOutlineSafety color='#efefef'/>},
  {key:"6",text:"Universal Access",icon:<HiOutlineTicket color='#efefef'/>},
  {key:"7",text:"Automated Payment",icon:<RiSecurePaymentLine color='#efefef'/>},

  
]

  return (
    <>
    <TauHeader links={link}></TauHeader>
    <HomeBanner2></HomeBanner2>
    <HomeBanner></HomeBanner>
    <Roadmap></Roadmap>
    <Features features={features}></Features>
    </>
  )
}
