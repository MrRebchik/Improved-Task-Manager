package auth_mongo

import (
	"context"
	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/bson/primitive"
	"go.mongodb.org/mongo-driver/mongo"
	"log"
)

type MongoUser struct {
	ID       primitive.ObjectID `bson:"_id,omitempty"`
	Username string             `bson:"username"`
	Password string             `bson:"password"`
}

type ModelUser struct {
	ID       string
	Username string
	Password string
}

func ToMongoUser(u *ModelUser) *MongoUser {
	return &MongoUser{
		Username: u.Username,
		Password: u.Password,
	}
}

func ToModelUser(u *MongoUser) *ModelUser {
	return &ModelUser{
		ID:       u.ID.Hex(),
		Username: u.Username,
		Password: u.Password,
	}
}

type UserRepository struct {
	db *mongo.Collection
}

func NewUserRepository(db *mongo.Database, collection string) *UserRepository {
	return &UserRepository{
		db: db.Collection(collection),
	}
}

func (r *UserRepository) CreateUser(ctx context.Context, user *ModelUser) error {
	mongoModel := ToMongoUser(user)
	res, err := r.db.InsertOne(ctx, mongoModel)
	if err != nil {
		log.Println(err.Error())
		return err
	}

	user.ID = res.InsertedID.(primitive.ObjectID).Hex()
	return nil

}

func (r *UserRepository) GetUser(ctx context.Context, username, password string) (*ModelUser, error) {
	user := new(MongoUser)
	err := r.db.FindOne(ctx, bson.M{
		"username": username,
		"password": password,
	}).Decode(user)

	if err != nil {
		return nil, err
	}
	return ToModelUser(user), nil
}
