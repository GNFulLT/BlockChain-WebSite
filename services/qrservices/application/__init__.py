from flask import Flask
import os

app = Flask(__name__)

dir_path = os.path.dirname(os.path.realpath(__file__))
app.config['SECRET_KEY'] = '91eeae4ea4de376193d0f9c9eefa351780e2dc10'

app.config.update(
    UPLOAD_PATH=os.path.join(dir_path,"static")
)

from application import routes