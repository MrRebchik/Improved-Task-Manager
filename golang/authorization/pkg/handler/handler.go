package handler

import (
	handler "authorization/pkg/handler/http/gin"
	"authorization/pkg/service"
	"github.com/gin-gonic/gin"
)

type HttpHandler interface {
	SignUpUser(ctx *gin.Context)
	SignInUser(ctx *gin.Context)
	GetSingleUser(ctx *gin.Context)
	GetPluralUser(ctx *gin.Context)
	DeleteUser(ctx *gin.Context)
	CreateUser(ctx *gin.Context)
	UpdateUser(ctx *gin.Context)
}

type BrokerHandler interface {
	// TODO methods
}

type Handler struct {
	HttpHandler
	BrokerHandler
}

func NewHandler(services *service.Service) *Handler {
	return &Handler{
		HttpHandler: handler.NewGinHttpHandler(services),
	}
}
