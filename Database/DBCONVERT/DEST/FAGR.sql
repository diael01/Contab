  if exists ( select * from sys.tables where name = N'FAGR')
 DROP TABLE [FAGR];
 CREATE TABLE [FAGR] (
[NRCTRA]                           Char(3), 
[STPA]                             Integer, 
[STRPAG]                           Integer, 
[SECLA]                            Integer, 
[OLAEF]                            Integer, 
[RTRATR]                           Integer, 
[RTRATRC]                          Integer, 
[RAREP]                            Integer, 
[PART]                             Integer, 
[OLATAR]                           Integer, 
[RTATTAR]                          Integer, 
[RTRATTAR]                         Integer, 
[RTACRTAR]                         Integer, 
[RAREPTAR]                         Integer, 
[PARTICTAR]                        Integer);
