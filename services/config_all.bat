@echo off

for /f %%i in ('docker network ls -qf "name=tautoken-network"') do if not "%%i" == "" (
    echo Network is already created with id %%i. Restarting ...
    docker network rm %%i
  )

echo "Network is creating tautoken-network
docker network create -d bridge tautoken-network

echo Network is successfully created. Building services

echo Taueureka Discovery Service building

call ./build_taueureka.bat

echo Taugateway Service building

call ./build_taugateway.bat

echo Database Service building

call ./build_database_service.bat

echo Now you can start up_all.bat

pause