@echo off

powershell -Command "& {docker run -p 3333:3333 -e ASPNETCORE_URLS=http://+:3333 --net tautoken-network database-service}" 
pause