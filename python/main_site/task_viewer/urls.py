from django.urls import path

from .views import task_list, task_create

urlpatterns = [
    path('tasks/', task_list, name='task_list'),
    path('tasks/create', task_create, name='task_create')
]
