import json
from pathlib import Path


class Task:
    parameters = {}

    def __init__(self, title, **params):
        for param, value in params.items():
            self.parameters[param] = value
        json_str = json.dumps(self.parameters)
        path = Path(f'./classes/tasks/{self.parameters["date"]}.{title}.json')
        with open(path, 'w+') as f:
            f.write(json_str)
