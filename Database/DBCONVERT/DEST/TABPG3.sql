  if exists ( select * from sys.tables where name = N'TABPG3')
 DROP TABLE [TABPG3];
 CREATE TABLE [TABPG3] (
[RND]                              Integer, 
[CFLC]                             Char(6), 
[CL1]                              Integer, 
[CL2]                              Numeric(12,0), 
[CL3]                              Numeric(10,0), 
[CL4]                              Numeric(12,0), 
[CL5]                              Integer, 
[CL6]                              Numeric(6,2), 
[CL7]                              Integer, 
[CL17]                             Char(24), 
[CL18]                             Char(3), 
[CL33]                             Integer);
