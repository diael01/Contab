  if exists ( select * from sys.tables where name = N'PLEC2024')
 DROP TABLE [PLEC2024];
 CREATE TABLE [PLEC2024] (
[LN_R]                             Integer, 
[MARCA]                            Integer, 
[NP]                               Char(29), 
[CNP]                              Numeric(13,0), 
[PL]                               DateTime, 
[ZI_DCM]                           Integer, 
[LN_DCM]                           Integer, 
[AN_DCM]                           Integer, 
[OBS]                              Char(25), 
[AA]                               Char(1), 
[DENLM]                            Char(20));
