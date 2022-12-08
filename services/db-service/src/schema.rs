// @generated automatically by Diesel CLI.

diesel::table! {
    gusers (id) {
        id -> Int4,
        name -> Varchar,
        surname -> Varchar,
        username -> Varchar,
        psw -> Varchar,
        email -> Varchar,
        created_at -> Timestamp,
    }
}

diesel::table! {
    product_table (id) {
        id -> Int4,
        dsc -> Nullable<Varchar>,
        carbon_value -> Int4,
        created_at -> Timestamp,
        updated_at -> Timestamp,
    }
}

diesel::table! {
    qr_table (id) {
        id -> Int4,
        user_id -> Int4,
        qr_image_path -> Varchar,
        created_at -> Timestamp,
    }
}

diesel::table! {
    session_table (id) {
        id -> Int4,
        user_id -> Int4,
        session_id -> Varchar,
        created_at -> Timestamp,
        timeout_at -> Timestamp,
    }
}

diesel::table! {
    wallet_table (id) {
        id -> Int4,
        user_id -> Int4,
        carbon_point -> Int4,
        created_at -> Timestamp,
        updated_at -> Timestamp,
    }
}

diesel::allow_tables_to_appear_in_same_query!(
    gusers,
    product_table,
    qr_table,
    session_table,
    wallet_table,
);
