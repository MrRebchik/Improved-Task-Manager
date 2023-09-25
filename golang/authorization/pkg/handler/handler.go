package handler

import (
	handler "authorization/pkg/handler/http"
	"authorization/pkg/service"
	"github.com/gin-gonic/gin"
)

type HttpHandler interface {
	GetSingleUser(ctx *gin.Context)
	GetPluralUser(ctx *gin.Context)
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
