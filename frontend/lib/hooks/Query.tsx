import { useMediaQuery } from '@mantine/hooks';
import * as React from 'react'

interface QueryActive
{
   mdQuery:boolean,
   lgQuery:boolean
}

const QueryActiveContext = React.createContext<QueryActive>({} as QueryActive);

const QueryActiveProvider : React.FC<any> = ({children}) => 
{
    const mdQuery = useMediaQuery("(min-width:768px)",false);
    const lgQuery = useMediaQuery("(min-width: 1024px)",false);
    return(
        <QueryActiveContext.Provider value={{mdQuery,lgQuery}}>
            {children}
        </QueryActiveContext.Provider>
    );
}

export const useMdQuery = () => React.useContext(QueryActiveContext);

export default QueryActiveProvider;