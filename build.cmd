@echo off
cls

call npm install

.paket\paket.bootstrapper.exe
if errorlevel 1 (
  exit /b %errorlevel%
)

.paket\paket.exe restore
if errorlevel 1 (
  exit /b %errorlevel%
)

xcopy patches\*.* packages\ /S /Y

packages\FAKE\tools\FAKE.exe build.fsx %*
