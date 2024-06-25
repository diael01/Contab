  if exists ( select * from sys.tables where name = N'FC_BRD')
 DROP TABLE [FC_BRD];
 CREATE TABLE [FC_BRD] (
[ID_CONV]                          Char(6), 
[SV_IBAN]                          Char(24), 
[ID_CLIENT]                        Char(11), 
[NUME]                             Char(30), 
[CNP]                              Char(13), 
[RESTPLATA]                        Numeric(10,2), 
[SUMACOMIS]                        Numeric(10,2), 
[SUMA]                             Numeric(16,2), 
[CIBANK]                           Char(24));
