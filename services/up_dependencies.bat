@echo off

echo Checking Services ...

for /f %%i in ('docker images -aq taueureka') do If not "%%i" == "" (
    echo Taueureka is ready. Starting ...
    start cmd /k call run_taueureka.bat
    timeout 15 > NUL

        for /f %%i in ('docker images -aq taugateway') do If not "%%i" == "" (
            echo Taugateway is ready
            start cmd /k call run_taugateway.bat
            timeout 15 > NUL
            for /f %%i in ('docker images -aq database-service') do If not "%%i" == "" (
                echo Database service is ready
                start cmd /k call run_database_service.bat
                echo You can up any server you want
                pause
                exit
            )
            echo Database-Service is not ready Please build database-service
            pause
             exit
        )
    echo Taugateway is not ready Please build taugateway 
    pause 
    exit
  )
  echo Taueureka is not ready Please build taueureka  
  pause
  exit