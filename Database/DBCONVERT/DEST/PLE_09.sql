  if exists ( select * from sys.tables where name = N'PLE_09')
 DROP TABLE [PLE_09];
 CREATE TABLE [PLE_09] (
[MARCAL]                           Integer, 
[OANL]                             Integer, 
[SECL]                             Integer, 
[ACL]                              Integer, 
[CLML]                             Integer);
