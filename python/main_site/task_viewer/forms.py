from django import forms


class TaskForm(forms.Form):
    title = forms.CharField(label='Task title', max_length=2000)
    date = forms.DateField(label='Task date')


