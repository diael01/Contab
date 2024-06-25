  if exists ( select * from sys.tables where name = N'XML_1SS')
 DROP TABLE [XML_1SS];
 CREATE TABLE [XML_1SS] (
[FIELD_NAME]                       Char(10), 
[FIELD_TYPE]                       Char(1), 
[FIELD_LEN]                        Integer, 
[FIELD_DEC]                        Integer);
