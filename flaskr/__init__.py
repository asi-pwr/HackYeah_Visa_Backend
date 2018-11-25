import os
import json
import pusher

from flask import Flask, request
from . import visa_api_client

import opencv.recognize as rec
import opencv.opencv as cv

payments = []
subjects = ["", "Kuba", "Tomek", "Łukasz", "asia"]


def create_app(test_config=None):
    UPLOAD_FOLDER = '/upload'

    payment_counter = 0

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

            recognizer = cv.train_run(False)
            test_img1 = cv.cv2.imread("img.png")
            user_id = rec.recognize_by_img(test_img1, recognizer, subjects)

            data = json.load(request.files['data'])
            print(data)

            payment_id = len(payments) + 1

            new_payment = {"payment_id": payment_id, "user_id": user_id, "value": data['value'], "name": "Biedronka", "title": "Zakupy"}
            payments.append(new_payment)
            print(len(payments))

            pusher_client = pusher.Pusher(
                app_id='656893',
                key='35db3a17fbbf7b8a74b6',
                secret='f781af7bb696cbe97071',
                cluster='eu',
                ssl=True
            )

            pusher_client.trigger('my-channel', 'my-event',
                                  {'userId': user_id, 'paymentId': payment_id})
            return 'file uploaded successfully'

    @app.route('/payments/<id>', methods=['GET'])
    def get_payment_details(id):
        print(len(payments))
        if request.method == 'GET':
            return json.dumps(payments[int(id)])

    @app.route('/payments', methods=['POST'])
    def push_fund_transaction():
        if request.method == 'POST':
            # request.json.pin

            push_res = visa_api_client.push_fund_transactions()
            pull_res = visa_api_client.pull_fund_transactions()
            return 'Success'

    return app
