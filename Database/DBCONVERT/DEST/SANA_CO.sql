  if exists ( select * from sys.tables where name = N'SANA_CO')
 DROP TABLE [SANA_CO];
 CREATE TABLE [SANA_CO] (
[NR]                               Char(7), 
[NRC]                              Integer, 
[NRCA]                             Integer, 
[NRCC]                             Integer, 
[TIP]                              Char(28), 
[AN]                               Integer, 
[LN]                               Integer, 
[MARCA]                            Integer, 
[NUME]                             Char(32), 
[CNP]                              Char(13), 
[ADRESA]                           Char(25), 
[LOC]                              Char(30), 
[JUD]                              Char(10), 
[NRSEC]                            Integer, 
[SECTIE]                           Char(30), 
[CA]                               Integer, 
[CASA]                             Char(2), 
[CNP_P]                            Char(13), 
[JUDP]                             Char(2));
