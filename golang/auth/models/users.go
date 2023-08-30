package models

import "github.com/MrRebchik/Improved-Task-Manager/auth/repository/mongo"

type User struct {
	ID       string
	Username string
	Password string
}

func ToMongoUser(u *User) *repository_mongo.User {
	return &repository_mongo.User{
		Username: u.Username,
		Password: u.Password,
	}
}

func ToModelUser(u *repository_mongo.User) *User {
	return &User{
		ID:       u.ID.Hex(),
		Username: u.Username,
		Password: u.Password,
	}
}
