  if exists ( select * from sys.tables where name = N'L1_STATF')
 DROP TABLE [L1_STATF];
 CREATE TABLE [L1_STATF] (
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
