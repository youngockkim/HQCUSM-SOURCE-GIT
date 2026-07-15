@echo off
REM %1 : Visual Studio C++ Directory
REM %2 : Platform
REM %3 : Solution Configuration

if /i %2 == win32	goto x86
if /i %2 == Win32	goto x86
if /i %2 == WIN32	goto x86
if /i %2 == x64		goto x64
if /i %2 == X64		goto x64
goto :eof

REM Call visual studio environment batch file
:x86
call %1\vcvarsall.bat x86
goto build

:x64
call %1\vcvarsall.bat x64
goto build

:build
REM to switch Oracle 10g/11g
set PATH_OLD=%PATH%
set PATH=%ORA_HOME%\bin;%PATH%

set MESHOME_DIR=.\..\
set MESSERVER_DIR=.\server\MESServer
set ADMSERVER_DIR=.\server\ADMServer
set ARCHIVE_DIR=.\server\MESArchive
set BATSERVER_DIR=.\server\BATServer

set MESSERVER_SLN=%MESSERVER_DIR%\MESServer.sln
set ADMSERVER_SLN=%ADMSERVER_DIR%\ADMServer.sln
set ARCHIVE_SLN=%ARCHIVE_DIR%\MESArchive.sln
set BATSERVER_SLN=%BATSERVER_DIR%\BATServer.sln

del %MESHOME_DIR%\inc\*.h
del %MESHOME_DIR%\inc\dbinc\*.h

copy ..\..\..\AddLib_MES.bat .\library\MES_DBCmn\AddLib.bat /y
copy ..\..\..\AddLib_ADM.bat .\library\ADM_DBCmn\AddLib.bat /y
copy ..\..\..\AddLib_MES.bat .\library\BAT_DBCmn\AddLib.bat /y

xcopy .\library\ADM_DBCmn\*.h %MESHOME_DIR%\inc\dbinc /d/r/y
xcopy .\library\MES_DBCmn\*.h %MESHOME_DIR%\inc\dbinc /d/r/y
xcopy .\library\BAT_DBCmn\*.h %MESHOME_DIR%\inc\dbinc /d/r/y
xcopy .\library\Miracom_ACTCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_ADMCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_ALMCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_ARCCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_BASCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_BATCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_BOMCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_COMCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_EDCCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_FMBCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_INVCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_LOGCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_MANCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_MESCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_MSGCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_ORDCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_POPCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_QCMCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_RASCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_RCPCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_RTDCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_SECCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_SLCCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_SLPCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_SPCCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_SVMCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_TRSCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_WIPCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_SPMCore\*.h %MESHOME_DIR%\inc /d/r/y
xcopy .\library\Miracom_WEMCore\*.h %MESHOME_DIR%\inc /d/r/y

xcopy %MESSERVER_DIR%\*.h %MESHOME_DIR%\inc /d/r/y
xcopy %ADMSERVER_DIR%\*.h %MESHOME_DIR%\inc /d/r/y
xcopy %BATSERVER_DIR%\*.h %MESHOME_DIR%\inc /d/r/y


REM ###### MESServer ######
echo ========================================================
echo Build MESServer 1
echo ORA_HOME=%ORA_HOME%
echo ========================================================

call .\zBuild\zWinBuilder %MESSERVER_SLN% %3 %2
IF %ERRORLEVEL% EQU 0 goto ADMIN

echo Build MESServer 2
call .\zBuild\zWinBuilder %MESSERVER_SLN% %3 %2
IF %ERRORLEVEL% EQU 0 goto ADMIN

echo Build MESServer 3
call .\zBuild\zWinBuilder %MESSERVER_SLN% %3 %2
IF %ERRORLEVEL% NEQ 0 goto :eof

:ADMIN
REM ###### ADMServer ######
echo ========================================================
echo Build ADMServer 1
echo ========================================================

call .\zBuild\zWinBuilder %ADMSERVER_SLN% %3 %2
IF %ERRORLEVEL% EQU 0 goto BATJOB

echo Build ADMServer 2
call .\zBuild\zWinBuilder %ADMSERVER_SLN% %3 %2
IF %ERRORLEVEL% EQU 0 goto BATJOB

echo Build ADMServer 3
call .\zBuild\zWinBuilder %ADMSERVER_SLN% %3 %2
IF %ERRORLEVEL% NEQ 0 goto :eof

:BATJOB
REM ###### BATServer ######
echo ========================================================
echo Build BATServer 1
echo ========================================================

call .\zBuild\zWinBuilder %BATSERVER_SLN% %3 %2
IF %ERRORLEVEL% EQU 0 goto ARCHIVE

echo Build BATServer 2
call .\zBuild\zWinBuilder %BATSERVER_SLN% %3 %2
IF %ERRORLEVEL% EQU 0 goto ARCHIVE

echo Build BATServer 3
call .\zBuild\zWinBuilder %BATSERVER_SLN% %3 %2
IF %ERRORLEVEL% NEQ 0 goto :eof

:ARCHIVE
REM ###### MESArchive ######
echo ========================================================
echo Build MESArchive 1
echo ========================================================

if /i %3 == Release				goto ACH_REL
if /i %3 == Release_TibRv		goto ACH_REL
if /i %3 == Release_11g			goto ACH_REL_11G
if /i %3 == Release_TibRv_11g	goto ACH_REL_11G
goto :eof

:ACH_REL
call .\zBuild\zWinBuilder %ARCHIVE_SLN% Release %2
IF %ERRORLEVEL% EQU 0 goto SUCCESS

echo Build MESArchive 2
call .\zBuild\zWinBuilder %ARCHIVE_SLN% Release %2
IF %ERRORLEVEL% EQU 0 goto SUCCESS

echo Build MESArchive 3
call .\zBuild\zWinBuilder %ARCHIVE_SLN% Release %2
IF %ERRORLEVEL% NEQ 0 goto :eof

:ACH_REL_11G
call .\zBuild\zWinBuilder %ARCHIVE_SLN% Release_11g %2
IF %ERRORLEVEL% EQU 0 goto SUCCESS

echo Build MESArchive 2
call .\zBuild\zWinBuilder %ARCHIVE_SLN% Release_11g %2
IF %ERRORLEVEL% EQU 0 goto SUCCESS

echo Build MESArchive 3
call .\zBuild\zWinBuilder %ARCHIVE_SLN% Release_11g %2
IF %ERRORLEVEL% NEQ 0 goto :eof

:SUCCESS
echo ========================================================
echo Build Finished at %date% %time%
echo ========================================================

REM restore original path
set PATH=%PATH_OLD%

echo:
echo BUILD SUCCESSFUL
echo:
