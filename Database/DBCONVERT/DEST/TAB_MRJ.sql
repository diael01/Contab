  if exists ( select * from sys.tables where name = N'TAB_MRJ')
 DROP TABLE [TAB_MRJ];
 CREATE TABLE [TAB_MRJ] (
[RND]                              Integer, 
[MARJA]                            Numeric(10,2));
