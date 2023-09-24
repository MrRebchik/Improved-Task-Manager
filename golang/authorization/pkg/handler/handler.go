package handler

import (
	"context"
)

type HttpHandler interface {
	GetUser(ctx *context.Context)
	CreateUser(ctx *context.Context)
}
