  if exists ( select * from sys.tables where name = N'FRETL')
 DROP TABLE [FRETL];
 CREATE TABLE [FRETL] (
[MARCA]                            Integer, 
[RET]                              Integer, 
[BEN]                              Integer, 
[NRDOC]                            Integer, 
[ANDOC]                            Integer, 
[LNDOC]                            Integer, 
[ZIDOC]                            Integer, 
[RDRL]                             Numeric(8,2), 
[RRLLR]                            Numeric(8,2), 
[RDDLL]                            Numeric(7,2), 
[RDLL1]                            Numeric(7,2), 
[RDPEN]                            Numeric(8,2), 
[TAXA]                             Numeric(6,2), 
[RRPR]                             Numeric(8,2), 
[RRPCAS]                           Numeric(8,2), 
[BANCA]                            Char(3), 
[NRBANCA]                          Integer, 
[COMIS_V]                          Numeric(5,2), 
[COMIS_T]                          Char(1), 
[COMISION]                         Numeric(5,2));
