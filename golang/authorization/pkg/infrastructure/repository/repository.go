package repository

import (
	"authorization/models"
	"gorm.io/gorm"
)

type Authorization interface {
	GetUser(user *models.User) (*models.User, error)
	CreateUser(user *models.User) (*models.User, error)
}

type Repository struct {
	Authorization
}

func NewRepository(db *gorm.DB, typeDB string) *Repository {
	switch typeDB {
	case "sqlite":
		return &Repository{
			Authorization: NewSqliteRepository(db),
		}
	default:
		return &Repository{
			Authorization: NewSqliteRepository(db),
		}
	}
}
