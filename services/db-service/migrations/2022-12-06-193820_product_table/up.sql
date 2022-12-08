-- Your SQL goes here
CREATE TABLE product_table(
  id SERIAL PRIMARY KEY,
  dsc VARCHAR(1000),
  carbon_value INT NOT NULL DEFAULT(0),
  created_at TIMESTAMP NOT NULL DEFAULT NOW(),
  updated_at TIMESTAMP NOT NULL DEFAULT NOW()
)