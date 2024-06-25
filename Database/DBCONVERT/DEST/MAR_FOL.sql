  if exists ( select * from sys.tables where name = N'MAR_FOL')
 DROP TABLE [MAR_FOL];
 CREATE TABLE [MAR_FOL] (
[MARCAL]                           Integer, 
[CNP]                              Numeric(13,0), 
[NUM]                              Char(30), 
[ZIMOD6]                           Integer, 
[ZIMOD8]                           Integer, 
[SCHL]                             Char(1));
