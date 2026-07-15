REM %1 : PC file name except extention.
REM %2 : The path of precompiled C file.
REM %3 : Library name.
REM %4 : Visual Studio C++ Directory

echo:
echo ===== PRO C/C++ Compile : %1.pc ==============================
echo:

REM Call visual studeo environment batch file
REM ---------------------
REM call %4\vcvarsall.bat x86
call %4\vcvarsall.bat x64
REM ---------------------

REM Copy all modified header file
xcopy .\*.h ..\..\..\inc\dbinc /d/r/y 

REM Delete C and Obj files
del %2\%1.c
del %2\%1.obj

REM Set system environment vriable "ORA_HOME" - xxxx\Oracle\Ora10g

REM ---------------------
REM  VS2005 Standard Debug, Release Mode
REM ---------------------
REM proc PARSE=PARTIAL SQLCHECK=FULL USERID=mesmgr/mesmgr@ORAMES iname=%1 oname=%2\%1.c include="..\..\..\inc\dbinc" include="%VCINSTALLDIR%\include" include="%ORA_HOME%\oci\include" include="%ORA_HOME%\precomp\public"
proc PARSE=PARTIAL SQLCHECK=SYNTAX iname=%1 oname=%2\%1.c include="..\..\..\inc\dbinc" include="%VCINSTALLDIR%\include" include="%ORA_HOME%\oci\include" include="%ORA_HOME%\precomp\public"

cd %2

cl /c %1.c /I "..\..\..\..\inc\dbinc" /I "%ORA_HOME%\precomp\public" /MT /D "_CRT_SECURE_NO_DEPRECATE"

REM If you necessary debugging, then set below option.
REM cl /c /Zi %1.c ~


IF EXIST %3.lib (
lib %3.lib %1.obj
) ELSE (
lib /out:%3.lib %1.obj
)

xcopy %3.lib ..\..\..\..\lib /r/y
