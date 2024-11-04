USE [Contab]
GO

/****** Object:  Table [dbo].[Disease]    Script Date: 11/4/2024 12:25:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
  if exists ( select * from sys.tables where name = N'DiseaseHist')
 DROP TABLE [DiseaseHist];
CREATE TABLE [dbo].[DiseaseHist](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpNode] [hierarchyid] NOT NULL,
	[EmpRecordChangeDate] [smalldatetime] NULL,
	[CodeDisease] [int] NULL,
	[StartDateofMedicalHoliday] [smalldatetime] NULL,
	[NoDiseaseDayCalend] [int] NULL,
	[NoDiseaseDayWork] [int] NULL,
	[NoDiseaseDayWorkPaidByEmployer] [int] NULL,
	[NoDiseaseDayWorkPaidByGovt] [int] NULL,
	[NetSalaryOnTheLast12Months] [money] NULL,
	[NetSalaryPerDayOnTheLast12Months] [money] NULL,
	[NoWorkDaysPerLast12Months] [int] NULL,
	[NoCalendDaysPerLast12Months] [int] NULL,
	[StartDateOfTheDisease] [smalldatetime] NULL,
	[EndDateOfTheDisease] [smalldatetime] NULL,
	[DiseaseIsInitialOrContinued] [bit] NULL,
	[MedCertificateCode] [char](2) NULL,
	[MedCertificateSerie] [char](10) NULL,
	[MedCertificateNo] [char](10) NULL,
	[MedCertificateCodeContinue] [char](2) NULL,
	[MedCertificateSerieContinued] [char](10) NULL,
	[MedCertificateNumberContinued] [char](10) NULL,
	[UrgencyCode] [char](3) NULL,
	[ContagiousCode] [char](2) NULL,
	[ChildCnp] [numeric](13, 0) NULL,
	[DoctorLicenseNumber] [char](10) NULL,
	[DateMedicalCertificate] [smalldatetime] NULL,
	[LocationCode] [int] NULL,
	[DiagnosticCode] [int] NULL,
	[OtherPersonInCareCnp] [numeric](13, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


