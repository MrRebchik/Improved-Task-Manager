package main

import (
	"fmt"
	"github.com/spf13/viper"
	"html/template"
	"log"
	"net/http"
)

func main() {
	//if err := initConfig(); err != nil {
	//	log.Fatalf("%s", err.Error())
	//}

	http.HandleFunc("/", func(w http.ResponseWriter, r *http.Request) {
		render(w, "welcome_page.gohtml")
	})

	fmt.Println("Starting server on :8000")
	err := http.ListenAndServe(":8000", nil)
	if err != nil {
		log.Panic(err)
	}
	//app := server.NewApp()
	//
	//if err := app.Run(viper.GetString("port")); err != nil {
	//	log.Fatalf("%s", err.Error())
	//}
}

func render(w http.ResponseWriter, t string) {

	partials := []string{
		"./front/templates/base.layout.gohtml",
		"./front/templates/header.partial.gohtml",
		"./front/templates/footer.partial.gohtml",
	}

	var templateSlice []string
	templateSlice = append(templateSlice, fmt.Sprintf("./front/templates/%s", t))

	for _, x := range partials {
		templateSlice = append(templateSlice, x)
	}

	tmpl, err := template.ParseFiles(templateSlice...)
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}

	if err := tmpl.Execute(w, nil); err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
	}

}

func initConfig() error {
	viper.AddConfigPath("./configs")
	viper.SetConfigName("config")
	return viper.ReadInConfig()
}
