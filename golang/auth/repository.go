package auth

import (
	user "github.com/MrRebchik/Improved-Task-Manager/models"
)

type Authorization interface {
	user.User
}
