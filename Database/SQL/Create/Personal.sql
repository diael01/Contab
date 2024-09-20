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
 [EmpNode] [hierarchyid] primary key clustered NOT NULL,
	[EmpNodeText] [nvarchar](128) NULL,
	[ParentNode] [hierarchyid] NULL,
	[ParentNodeText] [nvarchar](128) NULL,
	[EmpLevel]  AS ([EmpNode].[GetLevel]()),
	[NameSurname] [nvarchar](128) NOT NULL,
	[Gender] [char](1) NOT NULL,
	[Birthday] [smalldatetime] NOT NULL,
	[CivilStatus] [char](1) NULL,
	[HiringDate] [smalldatetime] NOT NULL,
	[FirstHiringDate] [smalldatetime] NULL,--tbd: calculate seniority
	[CountyCode] [char](2) not NULL,--cod judet
	[Phone] [nvarchar](32) NULL,
	[Location] [varchar](128) NULL,
	[IdCardSerieNo] [nvarchar](128) NULL,
	[IdCardCnp] [nvarchar](128) NULL,
	[Bank1Code] [char](3) NULL,
	[Bank1Iban] [nvarchar](128) NULL,
	[LunchTickets] [int] NULL,
	[AvansOrLiquidaton] [bit] NULL,
	[YearSeniority] [int] NULL,--AN_SV
	[MonthSeniority] [int] NULL,--LN_SV
	[Insured] [bit] NULL,--asigurat sau nu? ce fel de insured?
	[Insurance] [nvarchar](128) NULL,--ASCASA , ce casa de asigurari
	LastIdCardCreationDate [smalldatetime] NULL,-- = CALIF
	[Studies] [nvarchar](128) NULL,--studii sup, necalif, aso
	[Bank2Code] [char](3) NULL,
	[Bank2Iban] [nvarchar](128) NULL,
	[Retired] [bit] NOT NULL,
	[RetirementSeniority] [char](2) NULL,--P_SV
	[RetirementSupplement] [int] NULL,--PEN-SUP
	[RetirementExclusionReason] [int] NULL);-- 0 means no pensie privata = MOTIVEXC
CREATE INDEX Emp_BreadthFirst ON Personal(EmpLevel, EmpNode);

--[MARCA]                            Integer, 
--[NP]                               Char(31), 
--[SEX]                              Char(1), 
--[AN_N]                             Integer, 
--[LN_N]                             Integer, 
--[ZI_N]                             Integer, 
--[S_CIVIL]                          Char(1), 
--[COD_JUD]                          Integer, 
--[PEN_FC]                           Integer, 
--[AN_A]                             Integer, 
--[LN_A]                             Integer, 
--[ZI_A]                             Integer, 
--[AN_VT]                            Integer, 
--[LN_VT]                            Integer, 
--[ZI_VT]                            Integer, 
--[AN_VN]                            Integer, 
--[LN_VN]                            Integer, 
--[ZI_VN]                            Integer, 
--[AN_SV]                            Integer, 
--[LN_SV]                            Integer, 
--[P_SV]                             Char(2), 
--[PEN_SUP]                          Integer, 
--[AN_SV]                            Integer, -- ??? ang+x ani => an spor vechime inceput
--[LN_SV]                            Integer, 
--[P_SV]                             Char(2), --? pensie spor vechime
--[PEN_SUP]                          Integer, -- ?pensie suplimentra
--[ASIGS5]                           Integer, ---asigurat sa neasigurat
--[CALIF]                            Char(10), --- calificare = data eloberarii ultima cartii identitate
--[SB]                               Char(2), -- serie buletin, si nr buletin
--[CNP]                              Char(13), 
--/////[NRBU]                             Integer, -- nr buletin=> tb sa fie cu seria
--[BANCA]                            Char(3), -- cod banca
--[CODC]                             Char(26), -- cod card = IBAN
--[LOC]                              Char(35), -- adresa 
--[JUD]                              Char(10), 
--[STRADA]                           Char(30), 
--[NUMAR]                            Char(6), 
--[BLOC]                             Char(5), 
--[SCARA]                            Char(5), 
--[ETAJ]                             Char(6), 
--[APART]                            Char(5), 
--[COD_POS]                          Numeric(10,0), 
--[ASCASA]                           Integer, -- la ce casa are asigurare de sanatate, obligatorie
--[STUDII]                           Char(4), -- sup, med, profesionale
--[ADRESA1]                          Char(10), --?
--[ADRESA2]                          Char(10), 
--[ADRESA3]                          Char(20), 
--[TEL]                              Char(10), 
--[T_C]                              Integer, --tickete masa 0,1,2
--[BANCA2]                           Char(3), -- a 2-a bnca
--[CODC2]                            Char(26), 
--[AV_LI2]                           Char(1),  -- avans sau lichidare
--[PILON]                            Integer, -- daca vrea sa tina bani pt alta pensie privata, nr 0=null, 2
----////[ASIGEXC]                          Integer, -- asigurat excepetat de la?
--[MOTIVEXC]                         Integer); -- motivul exceptarii? 1=pensionar, 2=eelev, 3 
