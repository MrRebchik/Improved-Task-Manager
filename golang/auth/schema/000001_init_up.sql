CREATE TABLE users (
    id autoincrement unique,
    username VARCHAR NOT NULL unique,
    password VARCHAR NOT NULL
)