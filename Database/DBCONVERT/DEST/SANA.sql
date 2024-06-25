  if exists ( select * from sys.tables where name = N'SANA')
 DROP TABLE [SANA];
 CREATE TABLE [SANA] (
[NRSEC]                            Integer, 
[SECTIE]                           Char(30), 
[NRC]                              Integer, 
[AN]                               Integer, 
[LN]                               Integer, 
[MARCA]                            Integer, 
[NUME]                             Char(32), 
[CNP]                              Numeric(13,0), 
[ADRESA]                           Char(25), 
[LOC]                              Char(30), 
[JUD]                              Char(10), 
[CASA]                             Char(2), 
[NRCONTR]                          Char(10), 
[CA]                               Integer, 
[T_CASA]                           Char(12), 
[BT]                               Numeric(10,0), 
[FS]                               Integer, 
[CATEG]                            Char(3), 
[JUDP]                             Char(2));
