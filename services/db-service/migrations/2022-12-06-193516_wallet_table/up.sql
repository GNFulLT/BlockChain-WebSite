-- Your SQL goes here
CREATE TABLE wallet_table(
  id SERIAL PRIMARY KEY,
  user_id INT NOT NULL,
  carbon_point INT NOT NULL DEFAULT(0),
  created_at TIMESTAMP NOT NULL DEFAULT NOW(),
  updated_at TIMESTAMP NOT NULL DEFAULT NOW(),
  CONSTRAINT fk_user
      FOREIGN KEY(user_id) 
	  REFERENCES gusers(id)
)