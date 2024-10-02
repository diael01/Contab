USE Contab
GO
/****** Object:  Table [dbo].[Organisation]    Script Date: 6/11/2024 3:33:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
 if exists ( select * from sys.tables where name = N'Organisation')
 DROP TABLE [dbo].[Organisation];
 GO
CREATE TABLE [dbo].[Organisation](
	--Id int identity(1,1) primary key clustered not null,
	[OrgNode] [hierarchyid] primary key clustered not null,
	[OrgNodeText] [nvarchar](128),
	[ParentNode] [hierarchyid],
	[ParentNodeText] [nvarchar](128),
	[ParentNodeName] [nvarchar](128),--this is to add a node based on the Parent Node name for easy Swagger
	[OrgLevel]  AS ([OrgNode].[GetLevel]()),
	[Name] [nvarchar](128) NOT NULL,
	[Surname] [varchar](128) NULL,
	[CountyCode]  [char](2) NULL, --cod judet
	[Location] [varchar](128) NULL, --adresa
	[CodCor] int NULL,
	[CodGrm] [char](3) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL);
CREATE INDEX Org_BreadthFirst ON Organisation(OrgLevel, OrgNode);
GO 

