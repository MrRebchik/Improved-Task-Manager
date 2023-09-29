package repository

import (
	"authorization/models"
	"github.com/sirupsen/logrus"
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

func (r *SqliteRepository) GetSingleUser(user *models.User) (*models.User, error) {

	logrus.Infoln("Trying to find user ", user.Username)

	result := r.db.Find(&user)

	if result.Error != nil {
		logrus.Errorln("Error while creating user ", user.Username)
		return nil, result.Error
	}

	logrus.Infof("Found user %s with ID %s\n", user.Username, user.ID)

	return user, nil
}

func (r *SqliteRepository) CreateUser(user *models.User) (*models.User, error) {

	logrus.Infoln("Trying to create user ", user.Username)

	result := r.db.Create(&user)

	if result.Error != nil {
		logrus.Errorln("Error while creating user ", user.Username)
		return nil, result.Error
	}

	logrus.Infof("Created user %s with ID %s\n", user.Username, user.ID)

	return user, nil
}
