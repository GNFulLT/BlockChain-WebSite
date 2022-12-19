@echo off

powershell -Command "& {docker run -p 9000:9000 --hostname taugateway --net tautoken-network taugateway}" 
pause