  if exists ( select * from sys.tables where name = N'SREP_06')
 DROP TABLE [SREP_06];
 CREATE TABLE [SREP_06] (
[COD_ANG]                          Numeric(13,0), 
[DENUMIRE]                         Char(160), 
[JUDET]                            Char(20), 
[LOCALITATE]                       Char(50), 
[STRADA]                           Char(50), 
[NR]                               Char(10), 
[BLOC]                             Char(10), 
[SCARA]                            Char(10), 
[AP]                               Char(10), 
[COD_POSTAL]                       Numeric(10,0), 
[TELEFON]                          Char(10), 
[FAX]                              Char(10), 
[EMAIL]                            Char(50), 
[CONV]                             Char(3), 
[DIRECTOR]                         Char(25), 
[INTOCMIT]                         Char(25), 
[FUNC_INTOC]                       Char(25), 
[REGC]                             Char(20), 
[CAEN]                             Char(10), 
[PRO_AC]                           Numeric(10,3));
