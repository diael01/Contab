USE [Contab]
GO

/****** Object:  Table [dbo].[Organisation]    Script Date: 6/11/2024 3:33:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Organisation](
	[OrgNode] [hierarchyid] primary key clustered not null,
	[OrgLevel]  AS ([OrgNode].[GetLevel]()),
	[Type] int NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
	[LongName] [varchar](64) NULL,
	[Location] [varchar](64) NULL,
	[CodCor] int NULL,
	[CodGrm] [char](3) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](32) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](32) NOT NULL);

CREATE INDEX Org_BreadthFirst ON Organisation(OrgLevel, OrgNode);
GO 

