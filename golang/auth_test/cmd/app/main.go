package main

import (
	"github.com/spf13/viper"
	"log"
)

func main() {

	if err := InitConfig(); err != nil {
		log.Fatalf(err.Error())
	}

	web_port := viper.GetString("port")
}

func InitConfig() error {
	viper.AddConfigPath("./configs/config.yml")
	viper.SetConfigName("config")
	return viper.ReadInConfig()
}
