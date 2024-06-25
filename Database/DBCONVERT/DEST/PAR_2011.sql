  if exists ( select * from sys.tables where name = N'PAR_2011')
 DROP TABLE [PAR_2011];
 CREATE TABLE [PAR_2011] (
[DEN]                              Char(10), 
[VAL]                              Numeric(13,3), 
[VALA]                             Char(36));
