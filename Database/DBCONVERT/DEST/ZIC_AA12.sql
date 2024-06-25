  if exists ( select * from sys.tables where name = N'ZIC_AA12')
 DROP TABLE [ZIC_AA12];
 CREATE TABLE [ZIC_AA12] (
[SECL]                             Integer, 
[ACL]                              Integer, 
[CLML]                             Integer, 
[MARCAL]                           Integer, 
[OCOL]                             Integer, 
[COBRL]                            Integer, 
[OINVL]                            Integer, 
[OTBL]                             Integer, 
[OANL]                             Integer, 
[ZICOFR]                           Integer, 
[OREL]                             Integer, 
[OLAL]                             Integer, 
[OINTRL]                           Integer, 
[ZIMOD6]                           Integer, 
[ZIMOD8]                           Integer, 
[CNP]                              Numeric(13,0), 
[AVCOLL]                           Integer, 
[ZIINV]                            Integer, 
[ZIABS]                            Integer, 
[COFRL]                            Integer, 
[NUM]                              Char(30));
