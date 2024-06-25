  if exists ( select * from sys.tables where name = N'L_STATF')
 DROP TABLE [L_STATF];
 CREATE TABLE [L_STATF] (
[NRST]                             Integer, 
[MARCA]                            Integer, 
[CODS]                             Integer, 
[CODA]                             Integer, 
[CODLM]                            Integer, 
[SCH]                              Char(1), 
[CODF]                             Char(6), 
[CHEL]                             Char(6), 
[ACL]                              Integer, 
[PSP_V]                            Integer, 
[VSP_V]                            Numeric(10,2), 
[RETRIB]                           Numeric(10,0), 
[VSP_TOT]                          Numeric(10,2), 
[GRAD]                             Char(2), 
[CATEG]                            Integer);
