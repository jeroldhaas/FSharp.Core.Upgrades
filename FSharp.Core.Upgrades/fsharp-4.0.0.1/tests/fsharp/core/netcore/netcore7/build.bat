@if "%_echo%"=="" echo off
call %~d0%~p0..\..\..\..\config.bat

IF /I "%INSTALL_SKU%" NEQ "ULTIMATE" (
    echo Test not supported except on Ultimate
    exit /b 0
)

"%MSBUILDTOOLSPATH%\msbuild.exe" ..\netcore.sln /p:Configuration=Debug /p:TestProfile=Profile7 /t:Rebuild
exit /b %ERRORLEVEL%