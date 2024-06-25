  if exists ( select * from sys.tables where name = N'STATF1')
 DROP TABLE [STATF1];
 CREATE TABLE [STATF1] (
[NRST]                             Integer, 
[MARCA]                            Integer, 
[CODS]                             Integer, 
[CODA]                             Integer, 
[CODLM]                            Integer, 
[SCH]                              Char(1), 
[CODF]                             Char(6), 
[POZNOM]                           Char(12), 
[LCMIN]                            Integer, 
[LCMAX]                            Integer, 
[LRMIN]                            Numeric(10,2), 
[LRMAX]                            Numeric(10,2), 
[SEMNIF]                           Char(8), 
[CHEL]                             Char(6), 
[ACL]                              Integer);
