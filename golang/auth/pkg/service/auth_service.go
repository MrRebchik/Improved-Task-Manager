package service

import (
	"authorization/models"
	"authorization/pkg/infrastructure/repository"
)

type AuthService struct {
	repo *repository.Repository
}

func NewAuthService(repo *repository.Repository) *AuthService {
	return &AuthService{
		repo: repo,
	}
}

func (s *AuthService) GetUser(user *models.User) (*models.User, error) {
	// TODO GetUser

	return nil, nil
}

func (s *AuthService) CreateUser(user *models.User) (*models.User, error) {

	// TODO CreateUser

	return nil, nil
}

func (s *AuthService) ParseToken(user *models.User) (string, error) {
	return "", nil
}
