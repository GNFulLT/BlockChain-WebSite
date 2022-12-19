@echo off

powershell -Command "& {docker run -p 8761:8761 --hostname taueureka --net tautoken-network taueureka}"
pause