USE [Contab]
GO

/****** Object:  Table [dbo].[Params]    Script Date: 10/21/2024 2:22:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
 if exists ( select * from sys.tables where name = N'Params')
 DROP TABLE [Params];
CREATE TABLE [dbo].[Params](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	ProcessingDate smalldatetime,
	--[Year] [smallint] NULL,
	--[Month] [smallint] NULL,
	--[Day] [smallint] NULL,
	[FiscalCode] [nvarchar](32) NULL,
	[AdvanceWeight] smallint,--VA ?
	[AdvancePercentRate] numeric,-- CAV 10 charactere, 7 intregi si 2 zecimale
	[WorkRegime8Hours] smallint,--RM8 regimul de orar al muncitorilor care este calculat prin lege, functie de nr , dex 165.33 ore, indiferent de cate zile are luna
	[NormatedRegime] smallint,--RN8
	[Bank1Code] [nvarchar](64) NULL,
	[Bank2Code] [nvarchar](64) NULL,
	[CommerceRegister] [nvarchar](64) NULL,--REGC
	[NormalWorkHoursSchedule] smallint,--RNO8 regim normal de ore  ca la TESA, ca muncesc atat platesc
	[MinimSalaryGovt] money,--SALM
	------------------------------------------------------
	--TODO: addonly nodes and join with Employee tBLES
	EcnDirector hierarchyid,
	GenDirector hierarchyid,
	FinDirector hierarchyid,
	UserApp hierarchyid,
	--[NameEconomicDirector] [nvarchar](64) NULL,--SEFC
	--[NameGeneralDirector] [nvarchar](64) NULL,--SEFD
	--[NameFinanceDirector] [nvarchar](64) NULL,--SEFF
	--[NameUserApplication] [nvarchar](64) NULL,--SEFI
	--[FctEconomicDirector] [nvarchar](32) NULL,--SEFF1
	--[FctUserApplication] [nvarchar](32) NULL,--SEFF2
	--[FctHumanResourcesDirector] [nvarchar](32) NULL,--SEFF3
	---------------------------------------------------------
	---[DayOfLiquidation] [smallint] NULL,--ZILI
	[LiquidationDate] [smallint] NULL,--ZILI
	[PercUnion] numeric,--PSIND
	[CodesRetention] [nvarchar](64) NULL,--RETIN
	[PercSeniorityAddition] numeric,--SPVEC
	[PercDifferentForPension] numeric,--CASS_D_
	[PercNormalForPension] numeric,--CASS_N
	[PercSpecialForPension] numeric,--CASS_S
	[BeneficiaryCode] [numeric](18, 0) NULL,--CODBEN
	[InterestCAR] numeric,--DOBCAR
	[TaxRate] numeric,--PROC_I_
	[PercSuplemDeduction] numeric,--PRODS1_
	[PercFixDeduction] numeric,--PRODS6_
	[PercLimited] numeric,--PROLIM_
	[PercDeducMedicalOOO] numeric,--PRO_35_
	[PercContribToWorkAccident] numeric,--PRO_AC_
	[PercContribWorkInsurance] numeric,--PRO_AM_
	[PercContribRetirement] numeric,--PRO_CP_
	[PercHealthFund] numeric,--PRO_FS_
	[PercUnemplPaidByPerson] numeric,--PRO_SO_
	[PercUnemplPaidByCompany] numeric,--PRO_SU_
	[DiminishingRegime] [numeric](18, 0) NULL,--REGDIM_
	[AlgorithmUnemplCalc1] [numeric](18, 0) NULL,--SCTR1_
	[ManualOrAutomated_OOO_Calc] bit NULL,---CALC_CO
	[BaseDeduction] money NULL,--DEDBAZA_
	[TaxLimit] money,--very importnat,LIM_IMP_
	[TaxLimitInf] money,--4582><10000 LIM_IMP_Inf
	[TaxLimitSup] money,---10000, taxa limita pana la care are scutire,LIM_INF_
	[TaxLimitPercentProfictRealization] money,--0.80%  daca na-re 80% profit , oamenii n-au scutiri,LIM_INF_SUP?
	[SalaryModification] money,--MODRETR_
	[AlgorithmCalculCAS] [numeric](18, 0) NULL,--SPCTR3_
	[HowToCalculateSalary] [numeric](18, 0) NULL,--per loc de munca sau cumulat,VARFISA_
	[UnionDay] smalldatetime,--24 Jan,ZI_GUV0_
	[BigFriday] smalldatetime,--3 mai ZI_GUV1_
	[Easter] smalldatetime,--6 mai ZI_GUV1_
	[Rusali] smalldatetime,--24 mai,Zi_GUV3_
	[StMaria] smalldatetime,--15 Aug,ZI_GUV4_
	[ChildDay] smalldatetime,--1 iunie,ZI_GUV5_
	[StAndrei] smalldatetime,--30 Nov,ZI_GUV6_
	[MediumSalaryOnEconomy] money,--SALMEDIU_
	--------------------------------------------------------
	--todo: find another solution
	[PrecedentYearMonthlyWorkDays] nvarchar(64) NULL,--20 20 23 18 22 20 21 22 21 22 21 18,ZILE_ANA_ 
	[CurrentYearMonthlyWorkDays] nvarchar(64) NULL,--20 20 23 18 22 20 21 22 21 22 21 18,ZILE_ANC_
	-------------------------------------------------------
	--[ApplicationPath]  nvarchar(128) NULL,--CALE_SOFT_
	[ApplicationVersion] nvarchar(128) NULL,--VERS_SOFT_
	--[PRODS1_PercentSuplemDeduction] [numeric](18, 0) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL
 CONSTRAINT [PK_Params] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


