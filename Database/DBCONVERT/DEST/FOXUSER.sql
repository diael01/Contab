  if exists ( select * from sys.tables where name = N'FOXUSER')
 DROP TABLE [FOXUSER];
 CREATE TABLE [FOXUSER] (
[TYPE]                             Char(12), 
[ID]                               Char(12), 
[NAME]                             Char(24), 
[READONLY]                         Bit, 
[CKVAL]                            Integer, 
[DATA]                             Text, 
[UPDATED]                          DateTime);
