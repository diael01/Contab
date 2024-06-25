  if exists ( select * from sys.tables where name = N'COBO')
 DROP TABLE [COBO];
 CREATE TABLE [COBO] (
[CODB]                             Integer, 
[CDBN]                             Integer, 
[NUMEB]                            Char(50), 
[COTA]                             Integer, 
[STAGIU]                           Char(1), 
[GRPB]                             Char(1), 
[BU]                               Char(1), 
[PLAFON]                           Char(20), 
[G1_5]                             Char(2));
