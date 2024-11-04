USE [Contab]
GO

/****** Object:  Table [dbo].[IncreaseCodes]    Script Date: 11/4/2024 12:42:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if exists ( select * from sys.tables where name = N'IncreaseCodes')
 DROP TABLE [IncreaseCodes];
CREATE TABLE [dbo].[IncreaseCodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IncreaseCode] [nvarchar](8) NULL,
	[IncreaseDescription] [nvarchar](128) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL
) ON [PRIMARY]
GO


