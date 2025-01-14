USE [Contab]
GO

/****** Object:  Table [dbo].[RetainCodes]    Script Date: 1/13/2025 7:19:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
 if exists ( select * from sys.tables where name = N'RetainCode')
 DROP TABLE [RetainCode];
CREATE TABLE [dbo].[RetainCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RetainCode] [nvarchar](8) NULL,
	[RetainDescription] [nvarchar](128) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL
) ON [PRIMARY]
GO


