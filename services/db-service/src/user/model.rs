use crate::schema::*;

use diesel::prelude::*;

use serde::Serialize;

#[derive(Debug, Queryable, Serialize)]
pub struct User
{
    pub id:i32,
    pub name:String,
    pub surname:String,
    pub username:String,
    pub password:String
}

#[derive(Debug, Insertable, AsChangeset)]
#[table_name="gusers"]
pub struct NewUser<'x>
{
    pub name:&'x str,
    pub surname:&'x str,
    pub username:&'x str,
    pub psw:&'x str
}

