  if exists ( select * from sys.tables where name = N'TIC_PERS')
 DROP TABLE [TIC_PERS];
 CREATE TABLE [TIC_PERS] (
[NUME]                             Char(27), 
[PRENUME]                          Char(27), 
[CNP]                              Char(13));
