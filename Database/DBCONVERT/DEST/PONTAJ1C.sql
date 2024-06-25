  if exists ( select * from sys.tables where name = N'PONTAJ1C')
 DROP TABLE [PONTAJ1C];
 CREATE TABLE [PONTAJ1C] (
[MARCA]                            Integer, 
[ZIM]                              Integer, 
[ZIRE]                             Char(2), 
[ZICA]                             Integer, 
[AVCAS]                            Integer, 
[SAVR]                             Char(8), 
[SP]                               Integer, 
[SC]                               Char(1), 
[AVC]                              Integer, 
[ZILAN]                            Char(2), 
[UZIM]                             Integer, 
[NUME]                             Char(20));
