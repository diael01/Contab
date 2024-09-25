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
	[EmpNode] [hierarchyid] NOT NULL,
	[EmpNodeText] [nvarchar](128) NULL,
	[EmpLevel]  AS ([EmpNode].[GetLevel]()),
	[ManagerNode] [hierarchyid] NULL,
	[ManagerNodeText] [nvarchar](128) NULL,
	[ManagerNodeName] [nvarchar](128) NULL,
	[EmpFunctionNode] [hierarchyid] NOT NULL,
	[EmpFunctionNodeText] [nvarchar](128) NULL,
	[EmpFunctionNodeName] [nvarchar](128) NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Surname] [nvarchar](128) NULL,
	[Gender] [char](1) NULL,
	[Birthday] [smalldatetime] NULL,
	[CivilStatus] [char](1) NULL,
	[HiringDate] [smalldatetime] NULL,
	[FirstHiringDate] [smalldatetime] NULL,
	[CountyCode] [char](2) NULL,
	[Phone] [nvarchar](32) NULL,
	[Location] [varchar](128) NULL,
	[IdCardSerieNo] [nvarchar](128) NULL,
	[IdCardCnp] [nvarchar](128) NULL,
	[Bank1Code] [char](3) NULL,
	[Bank1Iban] [nvarchar](128) NULL,
	[LunchTickets] [int] NULL,
	[AvansOrLiquidaton] [bit] NULL,
	[YearSeniority] [int] NULL,
	[MonthSeniority] [int] NULL,
	[Insured] [bit] NULL,
	[Insurance] [nvarchar](128) NULL,
	[LastIdCardCreationDate] [smalldatetime] NULL,
	[Studies] [nvarchar](128) NULL,
	[Bank2Code] [char](3) NULL,
	[Bank2Iban] [nvarchar](128) NULL,
	[Retired] [bit] NULL,
	[RetirementSeniority] [char](2) NULL,
	[RetirementSupplement] [int] NULL,
	[RetirementExclusionReason] [int] NULL,
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpNode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Employee] FOREIGN KEY([ManagerNode])
REFERENCES [dbo].[Employee] ([EmpNode])
GO

ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Employee]
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Organisation] FOREIGN KEY([EmpFunctionNode])
REFERENCES [dbo].[Organisation] ([OrgNode])
GO

ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Organisation]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'CONSTRAINT',@level2name=N'FK_Employee_Employee'
GO

CREATE INDEX Emp_BreadthFirst ON Employee(EmpLevel, EmpNode);

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
