package service

import (
	"authorization/models"
	"authorization/pkg/repository"
)

type Authorization interface {
	GetUser(user *models.User) (*models.User, error)
	CreateUser(user *models.User) (*models.User, error)
}

type Service struct {
	Authorization
}

func NewService(repo *repository.Repository) *Service {
	return &Service{
		Authorization: NewAuthorizationService(repo),
	}
}
