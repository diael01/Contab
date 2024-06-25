  if exists ( select * from sys.tables where name = N'A_DICT')
 DROP TABLE [A_DICT];
 CREATE TABLE [A_DICT] (
[CAMP]                             Char(10), 
[EXPLIC]                           Char(26), 
[OBS]                              Char(28), 
[INPROG]                           Char(8));
