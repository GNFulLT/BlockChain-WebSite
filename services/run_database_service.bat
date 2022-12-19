@echo off

powershell -Command "& {docker run -p 443:443 -e ASPNETCORE_URLS=https://+:443 --net tautoken-network database-service}" 
pause