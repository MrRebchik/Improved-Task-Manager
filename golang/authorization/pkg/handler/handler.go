package handler

import (
	"authorization/pkg/service"
	"context"
)

type HttpHandler interface {
	GetUser(ctx *context.Context)
	CreateUser(ctx *context.Context)
}

type BrokerHandler interface {
	// TODO methods
}

type Handler struct {
	HttpHandler
	BrokerHandler
}

func NewHandler(services service.Service) *Handler {
	return &Handler{
		// TODO Handler return
	}
}
