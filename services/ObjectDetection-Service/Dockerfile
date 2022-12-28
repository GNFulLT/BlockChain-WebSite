FROM python:3

RUN mkdir /app

COPY requirements.txt /app

WORKDIR /app

RUN pip install -r requirements.txt

COPY . .

CMD ["python","yolo_pretratined.py"]