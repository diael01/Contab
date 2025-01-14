USE [Contab]
GO

/****** Object:  Table [dbo].[WorkTypeCodes]    Script Date: 1/13/2025 7:19:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
 if exists ( select * from sys.tables where name = N'WorkDaysPerMonth')
 DROP TABLE WorkDaysPerMonth;
CREATE TABLE [dbo].WorkDaysPerMonth(
	[Id] [int] IDENTITY(1,1) primary key clustered NOT NULL,
	[Month] smallint not null,
	[MonthName] varchar(16), 
	WorkDaysNo smallint not null,
	[Year] smallint not null,
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL
) ON [PRIMARY]
GO


