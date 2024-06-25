  if exists ( select * from sys.tables where name = N'XML_1_2')
 DROP TABLE [XML_1_2];
 CREATE TABLE [XML_1_2] (
[CNPASIG]                          Numeric(13,0), 
[IDASIG]                           Integer, 
[COD_LIN]                          Integer, 
[LINIE]                            Char(254), 
[LINIE_]                           Char(254));
