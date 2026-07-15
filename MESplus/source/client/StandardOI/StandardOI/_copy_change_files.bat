@echo off
REM %1 : Project Directory
REM %2 : Target Directory

xcopy %1\ChangeFiles\MESOI_logo.png %2 /d/r/y
xcopy %1\ChangeFiles\MainImage.png %2 /d/r/y
xcopy %1\ChangeFiles\MESCaption.xml %2 /d/r/y
xcopy %1\ChangeFiles\MESMessage.xml %2 /d/r/y
xcopy %1\ChangeFiles\errorsound.wav %2 /d/r/y