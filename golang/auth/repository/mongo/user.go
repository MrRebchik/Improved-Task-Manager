package mongo

import (
	models "github.com/MrRebchik/Improved-Task-Manager/models"
	"go.mongodb.org/mongo-driver/bson/primitive"
)

type User struct {
	ID       primitive.ObjectID `bson:"_id,omitempty"`
	Username string             `bson:"username"`
	Password string             `bson:"password"`
}

func toMongoUser(user *models.User) *User {
	return &User{
		Username: user.Username,
		Password: user.Password,
	}
}

func toModelUser(user *User) *models.User {
	return &models.User{
		ID:       user.ID.Hex(),
		Username: user.Username,
		Password: user.Password,
	}
}
