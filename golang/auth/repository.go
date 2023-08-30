package auth

import (
	"context"
	"github.com/MrRebchik/Improved-Task-Manager/auth/models"
)

type UserRepository interface {
	CreateUser(ctx context.Context, user *models.User) error
	GetUser(ctx context.Context, username, password string) (*models.User, error)
}
