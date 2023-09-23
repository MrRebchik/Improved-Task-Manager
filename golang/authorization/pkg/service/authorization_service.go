package service

import (
	"authorization/models"
	"authorization/pkg/repository"
)

type AuthorizationService struct {
	repo *repository.Repository
}

func NewAuthorizationService(repo *repository.Repository) *AuthorizationService {
	return &AuthorizationService{
		repo: repo,
	}
}

func (s *AuthorizationService) GetUser(user *models.User) (*models.User, error) {
	// TODO GetUser

	return nil, nil
}

func (s *AuthorizationService) CreateUser(user *models.User) (*models.User, error) {

	// TODO CreateUser

	return nil, nil
}
