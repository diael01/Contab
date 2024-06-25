  if exists ( select * from sys.tables where name = N'F_HELP')
 DROP TABLE [F_HELP];
 CREATE TABLE [F_HELP] (
[A_CHE]                            Char(10), 
[HELP]                             Text);
