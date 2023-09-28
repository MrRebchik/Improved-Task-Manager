package handler

import (
	"authorization/models"
	"github.com/gin-gonic/gin"
	"net/http"
)

type SignUpRequest struct {
	Username string `form:"username" binding:"required"`
	Password string `form:"username" binding:"required"`
}

type SignInRequest struct {
	Username string `json:"username" binding:"required"`
	Password string `json:"password" binding:"required"`
}

type SignUpResponse struct {
	AccessToken string `json:"access_token"`
	Error       error  `json:"error"`
}

type SignInResponse struct {
	AccessToken string `json:"access_token"`
	Error       error  `json:"error"`
}

func (h *GinHttpHandler) SignUpUser(c *gin.Context) {
	var signUpRequest SignUpRequest
	err := c.Bind(&signUpRequest)
	if err != nil {
		err = c.AbortWithError(http.StatusInternalServerError, err)
		return
	}

	UserModel := &models.User{
		Username: signUpRequest.Username,
		Password: signUpRequest.Password,
	}

	UserModel, err = h.services.CreateUser(UserModel)

	signUpResponse := SignUpResponse{
		Error:       err,
		AccessToken: "",
	}

	c.JSON(http.StatusOK, signUpResponse)

	return
}

func (h *GinHttpHandler) SignInUser(c *gin.Context) {
	// TODO
	return
}
