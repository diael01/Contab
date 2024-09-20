USE Contab
GO
/****** Object:  Table [dbo].[Organisation]    Script Date: 6/11/2024 3:33:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  if exists ( select * from sys.tables where name = N'Personal')
 DROP TABLE [Personal];
 CREATE TABLE [dbo].[Personal] (
 [EmpNode] [hierarchyid] primary key clustered not null,
	[EmpNodeText] [nvarchar](128),
	[ParentNode] [hierarchyid],
	[ParentNodeText] [nvarchar](128),
	[EmpLevel]  AS ([EmpNode].[GetLevel]()),
	[NameSurname] [nvarchar](128) NOT NULL,
	[Gender] char(1) NOT NULL,
	[Birthday]  [smalldatetime] NOT NULL,
	[CivilStatus] char(1) NULL,
	[CodJudet]  [char](2) not NULL,
	[Pensionar] bit not null,
	[HiringDate] [smalldatetime] NOT NULL,
	[FirstHiringDate] [smalldatetime] NOT NULL, --calculate seniority
	[CountyCode]  [char](2) NULL, --cod judet
	[Location] [varchar](128) NULL,
    [CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](32) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](32) NOT NULL,



[AN_SV]                            Integer, -- ??? ang+x ani => an spor vechime inceput
[LN_SV]                            Integer, 
[P_SV]                             Char(2), --? pensie spor vechime
[PEN_SUP]                          Integer, -- ?pensie suplimentra
[ASIGS5]                           Integer, ---asigurat sa neasigurat
[CALIF]                            Char(10), --- calificare = data eloberarii ultima cartii identitate
[SB]                               Char(2), -- serie buletin, si nr buletin
[CNP]                              Char(13), 
[NRBU]                             Integer, -- nr buletin=> tb sa fie cu seria
[BANCA]                            Char(3), -- cod banca
[CODC]                             Char(26), -- cod card = IBAN
[LOC]                              Char(35), -- adresa 
[JUD]                              Char(10), 
[STRADA]                           Char(30), 
[NUMAR]                            Char(6), 
[BLOC]                             Char(5), 
[SCARA]                            Char(5), 
[ETAJ]                             Char(6), 
[APART]                            Char(5), 
[COD_POS]                          Numeric(10,0), 
[ASCASA]                           Integer, -- la ce casa are asigurare de sanatate, obligatorie
[STUDII]                           Char(4), -- sup, med, profesionale
[ADRESA1]                          Char(10), --?
[ADRESA2]                          Char(10), 
[ADRESA3]                          Char(20), 
[TEL]                              Char(10), 
[T_C]                              Integer, --tickete masa 0,1,2
[BANCA2]                           Char(3), -- a 2-a bnca
[CODC2]                            Char(26), 
[AV_LI2]                           Char(1),  -- avans sau lichidare
[PILON]                            Integer, -- daca vrea sa tina bani pt alta pensie privata, nr 0=null, 2
--[ASIGEXC]                          Integer, -- asigurat excepetat de la?
[MOTIVEXC]                         Integer); -- motivul exceptarii? 1=pensionar, 2=eelev, 3 
