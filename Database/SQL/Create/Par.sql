  if exists ( select * from sys.tables where name = N'PAR')
 DROP TABLE [PAR];
 CREATE TABLE [PAR] (
[DEN]                              Char(10), 
[VAL]                              Numeric(13,3), 
[VALA]                             Char(36));
