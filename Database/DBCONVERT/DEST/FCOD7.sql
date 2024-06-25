  if exists ( select * from sys.tables where name = N'FCOD7')
 DROP TABLE [FCOD7];
 CREATE TABLE [FCOD7] (
[IDENT]                            Char(1), 
[CD]                               Char(6), 
[DENS]                             Char(17), 
[DENL]                             Char(50), 
[CASIER]                           Integer, 
[COD_COR]                          Integer, 
[COD_GRM]                          Char(3), 
[C_COR]                            Integer);
