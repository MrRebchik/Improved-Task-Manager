package auth_http

import (
	"github.com/MrRebchik/Improved-Task-Manager/auth"
	"github.com/gin-gonic/gin"
	"net/http"
)

type Handler struct {
	service auth.Service
}

func NewHandler(service auth.Service) *Handler {
	return &Handler{
		service: service,
	}
}

type signInput struct {
	Username string `json:"username"`
	Password string `json:"password"`
}

func (h *Handler) SignUp(c *gin.Context) {
	inp := new(signInput)

	if err := c.BindJSON(inp); err != nil {
		c.AbortWithStatus(http.StatusBadRequest)
		return
	}

	if err := h.service.SignUp(c.Request.Context(), inp.Username, inp.Password); err != nil {
		c.AbortWithStatus(http.StatusInternalServerError)
		return
	}

	c.Status(http.StatusOK)
}
