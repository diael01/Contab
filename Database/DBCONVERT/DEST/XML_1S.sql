  if exists ( select * from sys.tables where name = N'XML_1S')
 DROP TABLE [XML_1S];
 CREATE TABLE [XML_1S] (
[FIELD_NAME]                       Char(10), 
[FIELD_TYPE]                       Char(1), 
[FIELD_LEN]                        Integer, 
[FIELD_DEC]                        Integer);
