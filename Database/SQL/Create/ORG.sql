USE [Contab]
GO

/****** Object:  Table [dbo].[Organisation]    Script Date: 6/11/2024 3:33:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Organisation](
	[Id] int identity(1,1) primary key clustered not null,
	[OrgNode] [hierarchyid],--primary key clustered not null,
	[OrgNodeText] [nvarchar](128),
	[ParentNode] [hierarchyid],
	[ParentNodeText] [nvarchar](128),
	[OrgLevel]  AS ([OrgNode].[GetLevel]()),
	[Level] int NOT NULL,
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

