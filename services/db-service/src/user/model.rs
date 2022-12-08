use crate::schema::*;
use chrono::NaiveDateTime;
use diesel::{prelude::*, sql_types::Timestamp};

use serde::Serialize;



#[derive(Debug, Queryable, Serialize)]
pub struct User
{
    pub id:i32,
    pub name:String,
    pub surname:String,
    pub username:String,
    pub psw:String,
    pub email:String,
    #[serde(serialize_with = "serialize_naive_date_time")]
    pub created_at:NaiveDateTime,
}


fn serialize_naive_date_time<S>(x:&NaiveDateTime, serializer: S) -> Result<S::Ok, S::Error>
where
    S: serde::Serializer {
        serializer.serialize_str(&x.to_string())
}

#[derive(Debug, Insertable, AsChangeset)]
#[table_name="gusers"]
pub struct NewUser<'x>
{
    pub name:&'x str,
    pub surname:&'x str,
    pub username:&'x str,
    pub psw:&'x str,
    pub email:&'x str,
}

