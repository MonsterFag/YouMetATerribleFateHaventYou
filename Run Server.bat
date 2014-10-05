@ECHO OFF


:ONCE
start "" "bin/Debug/Server/server.exe"

start "" "bin/Debug/wServer/wServer.exe"

:STARTS
TASKLIST | find "server.exe"

if errorlevel 1 goto RUNS

if errorlevel 2 goto RUNS

if errorlevel 3 goto RUNS

if errorlevel 4 goto RUNS

goto STARTW

:STARTW
TASKLIST | find "wServer.exe"

if errorlevel 1 goto RUNW

if errorlevel 2 goto RUNW

if errorlevel 3 goto RUNW

if errorlevel 4 goto RUNW

goto RESTART



:RESTART

TIMEOUT 5

goto STARTS



:RUNW

start "" "bin/Debug/wServer/wServer.exe"

goto RESTART



:RNUS

start "" "bin/Debug/Server/server.exe"

goto STARTS