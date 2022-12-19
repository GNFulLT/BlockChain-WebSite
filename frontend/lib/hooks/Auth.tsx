//import axios from 'axios';
import * as React from 'react'
import { CookieAuthType } from '../types/CookieType';

interface AuthContextType
{
    auth? : CookieAuthType,
    signIn: (email:string,password:string) => Promise<void>,
    signOut : () =>  Promise<void>,
    isLoading : boolean
}


const AuthContext = React.createContext<AuthContextType >({} as AuthContextType);



const AuthProvider : React.FC<any> = ({children}) => 
{
   
    const [auth,setAuth] = React.useState<CookieAuthType | undefined>();
    const [isLoading,setIsLoading] =  React.useState(true);

    React.useEffect(() => {
        const tryGetAuth = async () => {
            /*
            const res = await axios.post("/api/users/auth");
            if(res.status == 200)
            {
                const restCookie = res.data as CookieAuthType;
                setAuth(restCookie);
            }
            */
        }

        tryGetAuth()
        .then(() => {
            console.log("Authed Successfully");
        })
        .finally(() => {
            setIsLoading(false);
        })
    },[])

    const signIn = async (email:string,password:string) => {
        /*const reqData = {email,password};
        const res = await axios.post("/api/users/login",reqData);
        if(res.status == 200)
        {
            setAuth(res.data as CookieAuthType);
        }
        else
        {
            throw "Can Login";
        }*/
    } 

    const signOut = async () => {
        /*const res = await axios.post("/api/users/logout");
        if(res.status == 200)
        {
            setAuth(undefined);
        }
        else
        {
            throw "Cant Logout";
        }*/
    } 

    if(isLoading)
    {
        return (
            <AuthContext.Provider value={{auth,signIn,signOut,isLoading}}>
        
            </AuthContext.Provider>
        )
    }
    return(
        <AuthContext.Provider value={{auth,signIn,signOut,isLoading}}>
        {children}
        </AuthContext.Provider>
    );
}


export const useAuth = () => React.useContext(AuthContext);

export default AuthProvider;