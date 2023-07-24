from django.shortcuts import render
from django.http import HttpResponse
from django.conf import settings

import json

import os
# Create your views here.


def task_list(request, user):
    user_task_dir = settings.BASE_DIR.parent.parent / f'users/{user}/tasks'
    if not os.path.exists(user_task_dir):
        os.mkdir(user_task_dir)
        with open(user_task_dir / '_NameNode.json', 'w') as f:
            json.dump({'user': user, 'task_ids': []}, f)
    tasks = []
    name_node_path = user_task_dir / '_NameNode.json'
    with open(name_node_path, 'r') as f:
        name_node = json.load(f)
    for i in name_node['task_ids']:
        with open(user_task_dir / i, 'r') as curr_task_f:
            tasks.append(curr_task_f)
    return render(request, 'task_viewer/task_list.html', {'tasks': tasks})

def read_task_for_list():
    pass