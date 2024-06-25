  if exists ( select * from sys.tables where name = N'PLAV')
 DROP TABLE [PLAV];
 CREATE TABLE [PLAV] (
[MARCA]                            Integer, 
[ZIM]                              Integer, 
[NP]                               Char(20), 
[LN]                               Integer, 
[SUMA]                             Integer, 
[RET]                              Integer, 
[NET]                              Integer, 
[CHEIE]                            Char(6), 
[FUNCTIE]                          Char(6), 
[CLM]                              Char(6), 
[ZINT]                             Integer, 
[TS]                               Char(1), 
[CARDL]                            Numeric(10,2), 
[TIPCARD]                          Char(1), 
[SAN]                              Numeric(7,2), 
[CAS]                              Numeric(7,2), 
[SOM]                              Numeric(7,2), 
[IMP]                              Integer, 
[AN]                               Integer, 
[TIPN]                             Bit);
