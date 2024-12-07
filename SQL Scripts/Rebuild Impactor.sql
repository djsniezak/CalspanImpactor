
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*	Rebuild Impactor
*
*	Created: December 7, 2024
*
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorAxis]    Script Date: 12/7/2024 10:41:19 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImpactorAxis]') AND type in (N'U'))
DROP TABLE [dbo].[ImpactorAxis]
GO

/****** Object:  Table [dbo].[ImpactorAxis]    Script Date: 12/7/2024 10:41:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorAxis](
	[ImpactorAxisId] [bigint] IDENTITY(1,1) NOT NULL,
	[ImpactorTestId] [bigint] NULL,
	[ImpactorParameterId] [bigint] NULL,
	[SetName] [varchar](50) NULL,
	[XAxis] [int] NULL,
	[YAxis] [int] NULL,
	[ZAxis] [int] NULL,
	[Alpha] [decimal](5, 2) NULL,
 CONSTRAINT [PK_ImpactorAxis] PRIMARY KEY CLUSTERED 
(
	[ImpactorAxisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorClient]    Script Date: 12/7/2024 10:42:53 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImpactorClient]') AND type in (N'U'))
DROP TABLE [dbo].[ImpactorClient]
GO

/****** Object:  Table [dbo].[ImpactorClient]    Script Date: 12/7/2024 10:42:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorClient](
	[ImpactorClientId] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NULL,
	[ShortName] [varchar](50) NULL,
	[ClientPrefix] [varchar](3) NULL,
	[ClientCode] [varchar](8) NULL,
	[Address1] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](2) NULL,
	[Zip] [varchar](7) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_ImpactorClient] PRIMARY KEY CLUSTERED 
(
	[ImpactorClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorParameters]    Script Date: 12/7/2024 10:43:05 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImpactorParameters]') AND type in (N'U'))
DROP TABLE [dbo].[ImpactorParameters]
GO

/****** Object:  Table [dbo].[ImpactorParameters]    Script Date: 12/7/2024 10:43:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorParameters](
	[ImpactorParametersId] [bigint] IDENTITY(1,1) NOT NULL,
	[ImpactorTestId] [bigint] NULL,
	[ImpactorTypeId] [bigint] NULL,
	[Temperature] [decimal](5, 2) NULL,
	[Humidity] [decimal](5, 2) NULL,
	[Trigger1] [int] NULL,
	[Trigger2] [int] NULL,
	[ParmsId] [bigint] NULL,
	[Notes] [varchar](500) NULL,
	[FirePressure] [decimal](5, 1) NULL,
	[CylinderSpeed] [int] NULL,
	[MeasuredSpeed] [int] NULL,
	[WithOutImpactorSetPoint] [int] NULL,
	[AcceleratorTemperature] [decimal](5, 2) NULL,
	[TankTemperature] [decimal](5, 2) NULL,
	[Airbag1] [int] NULL,
	[Airbag2] [int] NULL,
	[Airbag3] [int] NULL,
 CONSTRAINT [PK_ImpactorParameters] PRIMARY KEY CLUSTERED 
(
	[ImpactorParametersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorTest]    Script Date: 12/7/2024 10:43:20 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImpactorTest]') AND type in (N'U'))
DROP TABLE [dbo].[ImpactorTest]
GO

/****** Object:  Table [dbo].[ImpactorTest]    Script Date: 12/7/2024 10:43:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorTest](
	[ImpactorTestId] [bigint] IDENTITY(1,1) NOT NULL,
	[TestRunNumber] [varchar](50) NULL,
	[RunTime] [datetime] NULL,
	[CustomerId] [bigint] NULL,
	[Specimen] [varchar](50) NULL,
	[Engineer] [varchar](50) NULL,
	[Operator] [varchar](50) NULL,
	[TestTypeId] [bigint] NULL,
	[ProtocolId] [bigint] NULL,
	[Notes] [varchar](500) NULL,
 CONSTRAINT [PK_ImpactorTest] PRIMARY KEY CLUSTERED 
(
	[ImpactorTestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorTestType]    Script Date: 12/7/2024 10:43:42 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImpactorTestType]') AND type in (N'U'))
DROP TABLE [dbo].[ImpactorTestType]
GO

/****** Object:  Table [dbo].[ImpactorTestType]    Script Date: 12/7/2024 10:43:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorTestType](
	[ImpactorTestTypeId] [bigint] IDENTITY(1,1) NOT NULL,
	[TestName] [varchar](50) NULL,
	[Description] [varchar](100) NULL,
 CONSTRAINT [PK_ImpactorTestType] PRIMARY KEY CLUSTERED 
(
	[ImpactorTestTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorType]    Script Date: 12/7/2024 10:43:56 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImpactorType]') AND type in (N'U'))
DROP TABLE [dbo].[ImpactorType]
GO

/****** Object:  Table [dbo].[ImpactorType]    Script Date: 12/7/2024 10:43:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorType](
	[ImpactorTypeId] [bigint] IDENTITY(1,1) NOT NULL,
	[ImpactorTestTypeId] [bigint] NULL,
	[SerialNumber] [varchar](50) NULL,
	[Owner] [varchar](50) NULL,
 CONSTRAINT [PK_ImpactorType] PRIMARY KEY CLUSTERED 
(
	[ImpactorTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  Table [dbo].[Protocol]    Script Date: 12/7/2024 10:44:10 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Protocol]') AND type in (N'U'))
DROP TABLE [dbo].[Protocol]
GO

/****** Object:  Table [dbo].[Protocol]    Script Date: 12/7/2024 10:44:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Protocol](
	[ProtocolId] [bigint] IDENTITY(1,1) NOT NULL,
	[ImpactorTypeId] [bigint] NULL,
	[Name] [varchar](50) NULL,
	[ImpactorMass] [decimal](5, 2) NULL,
	[TargetingMethod] [varchar](50) NULL,
	[NormalImpactSpeed] [decimal](5, 2) NULL,
	[NormalImpactAngle] [int] NULL,
 CONSTRAINT [PK_Protocol] PRIMARY KEY CLUSTERED 
(
	[ProtocolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



