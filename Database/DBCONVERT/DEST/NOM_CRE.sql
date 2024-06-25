  if exists ( select * from sys.tables where name = N'NOM_CRE')
 DROP TABLE [NOM_CRE];
 CREATE TABLE [NOM_CRE] (
[NRC]                              Integer, 
[VAL]                              Integer, 
[COD]                              Char(10), 
[SDA]                              Integer, 
[SDE]                              Integer, 
[SSE]                              Integer, 
[SPL]                              Integer, 
[BR_SA]                            Integer, 
[OK]                               Bit, 
[DIF]                              Integer, 
[SUMA]                             Integer, 
[EXP1]                             Char(33), 
[EXP2]                             Char(33), 
[EXP3]                             Char(33), 
[EXP4]                             Char(33), 
[EXP]                              Char(254), 
[VLA]                              Bit);
