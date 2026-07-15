@echo off

REM sleep 15 seconds
ping -n 15 localhost >NUL

rmdir /S /Q MESplusV5

mkdir MESplusV5
mkdir MESplusV5\bin
mkdir MESplusV5\cmd
mkdir MESplusV5\data
mkdir MESplusV5\inc
mkdir MESplusV5\lic
mkdir MESplusV5\lib
mkdir MESplusV5\log
mkdir MESplusV5\mail
mkdir MESplusV5\source
mkdir MESplusV5\temp
mkdir MESplusV5\upgrade

copy bin\*.exe                 MESplusV5\bin
copy bin\MESServer.exe         MESplusV5\bin\RTDServer.exe

copy cmd\Sample_ADMServer.ini  MESplusV5\cmd\ADMServer.ini
copy cmd\Sample_MESplus.ini    MESplusV5\cmd\MESplus.ini
copy cmd\Sample_MESServer.ini  MESplusV5\cmd\MESServer.ini
copy cmd\Sample_RTDServer.ini  MESplusV5\cmd\RTDServer.ini
copy cmd\Sample_BATServer.ini  MESplusV5\cmd\BATServer.ini
copy cmd\startADMServer.bat    MESplusV5\cmd\
copy cmd\startMESServer.bat    MESplusV5\cmd\
copy cmd\startRTDServer.bat    MESplusV5\cmd\
copy cmd\startBATServer.bat    MESplusV5\cmd\
copy cmd\stopADMServer.bat     MESplusV5\cmd\
copy cmd\stopMESServer.bat     MESplusV5\cmd\
copy cmd\stopRTDServer.bat     MESplusV5\cmd\
copy cmd\stopBATServer.bat     MESplusV5\cmd\

xcopy inc                      MESplusV5\inc\ /S
xcopy lib                      MESplusV5\lib\ /S
xcopy data                     MESplusV5\data\ /S

REM ##### Copy Server Source #####
del zExclude.dat /Q

echo \obj       >  zExclude.dat
echo \Release   >> zExclude.dat
echo \Debug     >> zExclude.dat
echo \x64       >> zExclude.dat
echo \output    >> zExclude.dat
echo .obj       >> zExclude.dat
echo .ncb       >> zExclude.dat
echo .user      >> zExclude.dat
echo Miracom_   >> zExclude.dat
echo UT_        >> zExclude.dat
xcopy source                   MESplusV5\source\ /S/EXCLUDE:zExclude.dat
rmdir /S /Q                    MESplusV5\source\batch
rmdir /S /Q                    MESplusV5\source\loader
rmdir /S /Q                    MESplusV5\source\util
rmdir /S /Q                    MESplusV5\source\server\MESArchive
rmdir /S /Q                    MESplusV5\source\server\ADMServer
del zExclude.dat /Q

copy version.txt               MESplusV5\z%buildVersion%.ver


zip -r %artifactsDir%\%buildVersion%-WITHCODE.zip MESplusV5\*

rmdir /S /Q MESplusV5\source

zip -r %artifactsDir%\%buildVersion%-NOCODE.zip MESplusV5\*

rmdir /S /Q MESplusV5

echo:
echo BUILD SUCCESSFUL
echo:
