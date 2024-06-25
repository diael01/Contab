  if exists ( select * from sys.tables where name = N'R_COTIZ')
 DROP TABLE [R_COTIZ];
 CREATE TABLE [R_COTIZ] (
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
