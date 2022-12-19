@echo off

for /f %%i in ('docker ps -aqf "name=taugateway"') do If not "%%i" == "" (
    echo "There is containers with same name or previous build. Deleting ..."
    docker rm -f %%i
  )

cd ./taugateway

powershell -Command "& {docker build . -t taugateway}"

