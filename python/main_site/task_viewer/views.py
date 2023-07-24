from django.shortcuts import render
from django.http import HttpResponse
from django.conf import settings

import os
# Create your views here.


def task_list(request, user):
    if not os.path.exists(settings.BASE_DIR.parent.parent / f'tasks/{user}'):
        os.mkdir(settings.BASE_DIR.parent.parent / f'tasks/{user}')
        return HttpResponse('Папка создана')
    else:
        return HttpResponse('Папка есть')
