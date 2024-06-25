  if exists ( select * from sys.tables where name = N'FAGTS')
 DROP TABLE [FAGTS];
 CREATE TABLE [FAGTS] (
[NRCTRS]                           Char(3), 
[STRPE]                            Integer, 
[STRAG]                            Integer, 
[SECAG]                            Integer, 
[OAE]                              Integer, 
[RETRAT]                           Integer, 
[RETRAC]                           Integer, 
[PARTIC]                           Integer, 
[OAETL]                            Integer, 
[RETRATT]                          Integer, 
[RETRATTL]                         Integer, 
[RETRATTLC]                        Integer, 
[PARTICTL]                         Integer);
