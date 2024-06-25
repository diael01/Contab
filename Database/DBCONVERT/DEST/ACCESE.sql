  if exists ( select * from sys.tables where name = N'ACCESE')
 DROP TABLE [ACCESE];
 CREATE TABLE [ACCESE] (
[MARCA]                            Char(5), 
[ACCESE]                           Char(10));
