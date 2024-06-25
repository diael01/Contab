  if exists ( select * from sys.tables where name = N'FCD_2011')
 DROP TABLE [FCD_2011];
 CREATE TABLE [FCD_2011] (
[IDENT]                            Char(1), 
[CD]                               Char(6), 
[DENS]                             Char(17), 
[DENL]                             Char(50), 
[COD_COR]                          Numeric(10,0));
