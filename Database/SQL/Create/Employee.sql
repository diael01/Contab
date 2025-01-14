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
	[Id] int identity(1,1) primary key clustered not null,
	[EmpNode] hierarchyid,--  NOT NULL, 
	EmpRecordChangeDate smalldatetime,--[ZIM]= only 5 changes allowed per month = ZIM = zi modificare 0-30
	[Name] nvarchar(128)		NOT NULL,-- default 'Jannie Doe',
	[IdCardSerieNo] nvarchar(128) not NULL,
	[IdCardCnp] numeric(13,0) not NULL,
	[LastIdCardCreationDate] smalldatetime not NULL,--CALIF?
	[LastIdCardCreatedBy] smalldatetime not NULL,--adresa3?
	[MainSalary]			  Money not null, --numeric(10,2) not null,-- default 1500.05,= RETRIB
	[HiringDate] smalldatetime not NULL default sysdatetime(),
	
	[EmpShift] char(1) NOT NULL default 'Z', --day or night
	[CountyCode] char(2) not NULL,-- default 'NY',
	[WorkGroup] smallint not null default 3 , --6- mineri, 3-IT
	----------------------------------------------------------------------------------
	--[WorkTypeContract] smallint not null default 0,--=[SP]? --0 sau 1=tesa, --1 inseamna normal, 8 ore,
	--                                                   --0, 3censori, 4 pensionri,--12,13,14,17,--42,23,-48
	--												   --bica =44, =  4 pensionar si 4 = nr de ore
	--								-- contract de munca = PEN_SUP
	--WORKTYPECONTRACT=RETIRED+HOURSTOWORK
	[HoursToWork] smallint not null default 8, --8 hours, make it short
    [Retired] bit not NULL default 0,--0 nepensionar, 1 pensionar --PEN_FC?
	RetirementPilonGovt smallint default 0, --PILON? --se pune cifra 2 daca vrea sa participe la pilonul 2 de pensii
	-----------------------------------------------------------------
	[Studies] char(4) not null,-- G=lice=studiigenerale, PROF-profesional, M - medii, PL=postliceal, S=superior, CC=curs calificare
							--SSD=studii superioare de scurta durata, G+CC= generale+curs calificare,
	[CivilStatus] char(1),
	SignalDeduction bit default 1, --1 - are deducere, 2 n-are deducere (deducere) LA calculul IMPOZITului
	SignalImpozit bit default 0, --PEN_FC dac are impozit sau nu,  --PEN_FC= cu impozit, 1=invalid gr1, 2=invgrd 2, 3 =fara imp = Semnal Impozit
	HealthExempted bit default 0,--0 NA,1=exc, 1=nuexc dela plata cass=sanatate si CAS=casa de pensii
	HealthExemptionReason bit default 0, -- 1 trebie adaugat motivul exceptarii - 1=elevei, 2=ucenici,3= cu dizabilitati, 4=pensionari, fara func baza
	--PensionExemption bit default 0,
	--impozitul de calculeaza adar nu plteste omul ci statul
	--ContractType
	
	[WorkEmail] nvarchar(128) not null default 'email@org.com', 
	[Gender] char(1) not NULL default 'F',
	[Birthday] smalldatetime not NULL,-- default sysdatetime(),
	[EmpDeptNode] hierarchyid,--sectia
	[EmpActivityNode] hierarchyid,-- NOT NULL,--activitate
	[EmpWorkTypeNode] hierarchyid,-- NOT NULL,--loc munca care e impropriu, spus tipul de munca
	[EmpFunctionNode] hierarchyid,-- NOT NULL,--functie
	[EmpDeptNodeName] varchar(128) NOT NULL,--sectia
	[EmpActivityNodeName] varchar(128),--activitate
	[EmpWorkTypeNodeName] varchar(128),--loc munca care e impropriu, spus tipul de munca
	[EmpFunctionNodeName] varchar(128) NOT NULL,--functie
	----from Salar
	[ManagerNode] hierarchyid, --Not NULL,
	[PersonalEmail] nvarchar(128), 
	[Surname] nvarchar(128),
	[Bank1Code] char(3),
	Iban1 char(24),
	[Bank2Code] char(3),
	Iban2 char(24),
	[Phone] nvarchar(128),
	--[Category] smallint, --CATEG --muncitor calificat categoria 5
	--[EmpGradation] char(2),--STUDII
	 [MgmtSalaryIncrease]  Money default 0, --IND_COND
    [EndWorkCode] char(2),
	[EndWorkDate] smalldatetime, 
	[WorkExperienceSalaryIncrease] Money default 0,																	
	[FirstJobHiringDate] smalldatetime,--
	[Location] [varchar](128) NULL,--adresa
	[MealTickets] bit default 0,--T_Cl
	[AdvanceOrLiquidaton] bit,--AV_LI2
	[YearSeniority] smallint,--AN_SV
	[MonthSeniority] smallint,--LN_SV
	[Insured] bit,--ASIGS5
	[Insurance] nvarchar(128) ,--ASCASA
	
	
	[RetirementSeniority] char(2),--P_SV
	[RetirementSupplement] smallint,--PEN_SUB
	[RetirementExclusionReason] smallint,--MOTIVEXC
	
	-------------din pontaj1,2
	MoneyAdvance Money null, --AVC, --[ZILAN]   Char(2), --?DateCalculationPontaj1 smalldatetime,--redundant, TBD check if it can be in param
	ExceptedRetributionDays smallint, --ZIRE, 
							--ZILE retributiei exceptata, poajul1 se face pt zilelelucrate intre 1-15 ale lunii
							--pontajul poatee permite zile nepontate
	--in pontaj2
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
	--RetinerAvans
	CodRetentionAdvance smallint,--COD_RET
	AdvanceDocumentNo nvarchar(128),--NR_DOC, nr documentlui de imrpumut dex la casa
	RateRetentionAdvance  Money,--RATA_CHZ1
	FundEnterDate smalldatetime, --LN_I_CAR,AN_I_CAR, CAR=Casa de ajutor reciproc, old commie value
	FundTax Money,--TAX_CAR
	FundTotal Money,--FOND_CAR
	MonthlyContributionToFound Money,--CORIZ_LN,
	BorrowingDate smalldatetime, --LN_IMPR,AN_IMPR
	BorrowedHowMuch Money, --IMPR_ACORD, cat s-a imprumutat
	ReturnedHowMuch Money, --IMPR_RET
	InterestOnBorrowed numeric, --DOB_CAR
	InterestRestant Money, --DOB_RES
	InterestNotCalculated Money, --NECAL_DOB
	RateRetentionLiquidation Money, --RATA_CHZ2, --CHZ_PR?, RATA_RCHZ1?, ARR numeric(8,2)?
	-------------------------------------
	--RetineriLichidare
	CodRetentionLiquidation smallint,--RETZ
	CodRetentionBeneficiary smallint, --BEN
	LiquidationDocumentNo smallint, --NRDOC
	LiquidationDocumentDate smalldatetime,--ANDOC,LNDOC,ZIDOC
	MonthlyRetentionRate Money,--DRL, RLR?,RRL?,DDL?,DL?, RDL?, 
	Penalty Money, --DPEN, ROL?, --SV
	LastRate Money, --UR, TP60,PROC60?, RLR_LIC?, RLR_AV?
	OtherRate Money,--RATE, 
	PriorityRate Money,
	-------------------------------------------------------------
	--Increases=Sporuri ----
	[IncreaseCode] char(1) NULL,--CDSP codul sporului, poate fi percent sau ore, PR sau PO, tot in tabela de coduri
	[Base] money,--BAZSP o baza sporului? poate fi egala cu salariul
	[WorkQuantity]  numeric,--CANTSP nr de ore sau procent lucrat in plus
	[IncreaseValue] money,--VALSP
	[TotalIncreaseValue] money,--VALT
	[IncreaseCode2] char(1) NULL,--codul sporului, poate fi percent sau ore, PR sau PO, tot in tabela de coduri
	[Base2] money,--o baza sporului? 
	[WorkQuantity2]  numeric,--nr de ore sau procent lucrat in plus
	[IncreaseValue2] money,
	[TotalIncreaseValue2] money,
	[IncreaseCode3] char(1) NULL,--CDSP codul sporului, poate fi percent sau ore, PR sau PO, tot in tabela de coduri
	[Base3] money,--BAZSP o baza sporului? poate fi egala cu salariul
	[WorkQuantity3]  numeric,--CANTSP nr de ore sau procent lucrat in plus
	[IncreaseValue3] money,--VALSP
	[TotalIncreaseValue3] money,--VALT
	[IncreaseCode4] char(1),--CDSP codul sporului, poate fi percent sau ore, PR sau PO, tot in tabela de coduri
	[Base4] money,--BAZSP o baza sporului? poate fi egala cu salariul
	[WorkQuantity4]  numeric, --CANTSP nr de ore sau procent lucrat in plus
	[IncreaseValue4] money,--VALSP
	[TotalIncreaseValue4] money,--VALT
	--adauga opt sporuri
	[SALINLOC_ReplacementSalaryForWhichInCalculateTheIncrease] numeric(18,1) NULL,
	RO1_HourlyRegimeForIncreaseCalculations numeric, -- calculated filed care reprzinta retributia/nr de orelucrate fara sporuri
    RO2_HourlyRegimeForIncreaseCalculations numeric,
	RO3_HourlyRegimeForIncreaseCalculations numeric,
	RO4_HourlyRegimeForIncreaseCalculations numeric,
	--adauga pana la RO8
	-------------------------------------------------------------
	--Plati in avans PLAV.sql table - sau premii sau bonuses
	--[LN]                               Integer, --luna curenta e aceea din Par
	GrossBonus		money, --SUMA
	NetBonus		money,--[NET]                              Integer, --[CHEIE]                            Char(6), 
	BonusPayDate	smalldatetime,
	BonusType		char(1), -- 'I' se impoziteaza, 'N' nu se impoziteaza, 'S' special - sumele introuse se imp limitat(se imp numai suma care dep limita din Params - afiseza limita dex 300)									--[TS]                               Char(1), ???
	ContributionToHealth		money,--[SAN]                              Numeric(7,2), 
	ContributinToRetirement		money,--[CAS]                              Numeric(7,2), 
	ContributionToUnemployment	money,--[SOM]                              Numeric(7,2), 
	TotalTaxOnAdvance			money,--[IMP]                              Integer, 
	AllOrOnlyWomenOrOnlyMen		char(1), --T=total, F=femei, B = barbati
	--[CARDL]                            Numeric(10,2), ? to find ce fel de suma este; n-au legatura cu banca
	--[TIPCARD]                          Char(1), ? to find; n-au legatura cu banca
	--[RET]                              Integer, --codRetinere? de ce am evoie de el cn am ret avand si lichidare????
	---------------------------------------------------------------------
	[EmpNodeText] [nvarchar](128) NULL,
	[EmpNodeName] [nvarchar](128) NULL,
	[EmpLevel]  AS ([EmpNode].[GetLevel]()),
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL
	)
GO
CREATE INDEX Emp_BreadthFirst ON Employee(EmpLevel, EmpNode);


