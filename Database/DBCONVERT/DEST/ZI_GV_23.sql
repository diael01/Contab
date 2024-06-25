  if exists ( select * from sys.tables where name = N'ZI_GV_23')
 DROP TABLE [ZI_GV_23];
 CREATE TABLE [ZI_GV_23] (
[DEN]                              Char(10), 
[VAL]                              Numeric(13,3), 
[VALA]                             Char(36));
