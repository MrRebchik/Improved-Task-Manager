package handler

import (
	handler "authorization/pkg/handler/http/gin"
	"authorization/pkg/service"
	"github.com/gin-gonic/gin"
)

type HttpHandler interface {
	SignUpUser(c *gin.Context)
	SignInUser(c *gin.Context)
	GetSingleUser(c *gin.Context)
	GetPluralUser(c *gin.Context)
	DeleteUser(c *gin.Context)
	CreateUser(c *gin.Context)
	UpdateUser(c *gin.Context)
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
