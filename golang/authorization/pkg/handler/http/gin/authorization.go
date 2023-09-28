package handler

import (
	"github.com/gin-gonic/gin"
	"net/http"
)

type AuthorizationForm struct {
	Username string `form:"username" binding:"required"`
	Password string `form:"username" binding:"required"`
}

func (h *GinHttpHandler) SignUpUser(c *gin.Context) {
	// TODO
	var loginForm AuthorizationForm
	err := c.Bind(&loginForm)
	if err != nil {
		c.AbortWithError(http.StatusInternalServerError, err)
		return
	}
	return
}

func (h *GinHttpHandler) SignInUser(c *gin.Context) {
	// TODO
	return
}
