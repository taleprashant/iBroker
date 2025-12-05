REM set YYYYMMDD=%DATE:~10,4%%DATE:~4,2%%DATE:~7,2%
REM echo %YYYYMMDD%
REM /wait
REM set fileName = fulldatabasebackup_%YYYYMMDD%.txt
REM echo %fileName%
"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump" -u root -pAdmin123 ibrokerdb > %DATE%_fulldatabasebackup.txt
iBroker.DBBackupUtility %DATE%_fulldatabasebackup.txt
/wait
