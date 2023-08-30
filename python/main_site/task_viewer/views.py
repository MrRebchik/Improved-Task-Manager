from django.shortcuts import render
from django.http import HttpResponseRedirect
from django.conf import settings
from django.urls import reverse

from .forms import TaskForm

import json

import os
# Create your views here.


def task_read(request, user):
    user_task_dir = settings.BASE_DIR.parent.parent / f'users/{request.user.username}/tasks'
    if not os.path.exists(user_task_dir):
        os.mkdir(user_task_dir)
        with open(user_task_dir / '_NameNode.json', 'w') as f:
            json.dump({'user': request.user.username, 'task_ids': []}, f)
    tasks = []
    name_node_path = user_task_dir / '_NameNode.json'
    with open(name_node_path, 'r') as f:
        name_node = json.load(f)
    for i in name_node['task_ids']:
        task_path = user_task_dir / f'{i}.json'
        if not os.path.exists(task_path):
            name_node['task_ids'].remove(i)
            continue
        with open(user_task_dir / f'{i}.json', 'r') as curr_task_f:
            tasks.append(json.load(curr_task_f))
    with open(user_task_dir / '_NameNode.json', 'r+') as f:
        f.seek(0)
        f.truncate()
        json.dump(name_node, f)
    print(tasks)
    return render(request, 'task_viewer/task_read.html', {'tasks': tasks})


def task_create(request, user):
    user_task_dir = settings.BASE_DIR.parent.parent / f'users/{request.user.username}/tasks'
    if request.method == 'POST':
        form = TaskForm(request.POST)
        if form.is_valid():
            task_title = form.cleaned_data['title']
            task_date = str(form.cleaned_data['date'])
            with open(user_task_dir / '_NameNode.json', 'r+') as f:
                name_node = json.load(f)
                name_node['task_ids'].append(task_title)
                f.seek(0)
                f.truncate()
                json.dump(name_node, f)
            with open(user_task_dir / f'{task_title}.json', 'w') as f:
                json.dump({'title': task_title, 'date': task_date}, f)
            return HttpResponseRedirect(reverse('task_read', kwargs={'user': request.user.username}))
        else:
            form = TaskForm()
            return render(request, 'task_viewer/task_create.html', {'form': form})
    else:
        form = TaskForm()
        return render(request, 'task_viewer/task_create.html', {'form': form})

def task_delete(request, user, id):
    if request.method == 'POST':
        print('TSAR PIZDY')
        user_task_dir = settings.BASE_DIR.parent.parent / f'users/{request.user.username}/tasks'
        os.remove(user_task_dir / (id + '.json'))
        if not os.path.exists(user_task_dir / str(id)):
            with open(user_task_dir / '_NameNode.json', 'r+') as f:
                name_node = json.load(f)
                name_node['task_ids'].remove(id)
                f.seek(0)
                f.truncate()
                json.dump(name_node, f)
    return HttpResponseRedirect('/')

