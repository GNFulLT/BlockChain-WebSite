from wtforms import StringField, SubmitField
from flask_wtf import FlaskForm
from wtforms.validators import DataRequired,Length


class QRCodeData(FlaskForm):
    data=StringField("Data",validators=[DataRequired(),Length(min=2, max=300)])
    submit=SubmitField("Generate QRCode")