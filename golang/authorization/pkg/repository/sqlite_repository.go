package repository

import (
	"authorization/models"
	"gorm.io/gorm"
)

type SqliteRepository struct {
	db *gorm.DB
}

func NewSqliteRepository(db *gorm.DB) *SqliteRepository {
	return &SqliteRepository{
		db: db,
	}
}

func (r *SqliteRepository) GetUser(user *models.User) *models.User {
	// TODO GetUser

	return nil
}

func (r *SqliteRepository) CreateUser(user *models.User) (*models.User, error) {
	// TODO CreateUser

	return nil, nil
}
