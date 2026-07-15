@echo off
REM %1 : Target MESplus Home
REM %2 : Start server flag, if value is "N" then do not start server.

set MESHOME_DIR=.\..\
set CURRUNT_DIR=%CD%

cd %1\cmd

call stopMESServer.bat
call stopADMServer.bat
call stopRTDServer.bat
call stopBATServer.bat

REM sleep 10 seconds
ping -n 10 localhost >NUL


cd %CURRUNT_DIR%

copy %MESHOME_DIR%\bin\*.exe %1\bin /y
copy %MESHOME_DIR%\bin\MESServer.exe %1\bin\RTDServer.exe /y

cd %1\cmd

if %2=="N"	goto SUCCESS

REM sleep 3 seconds
ping -n 3 localhost >NUL

call startMESServer.bat
call startADMServer.bat
call startRTDServer.bat
call startBATServer.bat

:SUCCESS
cd %CURRUNT_DIR%

echo:
echo BUILD SUCCESSFUL
echo:
