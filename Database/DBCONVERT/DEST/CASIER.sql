  if exists ( select * from sys.tables where name = N'CASIER')
 DROP TABLE [CASIER];
 CREATE TABLE [CASIER] (
[COD_CASIER]                       Integer, 
[CASIER]                           Char(24));
