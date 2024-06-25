  if exists ( select * from sys.tables where name = N'NJU')
 DROP TABLE [NJU];
 CREATE TABLE [NJU] (
[ICODN]                            Integer, 
[ICODA]                            Char(2), 
[IDENJ]                            Char(13), 
[CODJ]                             Integer);
