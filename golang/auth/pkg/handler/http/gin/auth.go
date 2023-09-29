package handler

import (
	"encoding/json"
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

	UserModelJSON, err := json.Marshal(signUpRequest)

	if err != nil {
		err = c.AbortWithError(http.StatusInternalServerError, err)
		return
	}

	_, err = h.services.CreateUser(UserModelJSON)

	signUpResponse := SignUpResponse{
		Error:       err,
		AccessToken: "",
	}

	c.JSON(http.StatusOK, signUpResponse)

	return
}

func (h *GinHttpHandler) SignInUser(c *gin.Context) {
	var signInRequest SignInRequest
	err := c.Bind(&signInRequest)
	if err != nil {
		err = c.AbortWithError(http.StatusInternalServerError, err)
		return
	}

	UserModelJSON, err := json.Marshal(signInRequest)

	if err != nil {
		err = c.AbortWithError(http.StatusInternalServerError, err)
		return
	}

	_, err = h.services.GetSingleUser(UserModelJSON)

	signUpResponse := SignInResponse{
		Error:       err,
		AccessToken: "",
	}

	c.JSON(http.StatusOK, signUpResponse)

	return
}
