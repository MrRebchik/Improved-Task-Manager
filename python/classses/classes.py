import json


class Task:
    parameters = {}

    def __init__(self, name, **params):
        for param, value in params.items():
            self.parameters[param] = value
        json_str = json.dumps(self.parameters)
        with open(f'{name}', 'w') as f:
            f.write(json_str)
