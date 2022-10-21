use actix_web::{get, post,HttpRequest, web,guard, App, HttpResponse, Responder};
use diesel::{QueryDsl, RunQueryDsl, Table};
use serde::Deserialize;

use crate::{schema::gusers, user_model::User, establish_connection,user_model::NewUser};

#[derive(Deserialize)]
pub struct GetUserBodyType {
    pub username: String,
}



pub fn get_user_route_controller() -> actix_web::Scope
{
    web::scope("/user")
    .guard(guard::Header("content-type", "application/json"))
    .service(get_user)
    .service(create_user)
}
 
#[get("/get-user")]
pub async fn get_user(_body: web::Json<GetUserBodyType>) -> impl Responder
{
    use crate::schema::gusers::dsl::*;
    use diesel::ExpressionMethods;

    let connection = establish_connection();

    let _user =  gusers
    .select(gusers::all_columns())
    .filter(username.eq(&_body.username))
    .first::<User>(&connection);


    match _user
    {
        Ok(__user) => 
        {
            HttpResponse::Ok().json(__user)//.body(zartzurt)
            
        }
        Err(_err) => 
        {
            println!("Couldn't find user");
            HttpResponse::NoContent().body("Couldn't find user")
        }
    }


    //HttpResponse::Ok()//.body(format!("Welcome {}!", reqType.username))
}


#[derive(Deserialize)]
pub struct CreateUserBodyType
{
    pub name:String,
    pub username:String,
    pub surname:String,
    pub password:String
}


#[post("/create-user")]
pub async fn create_user(_body: web::Json<CreateUserBodyType>) -> impl Responder
{
    let connection = establish_connection();

    let new_user = NewUser{
        name:&_body.name,
        username:&_body.username,
        surname:&_body.surname,
        psw:&_body.password
    };


    let t = diesel::insert_into(gusers::table)
        .values(&new_user)
        .execute(&connection);
    


    HttpResponse::Ok().body("User Inserted!")
}