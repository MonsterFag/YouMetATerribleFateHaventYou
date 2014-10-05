@echo off
set /p jm="Enter map name: "
copy %jm%.jm Json2wmapConv\bin\Debug
Json2wmapConv\bin\Debug\Json2wmapConv %jm%.jm %jm%.wmap
echo Compiled map!
echo Moving wmap to Worlds Folder
move %jm%.wmap wServer/realm/worlds/
echo Moved Map to Worlds Folder!
pause