  if exists ( select * from sys.tables where name = N'ALI_PERS')
 DROP TABLE [ALI_PERS];
 CREATE TABLE [ALI_PERS] (
[NUME]                             Char(27), 
[PRENUME]                          Char(27), 
[CNP]                              Char(13), 
[NR_TIC]                           Char(10), 
[VAL_TIC]                          Char(10), 
[SUM_TIC]                          Char(10));
