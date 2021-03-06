/****** Object:  ForeignKey [FK_Pais_Region]    Script Date: 01/06/2015 01:15:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Pais_Region]') AND parent_object_id = OBJECT_ID(N'[dbo].[Pais]'))
ALTER TABLE [dbo].[Pais] DROP CONSTRAINT [FK_Pais_Region]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 01/06/2015 01:15:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Pais_Region]') AND parent_object_id = OBJECT_ID(N'[dbo].[Pais]'))
ALTER TABLE [dbo].[Pais] DROP CONSTRAINT [FK_Pais_Region]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pais]') AND type in (N'U'))
DROP TABLE [dbo].[Pais]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 01/06/2015 01:15:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Region]') AND type in (N'U'))
DROP TABLE [dbo].[Region]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 01/06/2015 01:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Region]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Region](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 01/06/2015 01:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pais]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Pais](
	[Codigo] [char](2) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[RegionId] [bigint] NOT NULL,
	[Image] [varchar](max) NOT NULL,
	[Poblacion] [numeric](18, 0) NULL,
	[PBI] [numeric](18, 4) NULL,
	[FechaRelevamiento] [smalldatetime] NOT NULL,
	[Texto] [varchar](100) NOT NULL,
	[Capital] [varchar](50) NOT NULL,
	[PrefijoTel] [varchar](50) NOT NULL,
	[Presidente] [varchar](50) NOT NULL,
	[Himno] [varchar](100) NOT NULL,
	[Provincia] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  ForeignKey [FK_Pais_Region]    Script Date: 01/06/2015 01:15:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Pais_Region]') AND parent_object_id = OBJECT_ID(N'[dbo].[Pais]'))
ALTER TABLE [dbo].[Pais]  WITH CHECK ADD  CONSTRAINT [FK_Pais_Region] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Region] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Pais_Region]') AND parent_object_id = OBJECT_ID(N'[dbo].[Pais]'))
ALTER TABLE [dbo].[Pais] CHECK CONSTRAINT [FK_Pais_Region]
GO
