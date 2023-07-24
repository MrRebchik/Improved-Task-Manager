from django.shortcuts import render
from django.http import HttpResponse
from django.conf import settings

import json

import os
# Create your views here.


def task_list(request, user):
    user_task_dir = settings.BASE_DIR.parent.parent / f'tasks/{user}'
    if not os.path.exists(user_task_dir):
        os.mkdir(user_task_dir)
        with open(user_task_dir / '_NameNode.json', 'w') as f:
            json.dump({'user': user, 'task_ids': []}, f)
    return HttpResponse('Пописал')