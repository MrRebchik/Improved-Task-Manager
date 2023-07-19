from django.shortcuts import render
from django.http import HttpResponse


from django.contrib.auth.forms import UserCreationForm


# Create your views here.

def registration(request):
    user_reg_form = UserCreationForm()
    return render(request, 'authorization/registration.html', {'form': user_reg_form})
