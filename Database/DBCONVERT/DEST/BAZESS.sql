  if exists ( select * from sys.tables where name = N'BAZESS')
 DROP TABLE [BAZESS];
 CREATE TABLE [BAZESS] (
[C1]                               Char(10), 
[C2]                               Char(10), 
[EXPLICATII]                       Char(40));
