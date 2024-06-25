  if exists ( select * from sys.tables where name = N'CBCARD11')
 DROP TABLE [CBCARD11];
 CREATE TABLE [CBCARD11] (
[NUME]                             Char(32), 
[CNP]                              Char(13), 
[IBAN]                             Char(26), 
[SUMA]                             Numeric(14,2));
