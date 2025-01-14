USE [Contab]
GO

/****** Object:  Table [dbo].[WorkTypeCodes]    Script Date: 1/13/2025 7:19:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
 if exists ( select * from sys.tables where name = N'HolidayCode')
 DROP TABLE [HolidayCode];
CREATE TABLE [dbo].[HolidayCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HolidayCode] [nvarchar](8) NULL,
	[HolidayDescription] [nvarchar](128) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL
) ON [PRIMARY]
GO


