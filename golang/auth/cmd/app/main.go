package main

import "authorization/pkg/infrastructure/repository"

func main() {

	_ = repository.NewSqliteDB("../../sqlite.db")

}
