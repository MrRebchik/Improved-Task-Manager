package mongo

import (
	"context"
	models "github.com/MrRebchik/Improved-Task-Manager/models"
	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/bson/primitive"
	"go.mongodb.org/mongo-driver/mongo"
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

type UserRepository struct {
	db *mongo.Collection
}

func (r UserRepository) CreateUser(ctx context.Context, user *models.User) error {
	mongoModel := toMongoUser(user)
	res, err := r.db.InsertOne(ctx, mongoModel)
	if err != nil {
		return err
	}

	user.ID = res.InsertedID.(primitive.ObjectID).Hex()
	return nil
}

func (r UserRepository) GetUser(ctx context.Context, username, password string) (*models.User, error) {
	user := new(User)
	err := r.db.FindOne(ctx, bson.M{
		"username": username,
		"password": password,
	}).Decode(user)

	if err != nil {
		return nil, err
	}

	return models.ToModelUser(user), nil
}
