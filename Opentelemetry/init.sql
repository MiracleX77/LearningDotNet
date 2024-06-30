CREATE DATABASE roller;


CREATE TABLE IF NOT EXISTS Rolls (
        id SERIAL PRIMARY KEY,
        user_id INT NOT NULL,
        value INT NOT NULL,
        created TIMESTAMP NOT NULL
);