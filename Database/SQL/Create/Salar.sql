USE Contab
GO
/****** Object:  Table [dbo].[Organisation]    Script Date: 6/11/2024 3:33:48 PM ******/
SET ANSI_NULLS ON
GO
--this table is a tree due to to SQL Srver feature HyerarchyId,
--however HyerarchyId doesnt work on Mac Azure Data Studio, only on Windows

SET QUOTED_IDENTIFIER ON
GO
 if exists ( select * from sys.tables where name = N'Salary')
 DROP TABLE [dbo].[Salary];
 GO

  CREATE TABLE [Salary] (
    Id int identity(1,1)  primary key clustered,
    [EmpNode] [hierarchyid] not null,
	[RecordChangeDayHistory]  int NULL,
	[Category] int NULL,
	[EmpGradation] [char](2) NULL,
	[MainSalary]			   Numeric(10,2), 
    [MgmtSalaryIncrease]       Numeric(8,2), 
    [EndWorkCode] [char](2) NULL,
	[EndWorkDate] [smalldatetime] NULL, 
	[EmpDeptNode] [hierarchyid] NOT NULL,--sectia
	[EmpActivityNode] [hierarchyid] NOT NULL,
	[EmpSubActivityNode] [hierarchyid] NOT NULL,
	[EmpFunctionNode] [hierarchyid] NOT NULL,
	[EmpShift] char(1) NOT NULL default 'Z', --day or night
	[HoursToWork] int  null, --8 hours, make it short
	[WorkGroup] int  null, --6- mineri, 3-IT
	[WorkExperienceSalaryIncrease] Numeric(10,2),
    [CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL
	 --? [Percent]                          Numeric(6,2), 
	--niv?
	--sp_v not used
	--?cont
	--retro110
	)
--[ZI_MOD]                           Integer, 
--[COD_FUNC]                         Char(6), 
--[CATEG]                            Integer, 
--[GRAD]                             Char(2), 
--[RETRIB]                           Numeric(10,2), 
--[IND_COND]                         Numeric(8,2), 
--[PROCENT]                          Numeric(6,2), 

--[COD_DCM]                          Char(1), 
--[AN_DCM]                           Integer, 
--[LN_DCM]                           Integer, 
--[ZI_DCM]                           Integer, 

--[COD_SEC]                          Integer, 
--[COD_ACT]                          Integer, 
--[COD_LM]                           Integer, 
--[SCH]                              Char(1), --= Z
--[REGIM_LZ]                         Integer, 
--[GRMUNCA]                          Integer, 
--[NIV]                              Char(1), 
--[SP_V]                             Integer, 
--[CONT]                             Char(10), 
--[RETRIBV]                          Numeric(10,0), 
--[RETR0110]                         Integer);


--  if exists ( select * from sys.tables where name = N'SALAR')
-- DROP TABLE [SALAR];
-- CREATE TABLE [SALAR] (
--[MARCA]                            Integer, 
--[ZI_MOD]                           Integer, 
--[COD_FUNC]                         Char(6), 
--[CATEG]                            Integer, 
--[GRAD]                             Char(2), 
--[RETRIB]                           Numeric(10,2), 
--[IND_COND]                         Numeric(8,2), 
--[PROCENT]                          Numeric(6,2), 
--[COD_DCM]                          Char(1), 
--[AN_DCM]                           Integer, 
--[LN_DCM]                           Integer, 
--[ZI_DCM]                           Integer, 
--[COD_SEC]                          Integer, 
--[COD_ACT]                          Integer, 
--[COD_LM]                           Integer, 
--[SCH]                              Char(1), 

--[REGIM_LZ]                         Integer, 
--[GRMUNCA]                          Integer, 

--[NIV]                              Char(1), 
--[SP_V]                             Integer, 
--[CONT]                             Char(10), 
--[RETRIBV]                          Numeric(10,0), 
--[RETR0110]                         Integer);
