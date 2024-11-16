USE [CALSPAN_SLED]
GO

/****** Object:  Table [dbo].[tblImpactorAxis]    Script Date: 11/11/2024 2:01:08 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblImpactorAxis]') AND type in (N'U'))
DROP TABLE [dbo].[tblImpactorAxis]
GO

USE [CALSPAN_SLED]
GO

/****** Object:  Table [dbo].[tblImpactorClient]    Script Date: 11/11/2024 2:01:18 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblImpactorClient]') AND type in (N'U'))
DROP TABLE [dbo].[tblImpactorClient]
GO

USE [CALSPAN_SLED]
GO

/****** Object:  Table [dbo].[tblImpactorParameters]    Script Date: 11/11/2024 2:01:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblImpactorParameters]') AND type in (N'U'))
DROP TABLE [dbo].[tblImpactorParameters]
GO

USE [CALSPAN_SLED]
GO

/****** Object:  Table [dbo].[tblImpactorTest]    Script Date: 11/11/2024 2:01:47 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblImpactorTest]') AND type in (N'U'))
DROP TABLE [dbo].[tblImpactorTest]
GO

USE [CALSPAN_SLED]
GO

/****** Object:  Table [dbo].[tblImpactorType]    Script Date: 11/11/2024 2:02:06 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblImpactorType]') AND type in (N'U'))
DROP TABLE [dbo].[tblImpactorType]
GO

USE [CALSPAN_SLED]
GO

/****** Object:  Table [dbo].[tblImpactorTestType]    Script Date: 11/11/2024 2:10:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblImpactorTestType]') AND type in (N'U'))
DROP TABLE [dbo].[tblImpactorTestType]
GO






