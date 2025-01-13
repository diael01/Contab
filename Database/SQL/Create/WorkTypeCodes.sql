USE [Contab]
GO

/****** Object:  Table [dbo].[WorkTypeCodes]    Script Date: 1/13/2025 7:19:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
 if exists ( select * from sys.tables where name = N'WorkTypeCodes')
 DROP TABLE [WorkTypeCodes];
CREATE TABLE [dbo].[WorkTypeCodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkTypeCode] [nvarchar](8) NULL,
	[WorkTypeDescription] [nvarchar](128) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL
) ON [PRIMARY]
GO


