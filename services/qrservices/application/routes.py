from application import app
from flask import render_template,request
from application.forms import QRCodeData
import secrets
import qrcode

@app.route("/index")
def index():
    return render_template("layout.html",title="Home Page")

@app.route("/generate_qrcode", methods=["POST","GET"])
def index_page():
    form = QRCodeData()
    if request.method == "POST" :
        if form.validate_on_submit():
            data = form.data.data
            image_name= f"{secrets.token_hex(10)}.png"
            qrcode_location = f"{app.config['UPLOAD_PATH']}/{image_name}"

            try:
                my_qrcode = qrcode.make(str(data))
                my_qrcode.save(qrcode_location)
            except Exception as e:
                print(e)
            return render_template("generated_qrcode.html",title="Generated",image=image_name)
    else:
        return render_template("generate_qrcode.html",title="Generate QRCode  Page",form=form)