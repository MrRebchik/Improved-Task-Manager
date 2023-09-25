package handler

import (
	"authorization/pkg/service"
	"github.com/gin-gonic/gin"
)

type GinHttpHandler struct {
	services *service.Service
}

func NewGinHttpHandler(services *service.Service) *GinHttpHandler {
	return &GinHttpHandler{
		services: services,
	}
}

func (h *GinHttpHandler) InitRoutes() *gin.Engine {
	g := gin.New()

	auth := g.Group("/auth")
	{
		auth.POST("/sign-in")
		auth.POST("/sign-up")
	}

	api := auth.Group("/api")
	{
		api.GET("/")
		api.GET("/:id")
		api.POST("/")
		api.PUT("/")
		api.DELETE("/")
	}

	return g
}

func (h *GinHttpHandler) CreateUser(ctx *gin.Context) {
	// TODO
	return
}

func (h *GinHttpHandler) GetSingleUser(ctx *gin.Context) {
	// TODO
	return
}

func (h *GinHttpHandler) GetPluralUser(ctx *gin.Context) {
	// TODO
	return
}

func (h *GinHttpHandler) DeleteUser(ctx *gin.Context) {
	// TODO
	return
}

func (h *GinHttpHandler) UpdateUser(ctx *gin.Context) {
	return
}
