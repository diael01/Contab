  if exists ( select * from sys.tables where name = N'L-POPV')
 DROP TABLE [L-POPV];
 CREATE TABLE [L-POPV] (
[MARCA]                            Integer, 
[BEN]                              Integer, 
[NRDOC]                            Integer, 
[ANDOC]                            Integer, 
[LNDOC]                            Integer, 
[ZIDOC]                            Integer, 
[RDRL]                             Numeric(8,2), 
[RRLLR]                            Numeric(8,2), 
[BANCA]                            Char(3), 
[NRBANCA]                          Integer, 
[COMIS_V]                          Numeric(5,2), 
[COMIS_T]                          Char(1), 
[COMISION]                         Numeric(5,2), 
[AC]                               Integer, 
[NUME]                             Char(20), 
[SEC]                              Integer, 
[ROL]                              Char(6), 
[DRL]                              Numeric(9,2));
