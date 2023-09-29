package server

import (
	"github.com/sirupsen/logrus"
	"net/http"
)

type Server struct {
	httpServer *http.Server
}

func (s *Server) Run(port string, handler http.Handler) error {
	s.httpServer = &http.Server{
		Handler: handler,
		Addr:    ":" + port,
	}
	err := s.httpServer.ListenAndServe()

	if err != nil {
		logrus.Errorln("Error while starting server on port ", port)
		return err
	}
	return nil
}
