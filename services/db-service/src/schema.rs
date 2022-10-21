// @generated automatically by Diesel CLI.
diesel::table! {
    gusers (id) {
        id -> Int4,
        name -> Varchar,
        surname -> Varchar,
        username -> Varchar,
        psw -> Varchar,
    }
}
