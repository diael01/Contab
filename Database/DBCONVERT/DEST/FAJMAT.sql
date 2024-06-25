  if exists ( select * from sys.tables where name = N'FAJMAT')
 DROP TABLE [FAJMAT];
 CREATE TABLE [FAJMAT] (
[MARCA]                            Integer, 
[SECAJ]                            Integer, 
[ACAJ]                             Integer, 
[CLMAJ]                            Integer, 
[STRPERS]                          Integer, 
[CGRPB]                            Char(1), 
[CB]                               Integer, 
[ZIAJP]                            Integer, 
[SCAS]                             Integer, 
[ZIAJPB]                           Integer, 
[SCASB]                            Integer, 
[LUNAB]                            Integer, 
[ANB]                              Integer, 
[CNP]                              Numeric(13,0), 
[PROC]                             Integer, 
[ZI_INC]                           Integer, 
[CASS145]                          Numeric(12,4));
