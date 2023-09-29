package service

import (
	"authorization/models"
	"authorization/pkg/infrastructure/repository"
	"encoding/json"
	"github.com/sirupsen/logrus"
)

type AuthService struct {
	repo *repository.Repository
}

func NewAuthService(repo *repository.Repository) *AuthService {
	return &AuthService{
		repo: repo,
	}
}

func (s *AuthService) GetUser(userJSON []byte) (*models.User, error) {
	var user *models.User

	logrus.Infoln("Unmarshalling request")

	err := json.Unmarshal(userJSON, &user)

	if err != nil {
		logrus.Errorln("Error while unmarshalling userJSON")
		return nil, err
	}

	logrus.Infoln("Unmarshalled user ", user.Username)

	user, err = s.repo.CreateUser(user)

	return user, err
}

func (s *AuthService) CreateUser(userJSON []byte) (*models.User, error) {

	return nil, nil
}

func (s *AuthService) ParseToken(userJSON []byte) (string, error) {
	return "", nil
}
