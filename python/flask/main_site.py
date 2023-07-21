from flask import Flask
from flask import render_template
from flask import request
from flask import flash
from flask import redirect
from flask import url_for


from oop.classes import Task

from flask_login import login_required, LoginManager, login_user, UserMixin, logout_user

from flask_migrate import Migrate

from werkzeug.security import generate_password_hash, check_password_hash

import os

from flask_sqlalchemy import SQLAlchemy

messages = [{'title': 'Message One',
             'content': 'Message One Content'},
            {'title': 'Message Two',
             'content': 'Message Two Content'}
            ]

@app.route('/')
@login_required
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
            db.session.commit()
            return redirect(url_for('index'))
    return render_template('create.html')


