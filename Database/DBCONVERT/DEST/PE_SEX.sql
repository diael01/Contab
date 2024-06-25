  if exists ( select * from sys.tables where name = N'PE_SEX')
 DROP TABLE [PE_SEX];
 CREATE TABLE [PE_SEX] (
[SEX]                              Char(1), 
[COD_SEC]                          Integer, 
[COD_ACT]                          Integer, 
[COD_LM]                           Integer, 
[SCH]                              Char(1), 
[COD_FUNC]                         Char(6), 
[MARCA]                            Integer, 
[NP]                               Char(31), 
[CNP]                              Char(13), 
[ZI_N]                             Integer, 
[LN_N]                             Integer, 
[AN_N]                             Integer, 
[LOC]                              Char(35), 
[JUD]                              Char(10), 
[STRADA]                           Char(30), 
[NUMAR]                            Char(6), 
[BLOC]                             Char(5), 
[SCARA]                            Char(5), 
[ETAJ]                             Char(6), 
[APART]                            Char(5), 
[COD_POS]                          Numeric(10,0));
