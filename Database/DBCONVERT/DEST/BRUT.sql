  if exists ( select * from sys.tables where name = N'BRUT')
 DROP TABLE [BRUT];
 CREATE TABLE [BRUT] (
[MARCA]                            Integer, 
[BRUT]                             Numeric(10,2), 
[IMPOZIT]                          Numeric(10,2), 
[IMPOZ_ANT]                        Numeric(10,2), 
[VENIT_CUM]                        Numeric(10,2), 
[BAZA_AJS]                         Numeric(10,2), 
[CONT_AJS]                         Numeric(10,2), 
[BAZA_CASS]                        Numeric(10,2), 
[CASS]                             Numeric(10,2), 
[BAZA_FS]                          Numeric(10,2), 
[CONT_FS]                          Numeric(10,2), 
[BZ_CAS06]                         Numeric(10,2), 
[CAS06]                            Numeric(10,2), 
[CONTR_FS]                         Numeric(10,2));
