::E:
::cd "E:\7sem\info protection\lab4"
::@echo off
::set /p directory="Enter file directory "
::cd %directory%
set /p file="File to archive "
set /p options="options file "
set /p name="Result archive name "
set /p icon="Icon file "
::set /p setup="File to run after unpack "
rar a -sfx -z"%options%" %name% -hp -m5 -ma -iicon%icon% %file%
pause