  if exists ( select * from sys.tables where name = N'ZI_GV_24')
 DROP TABLE [ZI_GV_24];
 CREATE TABLE [ZI_GV_24] (
[DEN]                              Char(10), 
[VAL]                              Numeric(13,3), 
[VALA]                             Char(36));
