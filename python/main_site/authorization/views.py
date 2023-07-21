from django.shortcuts import render, redirect
from django.http import HttpResponse

from django.contrib import messages
from django.contrib.auth.forms import UserCreationForm, AuthenticationForm
from django.contrib.auth import authenticate, login, logout


# Create your views here.

def signup(request):
    if request.method == 'POST':
        user_reg_form = UserCreationForm(request.POST)
        if user_reg_form.is_valid():
            user_reg_form.save()
            user = authenticate(request, username=request.POST['username'], password=request.POST['password'])
            login(request, user)
            return redirect('tasks')
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
            return redirect('tasks')
        else:
            return redirect('/users/signin')
    else:
        user_auth_form = AuthenticationForm()
        return render(request, 'authorization/signin.html', {'form': user_auth_form})


def logout_user(request):
    logout(request)
    return HttpResponse('Логаут')
