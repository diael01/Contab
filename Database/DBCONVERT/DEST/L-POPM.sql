  if exists ( select * from sys.tables where name = N'L-POPM')
 DROP TABLE [L-POPM];
 CREATE TABLE [L-POPM] (
[MARCA]                            Integer, 
[BEN]                              Integer, 
[RDRL]                             Numeric(8,2), 
[RRLLR]                            Numeric(8,2), 
[TAXA]                             Numeric(6,2), 
[BANCA]                            Char(3), 
[NRBANCA]                          Integer, 
[COMIS_V]                          Numeric(5,2), 
[COMIS_T]                          Char(1), 
[COMISION]                         Numeric(5,2), 
[AC]                               Integer, 
[NUME]                             Char(20), 
[SEC]                              Integer, 
[DRL]                              Numeric(10,2));
