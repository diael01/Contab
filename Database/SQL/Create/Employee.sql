USE [Contab]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 9/25/2024 12:08:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
 if exists ( select * from sys.tables where name = N'Employee')
 DROP TABLE [Employee];
CREATE TABLE [dbo].[Employee](
	[Id] int identity(1,1) primary key clustered not null ,
	[EmpNode] [hierarchyid]  NOT NULL,
	[EmpRecordChangeDay]  int not NULL default 0, --[ZIM]= only 5 changes allowed per month = ZIM = zi modificare 0-30
	[Name] [nvarchar](128)		NOT NULL,-- default 'Jannie Doe',
	[IdCardSerieNo] [nvarchar](128) not NULL,
	[IdCardCnp] [nvarchar](128) not NULL,
	[LastIdCardCreationDate] [smalldatetime] not NULL,--CALIF?
	[MainSalary]			  Money not null, --numeric(10,2) not null,-- default 1500.05,= RETRIB
	[HiringDate] [smalldatetime] not NULL default sysdatetime(),
	[ManagerNode] [hierarchyid] Not NULL,
	[EmpShift] char(1)			NOT NULL default 'Z', --day or night
	[CountyCode] [char](2) not NULL,-- default 'NY',
	[WorkGroup] smallint not null default 3 , --6- mineri, 3-IT
	[HoursToWork] smallint not null default 8, --8 hours, make it short
	[WorkTypeContract] smallint not null default 0,--=[SP]? --0 sau 1=tesa, --1 inseamna normal, 8 ore, 0, 3censori, 4 pensionri,--12,13,14,17,--42,23,-48
	--ContractType
	[Email] [nvarchar](128) not NULL, 
	[WorkEmail] [nvarchar](128) not null default 'org@org.com', 
	[Gender] [char](1) not NULL default 'F',
	[Birthday] [smalldatetime] not NULL,-- default sysdatetime(),
	[EmpDeptNode] [hierarchyid] NOT NULL,--sectia
	[EmpActivityNode] [hierarchyid] NOT NULL,--activitate
	[EmpWorkTypeNode] [hierarchyid] NOT NULL,--loc munca
	[EmpFunctionNode] [hierarchyid] NOT NULL,--functie
	----from Salar
	[Retired] [bit] not NULL default 0,--0 nepensionar, 1 pensionar --PEN_FC?
	[Phone] [nvarchar](128) NULL,
	[Surname] [nvarchar](128) NULL,
	[Category] smallint NULL,
	[EmpGradation] [char](2) NULL,--STUDII
	[CivilStatus] [char](1) NULL,
    [MgmtSalaryIncrease]       Money, --IND_COND
    [EndWorkCode] [char](2) NULL,
	[EndWorkDate] [smalldatetime] NULL, 
	[WorkExperienceSalaryIncrease] Money,																	
	[FirstJobHiringDate] [smalldatetime] NULL,--
	[Location] [varchar](128) NULL,--adresa
	[MealTickets] bit NULL,--T_Cl
	[AvansOrLiquidaton] [bit] NULL,--AV_LI2
	[YearSeniority] [smallint] NULL,--AN_SV
	[MonthSeniority] [smallint] NULL,--LN_SV
	[Insured] [bit] NULL,--ASIGS5
	[Insurance] [nvarchar](128) NULL,--ASCASA
	[Studies] [nvarchar](128) NULL,
	[Bank1Code] [char](3) NULL,
	[Bank1Iban] [nvarchar](128) NULL,
	[Bank2Code] [char](3) NULL,
	[Bank2Iban] [nvarchar](128) NULL,
	[RetirementSeniority] [char](2) NULL,--P_SV
	[RetirementSupplement] [smallint] NULL,--PEN_SUB
	[RetirementExclusionReason] [smallint] NULL,--MOTIVEXC
	RetirementPilonGovt smallint, --PILON?
	-------------din pontaj1,2
	MoneyAdvance Money null, --AVC, --[ZILAN]   Char(2), --?DateCalculationPontaj1 smalldatetime,--redundant, TBD check if it can be in param
	HoursRegie smallint,--OLR
	HoursOOOGiven smallint, --OINV ore invoire
	HoursNotmotivatedAbsence smallint,--OAN
	HoursInterruption smallint,--OINTR
	HoursInterruptionNotmotivated smallint,--OINTRN
	HoursExcludedFromSeniorityAddition smallint,--ONSPV, ce este ONPRRS?
	DaysLeave smallint,--ZICO, --ZIC?
	DaysLeaveWithoutPay smallint,--ZICOFR
	DaysSick smallint,--ZIBT
	DaysUnmotivatedAbsence smallint,--ZIAN, [ABNZI]?
	DaysOOOGiven smallint,--[INVVZI]
	LeaveGross Money,--COBR
	MoneyLeaveLiquidation Money null,--AVCOL
	MoneyFinancialAid Money,--AAJM
	MoneyPartialSalary Money,--ARET
	MoneyBonus Money,--PRBR
	MoneyPartialBonus Money,--AVPR
	PercentDiminishQuantitative numeric,--DCANT
	PercentDimishFinal numeric,--DDEF
	MoneyGrossForOtherTimes Money,--SBRAP
	ContractNoIndivAccord nvarchar(128),--NRCAG
	IndividualAcord smallint,--SPAG
	HoursIndivAccord smallint, --OLA
	PercentIncreaseIndivAccord numeric,--MAG
	PercentDecreasecreaseIndivAccord numeric,--DAG
    HoursWorkedInTL smallint,--OLATL
	PercentIncreaseTL numeric,--MAJTL
	PercentDecreaseTL numeric,--DIMTL
	BaseCalculationTL numeric,--BAZATL
	TaxCumulated money,--[IMPZC]
	BonusGrossSpecial money,--[PRBR_S]
	BonusManagement money,--[INDCA]
	BonusManagementPartial Money,--[AVINDCA]
	UntaxedMoney Money,--[SNEIM]
	HoursLeave smallint,--OZICO
	HoursLeaveWithoutPay smallint,--OCOFR
	MoneyMealTickets Money,--VALTIC
	MoneyGiftTicket Money,--VTIC_CAD
	NumberOfTickets smallint,--NTIC_CAD
	----------------------------------
	[EmpNodeAsText] [nvarchar](128) NULL,
	[EmpNodeAsName] [nvarchar](128) NULL,
	[EmpLevel]  AS ([EmpNode].[GetLevel]()),
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL
	)
GO
CREATE INDEX Emp_BreadthFirst ON Employee(EmpLevel, EmpNode);

------------------------------------------------
--Personal
--[MARCA]                            Integer, 
--[NP]                               Char(31), 
--[SEX]                              Char(1), 
--[AN_N]                             Integer, 
--[LN_N]                             Integer, 
--[ZI_N]                             Integer, 
--[S_CIVIL]                          Char(1), 
--[COD_JUD]                          Integer, 
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
--[AN_SV]                            Integer, -- ??? ang+x ani => an spor vechime inceput
--[LN_SV]                            Integer, 
--[PEN_FC]                           Integer,
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

/* Tabela Salar
[ZI_MOD]                           Integer, 
[COD_FUNC]                         Char(6), 
[CATEG]                            Integer, 
[GRAD]                             Char(2), 
[RETRIB]                           Numeric(10,2), 
[IND_COND]                         Numeric(8,2), 
[PROCENT]                          Numeric(6,2), 
[COD_DCM]                          Char(1), 
[AN_DCM]                           Integer, 
[LN_DCM]                           Integer, 
[ZI_DCM]                           Integer, 
[COD_SEC]                          Integer, 
[COD_ACT]                          Integer, 
[COD_LM]                           Integer, 
[SCH]                              Char(1), 
[REGIM_LZ]                         Integer, 
[GRMUNCA]                          Integer, 
[NIV]                              Char(1), 
[SP_V]                             Integer, 
[CONT]                             Char(10), 
[RETRIBV]                          Numeric(10,0), 
[RETR0110]                         Integer);*/