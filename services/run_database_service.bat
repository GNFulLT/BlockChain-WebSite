@echo off

powershell -Command "& {docker run --net tautoken-network database-service}" 
pause