  if exists ( select * from sys.tables where name = N'PLANCO')
 DROP TABLE [PLANCO];
 CREATE TABLE [PLANCO] (
[MARCAC]                           Integer, 
[NUME]                             Char(20), 
[VECT]                             Integer, 
[ZICO]                             Integer, 
[ZICOS]                            Integer, 
[ZICOC]                            Integer, 
[ANCO]                             Integer, 
[ZIDIF]                            Integer, 
[PRIMAV]                           Numeric(10,2), 
[D_ANG]                            DateTime, 
[D_INC]                            DateTime, 
[S_PEN]                            Integer, 
[DI_CIC]                           DateTime, 
[DS_CIC]                           DateTime);
