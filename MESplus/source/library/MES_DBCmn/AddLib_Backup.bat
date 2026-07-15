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
del %2\%1.*

REM Set system environment variable "ORA_HOME" - xxxx\Oracle\Ora11g

REM ---------------------
REM  VS2010 Standard Debug, Release Mode
REM ---------------------

IF %1 == DBC_mwipfacdef (
REM If it want to skip SQLCHECK then use as below.
    proc PARSE=PARTIAL iname=%1 oname=%2\%1.c include="..\..\..\inc\dbinc" include="C:\Program Files (x86)\Microsoft Visual Studio 10.0\VC\include" include="%ORA_HOME%\precomp\public" define="_ALM" define="_BOM" define="_EDC" define="_FMB" define="_INV" define="_ORD" define="_POP" define="_QCM" define="_RAS" define="_RCP" define="_RTD" define="_SPC" define="_WIP" define="_CRR" define="_TOOL"
) ELSE IF %1 == DBC_semantics_file (
REM If it used Stored Procedure in PC file then use as below.
    proc PARSE=PARTIAL SQLCHECK=SEMANTICS USERID=mesmgr/mesmgr@QCEL_PC_DEV iname=%1 oname=%2\%1.c include="..\..\..\inc\dbinc" include="C:\Program Files (x86)\Microsoft Visual Studio 10.0\VC\include" include="%ORA_HOME%\precomp\public" define="_ALM" define="_BOM" define="_EDC" define="_FMB" define="_INV" define="_ORD" define="_POP" define="_QCM" define="_RAS" define="_RCP" define="_RTD" define="_SPC" define="_WIP" define="_CRR" define="_TOOL"
) ELSE (
REM Normal PC files
    proc PARSE=PARTIAL SQLCHECK=FULL USERID=mesmgr/mesmgr@QCEL_PC_DEV iname=%1 oname=%2\%1.c include="..\..\..\inc\dbinc" include="C:\Program Files (x86)\Microsoft Visual Studio 10.0\VC\include" include="%ORA_HOME%\precomp\public" define="_ALM" define="_BOM" define="_EDC" define="_FMB" define="_INV" define="_ORD" define="_POP" define="_QCM" define="_RAS" define="_RCP" define="_RTD" define="_SPC" define="_WIP" define="_CRR" define="_TOOL"
)

cd %2

cl /c %1.c /I "..\..\..\..\inc\dbinc" /I "%ORA_HOME%\precomp\public" /MT /D "_CRT_SECURE_NO_DEPRECATE" /D "_ALM" /D "_BOM" /D "_EDC" /D "_FMB" /D "_INV" /D "_ORD" /D "_POP" /D "_QCM" /D "_RAS" /D "_RCP" /D "_RTD" /D "_SPC" /D "_WIP" /D "_CRR" /D "_TOOL"

REM If you necessary debugging, then set below option.
REM cl /c /Zi %1.c ~


IF EXIST %3.lib (
    lib %3.lib %1.obj
) ELSE (
    lib /out:%3.lib %1.obj
)

IF %1 == DBC_common (
REM If it use another C file related the PC file then use as below
    copy ..\%1_c.c .
    cl /c %1_c.c /I "..\..\..\..\inc\dbinc" /I "%ORA_HOME%\precomp\public" /MT /D "_CRT_SECURE_NO_DEPRECATE" /D "_ALM" /D "_BOM" /D "_EDC" /D "_FMB" /D "_INV" /D "_ORD" /D "_POP" /D "_QCM" /D "_RAS" /D "_RCP" /D "_RTD" /D "_SPC" /D "_WIP" /D "_CRR" /D "_TOOL"
    lib %3.lib %1_c.obj
)

xcopy %3.lib ..\..\..\..\lib /r/y
