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
		auth.POST("/sign-in", h.SignInUser)
		auth.POST("/sign-up", h.SignUpUser)
	}

	api := auth.Group("/api")
	{
		api.GET("/", h.GetPluralUser)
		api.GET("/:id", h.GetSingleUser)
		api.POST("/", h.CreateUser)
		api.PUT("/", h.UpdateUser)
		api.DELETE("/", h.DeleteUser)
	}

	return g
}
