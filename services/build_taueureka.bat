@echo off

for /f %%i in ('docker ps -aqf "name=taueureka"') do If not "%%i" == "" (
    echo "There is containers with same name or previous build. Deleting ..."
    docker rm -f %%i
  )

cd ./taueureka

powershell -Command "& {docker build . -t taueureka}"

