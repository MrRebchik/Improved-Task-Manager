from flask import Flask
from flask import render_template
from flask import request
from flask import flash
from flask import redirect
from flask import url_for
from flask import session
from oop.classes import Task
import os
from flask_sqlalchemy import SQLAlchemy

basedir = os.path.abspath(os.path.dirname('../'))

app = Flask(__name__)
app.config['SECRET_KEY'] = 'a55a27362ac0c0b669849a161ee9c126c6afcbec809c4a4c'
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///' + os.path.join(basedir, 'database.db')
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False

db = SQLAlchemy(app)

messages = [{'title': 'Message One',
             'content': 'Message One Content'},
            {'title': 'Message Two',
             'content': 'Message Two Content'}
            ]

@app.route('/')
def index():
    return render_template('index.html', messages=messages)

@app.route('/registration/', methods=('GET', 'POST'))
def registration():
    if request.method == 'POST':
        login = request.form['login']
        password = request.form['password']

        if not login:
            flash('Login is required!')
        elif not password:
            flash('Password is required!')
        else:
            db.session.add(User(login=login, password=password))
            db.session.commit()
            return redirect(url_for('index'))
        return render_template('registration.html')


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
            db.session.commit()
            return redirect(url_for('index'))
    return render_template('create.html')

class User(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    login = db.Column(db.String(100), nullable=False)
    password = db.Column(db.String(100), nullable=False)
