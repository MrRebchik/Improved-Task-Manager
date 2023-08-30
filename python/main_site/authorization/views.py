from django.shortcuts import render, redirect
from django.http import HttpResponse
from django.urls import reverse
from django.http import HttpResponseRedirect
from django.contrib import messages
from django.contrib.auth.forms import UserCreationForm, AuthenticationForm
from django.contrib.auth import authenticate, login, logout
from django.conf import settings


import os

# Create your views here.

def signup(request):
    if request.method == 'POST':
        user_reg_form = UserCreationForm(request.POST)
        if user_reg_form.is_valid():
            user_reg_form.save()
            user = authenticate(request, username=request.POST['username'], password=request.POST['password1'])
            login(request, user)
            os.mkdir(settings.BASE_DIR.parent.parent / f'users/{request.user.username}')
            return HttpResponseRedirect(reverse('task_read', kwargs={'user': request.user.username}))
        else:
            return redirect('/users/signup')
    else:
        user_reg_form = UserCreationForm()
        return render(request, 'authorization/signup.html', {'form': user_reg_form})


def signin(request):
    if request.method == 'POST':
        user = authenticate(request, username=request.POST['username'], password=request.POST['password'])
        if user is not None:
            login(request, user)
            return HttpResponseRedirect(reverse('task_read', kwargs={'user': request.user.username}))
        else:
            return redirect('/users/signin')
    else:
        user_auth_form = AuthenticationForm()
        return render(request, 'authorization/signin.html', {'form': user_auth_form})


def logout_user(request):
    logout(request)
    return HttpResponse('Логаут')
