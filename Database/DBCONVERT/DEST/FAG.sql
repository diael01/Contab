  if exists ( select * from sys.tables where name = N'FAG')
 DROP TABLE [FAG];
 CREATE TABLE [FAG] (
[NRCTR]                            Char(3), 
[RTRTLC]                           Integer, 
[RTRTLB]                           Integer, 
[ORACA]                            Numeric(8,2), 
[IAGPR]                            Numeric(7,3), 
[PRTRTLC]                          Integer, 
[PRTRTLB]                          Numeric(9,2), 
[PIAGPR]                           Numeric(7,3), 
[NRTRTLC]                          Integer, 
[NRTRTLB]                          Numeric(8,2), 
[NIAGPR]                           Numeric(7,3), 
[ISRAGA]                           Numeric(7,3));
