import { UIEvent, UIEventHandler, useState,useRef, RefObject, Ref,useEffect} from 'react';
import { createStyles, Header, Container, Group, Burger } from '@mantine/core';
import { useDisclosure, useMediaQuery } from '@mantine/hooks';
import icon from "../../public/icon.png"
import Image from 'next/image';
import { styled } from '@stitches/react';
import styles from "./Header.module.scss"
import LoginCard from '../LoginRegister/LoginCard';

let isSticky = false;


const IconText = styled(("div"), {
  display:"flex",
  justifyContent:"space-evenly",
  alignItems:"center",
  gap:"15px",
  fontSize:"24px"
});

export interface LinkProps
{
  link: string; 
  label: string
}

export interface HeaderSimpleProps {
  links: LinkProps[];
}

function TauHeader({ links }: HeaderSimpleProps) {
  const [opened, { toggle }] = useDisclosure(false);
  const [active, setActive] = useState(links[0].link);
  const menuRef = useRef<HTMLUListElement>(null);

  const headerRef = useRef<HTMLElement>(null);
 
  useEffect(() => {
    
    window.onscroll = () => 
    {
      if(window.scrollY > 10)
      {
        if(!isSticky)
        {
          headerRef.current!.classList.add(styles["sticky-header"]);
          menuRef.current!.classList.add(styles["fixed-ul"]);
          isSticky = true;
        }
      }
      else if(window.scrollY < 5)
      {
        if(isSticky)
        {
          headerRef.current!.classList.remove(styles["sticky-header"]);
          menuRef.current!.classList.remove(styles["fixed-ul"]);
          isSticky = false;
        }
      }
    }

  },[]);


  const matches = useMediaQuery('(min-width: 1024px)');

  const useStyles = createStyles((theme) => ({

    header: {
      display: 'flex',
      justifyContent: 'space-between',
      alignItems: 'center',
      height: '100%',
      backgroundColor:"transparent",
      maxWidth:"100%",
      width:"100%",
      padding:`${matches ? "0 90px" : "0 45px"}`,
    },
  
    links: {
      [theme.fn.smallerThan('xs')]: {
        display: 'none',
      },
    },
  
    burger: {
      [theme.fn.largerThan('xs')]: {
        display: 'none',
      },
    },
  
    link: {
      display: 'block',
      lineHeight: 1,
      padding: '8px 12px',
      borderRadius: theme.radius.sm,
      textDecoration: 'none',
      color: theme.colorScheme === 'dark' ? theme.colors.dark[0] : theme.colors.gray[7],
      fontSize: theme.fontSizes.sm,
      fontWeight: 500,
      backgroundColor:"transparent",
      '&:hover': {
        backgroundColor: theme.colorScheme === 'dark' ? theme.colors.dark[6] : theme.colors.gray[0],
      },
    },
  
    linkActive: {
      '&, &:hover': {
        backgroundColor: theme.fn.variant({ variant: 'light', color: theme.primaryColor }).background,
        color: theme.fn.variant({ variant: 'light', color: theme.primaryColor }).color,
      },
    },
  }));

  const { classes, cx } = useStyles();
  const [showModal,setShowModal] = useState(false);

  const loginClickHandler = () => 
  {
    setShowModal(true);
    document.body.style.overflow = 'hidden';
    document.getElementsByTagName('html')[0].style.overflow = "hidden";
  }
  const modalCloseHandler = () => 
  {
    setShowModal(false);
    document.body.style.overflow = 'overlay';
    document.getElementsByTagName('html')[0].style.overflow = "overlay";

  }
  return (
    <Header className={styles["main-header"]} ref={headerRef} height={60} mb={120}>
      <Container className={classes.header}>
        <IconText>
          <Image src={icon} alt="Coin Icon" width={64} height={64}></Image>
          <div className={styles["headerText"]}>
            <div style={{display:"flex",flexDirection:"row",gap:"12px",color:"white"}}>
              <span style={{ "--index": 0,transform:"rotate(-90deg)",color:"white"} as React.CSSProperties}>A</span>
              <span style={{ "--index": 0,transform:"rotate(-90deg)",color:"white"} as React.CSSProperties}>X</span>     
              <span style={{ "--index": 0,transform:"rotate(-90deg)",color:"white"} as React.CSSProperties}>O</span>          
            </div>
            <span style={{color:"white"}}>TOKEN</span>
          </div>
        </IconText>
        <div className={styles["header"]}> 
          <input className={styles["menu-btn"]} type="checkbox" id={styles["menu-btn"]} />
          <label className={styles["menu-icon"]} htmlFor={styles["menu-btn"]}>
            <span className={styles["navicon"]}></span>
          </label>
          <ul ref={menuRef} className={styles["menu"]}>
            <li><a href="#work" >Goals</a></li>
            <li><a href="#about">Road Map</a></li>
            <li><a href="#careers">Team</a></li>
            <li><a href="#contact">SSS</a></li>
          </ul>
        </div>
        <div className={styles["login"]}>
          <ul>
            <li><a onClick={loginClickHandler} style={{fontSize:"12px"}}>Login</a></li>
            <li><a style={{color:"#55468D",fontSize:"12px",backgroundColor:"white",borderRadius:"9999px",padding:"12px 12px"}}>Get Started</a></li>
          </ul>
        </div>
      </Container>
      <LoginCard isShow={showModal} onClose={modalCloseHandler}></LoginCard>
    </Header>
  );
}




export default TauHeader;