  if exists ( select * from sys.tables where name = N'FUNC_MT')
 DROP TABLE [FUNC_MT];
 CREATE TABLE [FUNC_MT] (
[CFL]                              Char(6), 
[MARCAL]                           Integer, 
[BR]                               Numeric(10,0), 
[BT]                               Numeric(10,0));
