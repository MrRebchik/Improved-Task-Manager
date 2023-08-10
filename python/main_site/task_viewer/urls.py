from django.urls import path

from .views import task_read, task_create, task_delete

urlpatterns = [
    path('tasks/', task_read, name='task_read'),
    path('tasks/create', task_create, name='task_create'),
    path('tasks/delete/<str:id>', task_delete, name='task_delete'),
]
