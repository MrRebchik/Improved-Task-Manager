package models

import (
	"encoding/json"
	"github.com/sirupsen/logrus"
)

type User struct {
	ID       string `json:"id,omitempty"`
	Username string `json:"username"`
	Password string `json:"password"`
}

func (u *User) UnmarshalJSONToUser(userJSON []byte) error {
	err := json.Unmarshal(userJSON, &u)

	if err != nil {
		logrus.Errorln("Error while unmarshalling userJSON")
		return err
	}

	logrus.Infoln("Unmarshalled user ", u.Username)

	return nil
}
