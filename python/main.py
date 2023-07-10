from flask import Flask
from flask import render_template
from flask import request
from flask import flash
from flask import redirect
from flask import url_for
from classes.classes import Task

app = Flask(__name__)
app.config['SECRET_KEY'] = 'a55a27362ac0c0b669849a161ee9c126c6afcbec809c4a4c'

messages = [{'title': 'Message One',
             'content': 'Message One Content'},
            {'title': 'Message Two',
             'content': 'Message Two Content'}
            ]

@app.route('/')
def index():
    return render_template('index.html', messages=messages)


@app.route('/create/', methods=('GET', 'POST'))
def create():
    if request.method == 'POST':
        title = request.form['title']
        content = request.form['content']
        date = request.form['date']

        if not title:
            flash('Title is required!')
        elif not content:
            flash('Content is required!')
        elif not date:
            flash('Date is required!')
        else:
            Task(title, **{'content': content, 'date': date})
            return redirect(url_for('index'))
    return render_template('create.html')

