  if exists ( select * from sys.tables where name = N'RBCR0124')
 DROP TABLE [RBCR0124];
 CREATE TABLE [RBCR0124] (
[MARCA]                            Integer, 
[NUME]                             Char(30), 
[CARNET]                           Char(20), 
[SUMA]                             Numeric(10,2));
