package auth

import (
	users "github.com/MrRebchik/Improved-Task-Manager/models"
)

type Authorization interface {
	CreateUser(user users.User) (error, int)
	GetUser(username, password string) (users.User, error)
}
