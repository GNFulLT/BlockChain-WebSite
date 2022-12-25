@echo off

cd ./Authentication-Service

docker build . -f .\Authentication-Service\Dockerfile -t auth-service

@pause