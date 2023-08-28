package models

import "github.com/MrRebchik/Improved-Task-Manager/auth/repository/mongo"

type User struct {
	ID       string
	Username string
	Password string
}

func ToMongoUser(u *User) *mongo.User {
	return &mongo.User{
		Username: u.Username,
		Password: u.Password,
	}
}

func ToModelUser(u *mongo.User) *User {
	return &User{
		ID:       u.ID.Hex(),
		Username: u.Username,
		Password: u.Password,
	}
}
