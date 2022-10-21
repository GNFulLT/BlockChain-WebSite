pub mod db;
pub mod user;
pub mod schema;



pub use db::*;

pub use user::model as user_model;
pub use user::routes as user_routes;
use actix_web::{get, post, web, App, HttpResponse, HttpServer, Responder};
use user::routes::get_user_route_controller;
#[macro_use] extern crate diesel;






#[actix_web::main]
async fn main() -> std::io::Result<()> {
    HttpServer::new(|| {
        App::new()
            .service(
                get_user_route_controller()
            )
    })
    .bind(("127.0.0.1", 8080))?
    .run()
    .await
}
