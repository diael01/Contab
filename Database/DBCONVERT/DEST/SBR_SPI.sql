  if exists ( select * from sys.tables where name = N'SBR_SPI')
 DROP TABLE [SBR_SPI];
 CREATE TABLE [SBR_SPI] (
[MARCAS]                           Integer, 
[SBRAP]                            Numeric(10,2), 
[ALCT]                             Char(1), 
[NUME]                             Char(20), 
[SEC]                              Integer);
