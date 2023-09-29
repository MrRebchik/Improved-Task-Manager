package service

import (
	"authorization/models"
	"authorization/pkg/infrastructure/repository"
)

type Auth interface {
	GetSingleUser(userJSON []byte) (*models.User, error)
	CreateUser(userJSON []byte) (*models.User, error)
	ParseToken(userJSON []byte) (string, error)
}

type Service struct {
	Auth
}

func NewService(repo *repository.Repository) *Service {
	return &Service{
		Auth: NewAuthService(repo),
	}
}
