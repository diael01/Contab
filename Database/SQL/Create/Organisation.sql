USE Contab
GO
/****** Object:  Table [dbo].[Organisation]    Script Date: 6/11/2024 3:33:48 PM ******/
SET ANSI_NULLS ON
GO
--this table is a tree due to to SQL Srver feature HyerarchyId,
--however HyerarchyId doesnt work on Mac Azure Data Studio, only on Windows

SET QUOTED_IDENTIFIER ON
GO
 if exists ( select * from sys.tables where name = N'Organisation')
 DROP TABLE [dbo].[Organisation];
 GO
CREATE TABLE [dbo].[Organisation](
	[Node] [hierarchyid] primary key clustered not null, --node could ne the organisation, department, activity or function
	[NodeAsText] [nvarchar](128),
	[NodeAsName] [nvarchar](128),
	[ParentNode] [hierarchyid],
	[NodeLevel]  AS ([Node].[GetLevel]()),
	[Name] [nvarchar](128) NOT NULL,
	[CountyCode]  [char](2) NULL, --cod judet
	[Location] [varchar](128) NULL, --adresa
	[CodCor] int NULL,
	[CodGrm] [char](3) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL);
CREATE INDEX Org_BreadthFirst ON Organisation(NodeLevel, Node);
GO 

--department => sectia ex "personal technco. prod
--activitate => "contructii-montaj
--subactivitate=> "loc de munca" ex. "TASediu"
--schimb zi noapte 
--functie => 1 mercolog, 3 ingineri