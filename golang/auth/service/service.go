package service

import (
	"context"
	"github.com/MrRebchik/Improved-Task-Manager/auth"
	"github.com/MrRebchik/Improved-Task-Manager/models"
	"time"
)

type AuthService struct {
	userRepository auth.UserRepository
	hashSalt       string
	signingKey     []byte
	expireDuration time.Duration
}

func NewAuthService(
	userRepo auth.UserRepository,
	hashSalt string,
	signingKey []byte,
	tokenTTLSeconds time.Duration) *AuthService {
	return &AuthService{
		userRepository: userRepo,
		hashSalt:       hashSalt,
		signingKey:     signingKey,
		expireDuration: time.Second * tokenTTLSeconds,
	}
}

func (AS *AuthService) SignUp(ctx context.Context, username, password string) error {

	return nil
}

func (AS *AuthService) SignIn(ctx context.Context, username, password string) (string, error) {

	return "", nil
}

func (AS *AuthService) ParseToken(ctx context.Context, accessToken string) (*models.User, error) {

	return &models.User{}, nil
}
