from django.shortcuts import render
from django.http import HttpResponse

from django.contrib import messages
from django.contrib.auth.forms import UserCreationForm, AuthenticationForm
from django.contrib.auth.models import User


# Create your views here.

def signup(request):
    if request.method == 'POST':
        user_reg_form = UserCreationForm(request.POST)
        if user_reg_form.is_valid():
            user_reg_form.save()
            messages.success(request, 'Успешно рега')
            return HttpResponse('<h1>Govno</h1>')
        else:
            return HttpResponse('<p>Вы обосрались</p>')
    else:
        user_reg_form = UserCreationForm()
        return render(request, 'authorization/signup.html', {'form': user_reg_form})


def signin(request):
    if request.method == 'POST':
        user_auth_form = AuthenticationForm(request.POST)
    else:
        user_auth_form = AuthenticationForm()
        return render(request, 'authorization/signin.html', {'form': user_auth_form})
