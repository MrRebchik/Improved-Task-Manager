package repository

import (
	"authorization/models"
	"gorm.io/gorm"
)

type Authorization interface {
	GetUser(user *models.User) *models.User
	CreateUser(user *models.User) (*models.User, error)
}

type Repository struct {
	Authorization
}

func NewRepository(db *gorm.DB) *Repository {
	return &Repository{
		Authorization: NewSqliteRepository(db),
	}
}
