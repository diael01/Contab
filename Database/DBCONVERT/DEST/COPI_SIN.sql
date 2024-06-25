  if exists ( select * from sys.tables where name = N'COPI_SIN')
 DROP TABLE [COPI_SIN];
 CREATE TABLE [COPI_SIN] (
[MARCA]                            Integer, 
[SEC]                              Integer, 
[ACT]                              Integer, 
[LM]                               Integer, 
[CTZR]                             Numeric(10,2), 
[NP]                               Char(20), 
[CTZRR]                            Numeric(10,2), 
[CTZRC]                            Numeric(10,2), 
[RESTR]                            Numeric(10,2), 
[SIND]                             Integer, 
[PROCS]                            Numeric(6,2), 
[REST]                             Numeric(10,2));
