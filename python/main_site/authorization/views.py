from django.shortcuts import render
from django.http import HttpResponse

from django.contrib import messages
from django.contrib.auth.forms import UserCreationForm


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
        return render(request, 'authorization/registration.html', {'form': user_reg_form})


def signin(request):
    pass
