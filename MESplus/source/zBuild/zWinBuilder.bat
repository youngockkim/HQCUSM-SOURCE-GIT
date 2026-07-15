@echo off
REM %1 : Solution File
REM %2 : Solution Config Name
REM %3 : Platform

del MES_Build_Log.txt /Q
devenv.exe /build "%2|%3" %1 /Out MES_Build_Log.txt
