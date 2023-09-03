package main

import (
	"fmt"
	"github.com/spf13/viper"
	"log"
	"net/http"
)

func main() {
	if err := initConfig(); err != nil {
		log.Fatalf("%s", err.Error())
	}

	webPort := viper.GetString("port")

	log.Printf("Starting broker service on port %s", webPort)

	// define HTTP server
	srv := &http.Server{
		Addr: fmt.Sprintf(":%s", webPort),
	}

	if err := srv.ListenAndServe(); err != nil {
		log.Panic(err)
	}

}

func initConfig() error {
	viper.AddConfigPath("./configs")
	viper.SetConfigName("config")
	return viper.ReadInConfig()
}
