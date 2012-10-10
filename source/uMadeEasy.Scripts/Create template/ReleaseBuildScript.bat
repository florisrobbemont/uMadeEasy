REM Example: "C:\Development\Github\uMadeEasy\source\uMadeEasy.Scripts\Create template\ReleaseBuildScript.bat" "C:\Development\Github\uMadeEasy\source\uMadeEasy.ProjectGenerator\bin\Debug\Templates\FirstTemplate" "C:\Development\Github\uMadeEasy\templates\Umbraco 4.7"

@echo OFF

REM TemplateDir = %~f1
REM OutputPath = %~f2

set template_database_name="Umb-UmbTemplate"
set template_database_server="ntlucra6.lucrasoft.local"

set curr_dir=%cd%
REM chdir /D %~f1\

REM Create Database Dump

REM First remove it
del "%~f1\SqlDatabaseScript.sql"

set SqlPubWiz=%ProgramFiles%
if "%PROCESSOR_ARCHITECTURE%"=="AMD64" set SqlPubWiz=%ProgramFiles(x86)%

set SqlPubWizPath="%SqlPubWiz%\Microsoft SQL Server\90\Tools\Publishing\1.4\SqlPubWiz.exe"
%SqlPubWizPath% script -targetserver 2008 -d %template_database_name% -S %template_database_server% "%~f2\SqlDatabaseScript.sql"

robocopy "%~f1" "%~f2" /E

chdir /D %curr_dir%

REM exit 0