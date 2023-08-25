package sqlite

import (
	"database/sql"
	_ "github.com/mattn/go-sqlite3"
)

type DB struct {
	sql  *sql.DB
	stmt *sql.Stmt
}

const SchemaSQL string = `
	CREATE TABLE IF NOT EXISTS users (
	    id INTEGER NOT NULL PRIMARY KEY,
	    username TEXT NOT NULL,
	    password TEXT NOT NULL
	);
`

const InsertSQL string = `
	INSERT INTO users (id, username, password)
	VALUES (
	        ?, ?, ?, ?
	)
`

func InitializeSQLite(dbFile string) (*DB, error) {
	database, err := sql.Open("sqlite3", dbFile)
	if err != nil {
		return nil, err
	}

	if _, err = database.Exec(SchemaSQL); err != nil {
		return nil, err
	}

	stmt, err := database.Prepare(InsertSQL)
	if err != nil {
		return nil, err
	}

	db := DB{
		sql:  database,
		stmt: stmt,
	}
	return &db, nil
}
