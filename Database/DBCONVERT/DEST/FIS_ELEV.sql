  if exists ( select * from sys.tables where name = N'FIS_ELEV')
 DROP TABLE [FIS_ELEV];
 CREATE TABLE [FIS_ELEV] (
[MARCA]                            Integer, 
[CNP_PI]                           Numeric(13,0), 
[NUME_PI]                          Char(25), 
[TIP_PERS]                         Char(1), 
[TIP_HAND]                         Integer, 
[NR_COPIL]                         Integer, 
[VENIT]                            Numeric(10,2), 
[STERS]                            Bit, 
[LUNA]                             Char(24), 
[GRAD_RUD]                         Char(1), 
[CNP_PIV]                          Numeric(13,0), 
[DATAMO]                           DateTime, 
[CASA]                             Char(2), 
[CNP_P]                            Numeric(13,0), 
[ELEV]                             Integer);
