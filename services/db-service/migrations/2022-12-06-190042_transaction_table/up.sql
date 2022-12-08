-- Your SQL goes here
CREATE TABLE session_table(
  id SERIAL PRIMARY KEY,
  user_id INT NOT NULL, 
  session_id VARCHAR(255) NOT NULL,
  created_at TIMESTAMP NOT NULL DEFAULT NOW(),
  timeout_at TIMESTAMP NOT NULL,
    CONSTRAINT fk_user
      FOREIGN KEY(user_id) 
	  REFERENCES gusers(id)
);