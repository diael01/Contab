  if exists ( select * from sys.tables where name = N'FREP')
 DROP TABLE [FREP];
 CREATE TABLE [FREP] (
[MARCA]                            Integer, 
[REIR]                             Integer, 
[REICAS]                           Integer, 
[RECAR]                            Integer, 
[RECAS]                            Integer, 
[REAUR]                            Integer, 
[REACAS]                           Integer, 
[RECHR]                            Integer, 
[RECHA]                            Integer, 
[RER]                              Integer, 
[RERA]                             Integer, 
[REPR]                             Integer, 
[REPRCAS]                          Integer, 
[REPAR]                            Integer, 
[REPAC]                            Integer);
