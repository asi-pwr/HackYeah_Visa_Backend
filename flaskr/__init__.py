import os

from flask import Flask, request
from . import visa_api_client


def create_app(test_config=None):
    UPLOAD_FOLDER = '/upload'

    # create and configure the app
    app = Flask(__name__, instance_relative_config=True)
    app.config['UPLOAD_FOLDER'] = UPLOAD_FOLDER
    app.config.from_mapping(
        SECRET_KEY='dev',
        DATABASE=os.path.join(app.instance_path, 'flaskr.sqlite'),
    )

    if test_config is None:
        # load the instance config, if it exists, when not testing
        app.config.from_pyfile('config.py', silent=True)
    else:
        # load the test config if passed in
        app.config.from_mapping(test_config)

    # ensure the instance folder exists
    try:
        os.makedirs(app.instance_path)
    except OSError:
        pass

    # a simple page that says hello
    @app.route('/hello')
    def hello():
        return 'Hello, World!'

    @app.route('/uploader', methods=['GET', 'POST'])
    def upload_file():
        if request.method == 'POST':
            f = request.files['file']
            f.save("img.png")
            return 'file uploaded successfully'

    @app.route('/push', methods=['POST'])
    def push_fund_transaction():
        if request.method == 'POST':
            res = visa_api_client.push_fund_transactions()
            return res

    @app.route('/pull', methods=['POST'])
    def pull_fund_transaction():
        if request.method == 'POST':
            res = visa_api_client.pull_fund_transactions()
            return res

    return app
