export interface CookieType 
{
    accessToken:string,
    email: string
}

export interface CookieAuthType
{
    accessToken:string,
    email: string,
    first_name:string,
    last_name:string
}

export const AuthCookieKey = "AuthCookie"