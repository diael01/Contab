USE [Contab]
GO

/****** Object:  Table [dbo].[Retain]    Script Date: 1/13/2025 7:34:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
if exists ( select * from sys.tables where name = N'Increase')
 DROP TABLE Increase;
CREATE TABLE [dbo].Increase(
	[Id] int identity(1,1) primary key clustered not null,
) ON [PRIMARY]
GO


