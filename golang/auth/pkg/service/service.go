package service

import (
	"authorization/models"
	"authorization/pkg/infrastructure/repository"
)

type Auth interface {
	GetUser(user *models.User) (*models.User, error)
	CreateUser(user *models.User) (*models.User, error)
	ParseToken(user *models.User) (string, error)
}

type Service struct {
	Auth
}

func NewService(repo *repository.Repository) *Service {
	return &Service{
		Auth: NewAuthService(repo),
	}
}
