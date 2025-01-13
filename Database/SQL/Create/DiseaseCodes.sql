USE [Contab]
GO

/****** Object:  Table [dbo].[DiseaseCodes]    Script Date: 11/4/2024 12:27:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
  if exists ( select * from sys.tables where name = N'DiseaseCodes')
 DROP TABLE [DiseaseCodes];
CREATE TABLE [dbo].[DiseaseCodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DiseaseCode] [nvarchar](8) NULL,
	[DiseaseDescription] [nvarchar](128) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL
) ON [PRIMARY]
GO


