@echo off

docker run -p 6379:6379 --network tautoken-network --name redis-server -d redis --save 60 1 --loglevel warning

pause