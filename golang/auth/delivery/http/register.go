package auth_http

import (
	"github.com/MrRebchik/Improved-Task-Manager/auth"
	"github.com/gin-gonic/gin"
)

func RegisterHTTPEndpoints(router *gin.Engine, s auth.Service) {
	h := NewHandler(s)

	authEndpoints := router.Group("/auth")
	{
		authEndpoints.POST("/sign-up", h.SignUp)
		//authEndpoints.POST("/sign-in", h.SignIn)
	}
}
