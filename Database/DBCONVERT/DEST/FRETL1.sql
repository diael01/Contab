  if exists ( select * from sys.tables where name = N'FRETL1')
 DROP TABLE [FRETL1];
 CREATE TABLE [FRETL1] (
[MARCA]                            Integer, 
[RET]                              Integer, 
[BEN]                              Integer, 
[SECR]                             Integer, 
[ACR]                              Integer, 
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
[NP]                               Char(29));
