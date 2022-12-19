@echo off

for /f %%i in ('docker ps -aqf "name=database-service"') do If not "%%i" == "" (
    echo "There is containers with same name or previous build. Deleting ..."
    docker rm -f %%i
  )

cd ./Database-Service

powershell -Command "& {docker build . -f .\Database-Service\Dockerfile -t database-service}"

