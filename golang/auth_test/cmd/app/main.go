package main

import (
	"fmt"
	"github.com/spf13/viper"
	"log"
	"net/http"
)

func main() {

	if err := InitConfig(); err != nil {
		log.Fatalf(err.Error())
	}

	web_port := viper.GetString("port")

	fmt.Printf("Starting authorization service at port %s", web_port)

	srv := &http.Server{
		Addr: fmt.Sprintf(":%s", web_port),
	}

	if err := srv.ListenAndServe(); err != nil {
		log.Panic(err)
	}
}

func InitConfig() error {
	viper.AddConfigPath("./configs")
	viper.SetConfigName("config")
	return viper.ReadInConfig()
}
