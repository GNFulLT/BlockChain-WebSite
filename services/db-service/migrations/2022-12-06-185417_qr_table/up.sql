-- Your SQL goes here
CREATE TABLE qr_table(
  id SERIAL PRIMARY KEY,
  user_id INT NOT NULL, 
  qr_image_path VARCHAR(255) NOT NULL,
  created_at TIMESTAMP NOT NULL DEFAULT NOW(),
  CONSTRAINT fk_user
      FOREIGN KEY(user_id) 
	  REFERENCES gusers(id)
)