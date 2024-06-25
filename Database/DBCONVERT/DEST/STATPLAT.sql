  if exists ( select * from sys.tables where name = N'STATPLAT')
 DROP TABLE [STATPLAT];
 CREATE TABLE [STATPLAT] (
[DATASTAT]                         DateTime, 
[MARCA]                            Integer, 
[NUME]                             Char(31), 
[SALAR_NEG]                        Numeric(10,0), 
[ORE_ZILE]                         Integer, 
[ORE_CO]                           Integer, 
[ORE_CM]                           Integer, 
[ORE_CFS]                          Integer, 
[SALAR_BRUT]                       Integer, 
[CNP]                              Char(13));
