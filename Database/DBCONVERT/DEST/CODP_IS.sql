  if exists ( select * from sys.tables where name = N'CODP_IS')
 DROP TABLE [CODP_IS];
 CREATE TABLE [CODP_IS] (
[DENTS]                            Char(3), 
[NUMESTR]                          Char(55), 
[CODPOSTAL]                        Numeric(10,0), 
[ICODA]                            Char(5), 
[ICODS]                            Integer, 
[ICODN]                            Integer, 
[ICODJ]                            Integer, 
[TIPA]                             Integer, 
[DENTL]                            Char(15), 
[LOC]                              Char(40), 
[OFT]                              Char(5), 
[CODUNIC]                          Char(10));
