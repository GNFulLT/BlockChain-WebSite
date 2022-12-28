@echo off

docker run -p 3000:3000 --network tautoken-network wallet-service

@pause