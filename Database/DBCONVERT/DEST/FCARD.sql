  if exists ( select * from sys.tables where name = N'FCARD')
 DROP TABLE [FCARD];
 CREATE TABLE [FCARD] (
[NUME]                             Char(33), 
[PRENUME]                          Char(22), 
[CNP]                              Numeric(13,0), 
[SUMA]                             Numeric(16,2), 
[CONTAP]                           Char(11), 
[CODOIS]                           Char(5), 
[DATVAL]                           Char(8), 
[CONTPE]                           Char(12), 
[MARCA]                            Char(4), 
[DBCR]                             Char(1));
