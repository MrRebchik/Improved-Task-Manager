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

basedir = os.path.abspath(os.path.dirname('../'))

app = Flask(__name__)
app.config['SECRET_KEY'] = 'a55a27362ac0c0b669849a161ee9c126c6afcbec809c4a4c'
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///' + os.path.join(basedir, 'database.db')
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False

login_manager = LoginManager(app)
login_manager.login_view = 'login'

db = SQLAlchemy(app)
migrate = Migrate(app, db)

messages = [{'title': 'Message One',
             'content': 'Message One Content'},
            {'title': 'Message Two',
             'content': 'Message Two Content'}
            ]

@app.route('/')
@login_required
def index():
    return render_template('index.html', messages=messages)

@app.route('/registration/', methods=('GET', 'POST'))
def registration():
    if request.method == 'POST':
        u_login = request.form['login']
        u_password = generate_password_hash(request.form['password'])

        if not u_login:
            flash('Login is required!')
        elif not u_password:
            flash('Password is required!')
        else:
            db.session.add(User(login=u_login, password=u_password))
            db.session.commit()
            return redirect(url_for('index'))
    return render_template('registration.html')


@app.route('/login/', methods=('GET', 'POST'))
def login():
    if request.method == 'POST':
        u_login = request.form['login']
        u_password = request.form['password']

        if not u_login:
            flash('Login is required!')
        elif not u_password:
            flash('Password is required!')
        else:
            qr = db.session.query(User).filter_by(login=u_login).first()
            if qr:
                if check_password_hash(qr.password, u_password):
                    login_user(qr)
                    return redirect(url_for('index'))
            else:
                return '<p>Пользователь не найден!</p>'
    return render_template('login.html')

@app.route('/logout')
@login_required
def logout():
    logout_user()
    return redirect(url_for('login'))


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


@login_manager.user_loader
def load_user(user_id):
    qr = db.session.query(User).filter_by(id=user_id).first()
    if qr:
        return qr
    return None

class User(db.Model, UserMixin):
    id = db.Column(db.Integer, primary_key=True)
    login = db.Column(db.String(100), nullable=False)
    password = db.Column(db.String(100), nullable=False)

