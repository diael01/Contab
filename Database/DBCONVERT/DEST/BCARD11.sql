  if exists ( select * from sys.tables where name = N'BCARD11')
 DROP TABLE [BCARD11];
 CREATE TABLE [BCARD11] (
[NUME]                             Char(32), 
[CNP]                              Char(13), 
[IBAN]                             Char(26), 
[SUMA]                             Numeric(14,2));
