package service

import (
	"authorization/models"
	"authorization/pkg/infrastructure/repository"
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

func (s *AuthService) GetSingleUser(userJSON []byte) (*models.User, error) {
	var user *models.User

	logrus.Infoln("Unmarshalling request")

	err := user.UnmarshalJSONToUser(userJSON)

	if err != nil {
		return nil, err
	}

	user, err = s.repo.GetSingleUser(user)

	return user, err
}

func (s *AuthService) CreateUser(userJSON []byte) (*models.User, error) {

	return nil, nil
}

func (s *AuthService) ParseToken(userJSON []byte) (string, error) {
	return "", nil
}
