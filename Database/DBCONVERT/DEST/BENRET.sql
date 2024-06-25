  if exists ( select * from sys.tables where name = N'BENRET')
 DROP TABLE [BENRET];
 CREATE TABLE [BENRET] (
[ACR]                              Integer, 
[BENR]                             Integer, 
[RETR]                             Integer, 
[VALR]                             Numeric(10,2), 
[TAXR]                             Numeric(6,2), 
[BANCA]                            Char(3), 
[NRBANCA]                          Integer);
