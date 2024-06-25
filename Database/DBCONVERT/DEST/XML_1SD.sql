  if exists ( select * from sys.tables where name = N'XML_1SD')
 DROP TABLE [XML_1SD];
 CREATE TABLE [XML_1SD] (
[FIELD_NAME]                       Char(10), 
[FIELD_TYPE]                       Char(1), 
[FIELD_LEN]                        Integer, 
[FIELD_DEC]                        Integer);
