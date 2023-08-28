package auth

import (
	"context"
	"github.com/MrRebchik/Improved-Task-Manager/models"
)

type Service interface {
	SignUp(ctx context.Context, username, password string) error
	SignIn(ctx context.Context, username, password string) (string, error)
	ParseToken(ctx context.Context, accessToken string) (*models.User, error)
}
