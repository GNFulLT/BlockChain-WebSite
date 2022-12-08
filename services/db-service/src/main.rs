pub mod db;
pub mod user;
pub mod schema;



use chrono::NaiveDateTime;
pub use db::*;
use diesel::sql_types::Timestamp;
use dotenvy::dotenv;
use std::env;
use std::collections::HashMap;
pub use user::model as user_model;
pub use user::routes as user_routes;
use actix_web::{get, post, web, App, HttpResponse, HttpServer, Responder};
use user::routes::get_user_route_controller;
#[macro_use] extern crate diesel;





#[actix_web::main]
async fn main() -> std::io::Result<()> {

    dotenv().ok();
    
    let port = env::var("PORT").expect("There is no given port").parse::<u16>().expect("U16 YA DÖNÜŞMÜYOR PORT AMK");
    
    let eurekaHost = env::var("EUREKA_HOST").expect("There is no given eureka host in env");
    
    let clientName = env::var("CLIENT_NAME").expect("There is no given eureka host in env");
    let client = reqwest::Client::new();


 
    
    let parsed = format!(r#"
    {{
        "instance": {{
          "hostName": "localhost",
          "app": "{clientName}",
          "ipAddr": "10.0.0.10",
          "status": "STARTING",
          "port": {{
            "$": "9999",
            "@enabled": "true"
          }},
          "homePageUrl": "http://localhost:9999",
          "dataCenterInfo": {{
            "@class": "com.netflix.appinfo.InstanceInfo$DefaultDataCenterInfo",
            "name": "MyOwn"
          }}
        }}
      }}
      "#);

    let uri = format!("{eurekaHost}/eureka/apps/{clientName}");
    let rr = client.post(uri)
    .header("content-type", "application/json")
    .body(parsed)
    .send()
    .await;

    match rr
    {
        Ok(rr) => {
            let t = rr.text().await.expect("Çeviremedim dayi malesef");
            println!("{}", t);
        },
        Err(e) => println!("Cant be registered")
    }


    HttpServer::new(|| {
        App::new()
            .service(
                get_user_route_controller()
            )
    })
    .bind(("127.0.0.1",port))?
    .run()
    .await
}
