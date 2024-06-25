  if exists ( select * from sys.tables where name = N'Q2')
 DROP TABLE [Q2];
 CREATE TABLE [Q2] (
[CASIER]                           Integer, 
[COD_FUNC]                         Char(6), 
[MARCA]                            Integer, 
[DEN_F]                            Char(20), 
[COD_COR]                          Integer);
