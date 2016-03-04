node tools/fable2babel.js --projFile test/Fable.Tests.fsproj
call npm run test
cd test\helloworld
node ../../tools/fable2babel.js --projFile HelloWorld.fsx
cd ..\..
if not exist "C:\temp" mkdir C:\temp
copy test\helloworld C:\temp
node tools\fable2babel.js --projFile "C:\Temp\HelloWorld.fsproj"
cd sample\node\server
call npm install
cd ..\..\..
node tools/fable2babel.js --projFile sample/node/server/app.fsx
cd sample\browser\todomvc
call npm install
cd ..\..\..
node tools/fable2babel.js --projFile sample/browser/todomvc/app.fsx
for /F %%A in ('powershell -Command "(Start-Process -PassThru -FilePath 'node' -ArgumentList 'sample/node/server/app.js 8090').Id"') do set PID=%%A
timeout /t 10
taskkill /PID %PID%  
