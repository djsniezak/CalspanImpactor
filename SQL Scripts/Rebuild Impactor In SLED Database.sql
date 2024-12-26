
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*	Rebuild Impactor in SLED Database
*
*	Created: December 26, 2024
*
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

USE [CALSPAN_SLED]
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

USE [CALSPAN_SLED]
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

INSERT INTO ImpactorClient ([CompanyName], [ShortName], [ClientPrefix], [ClientCode], [Address1], [Address2], [City], [State], [Zip], [PhoneNumber], [Status])
				VALUES 
				('National Highway Traffic Safety Admisitration','NHTSA','FM','1','1200 New Jersey Ave. SE',NULL,'Washington','DC','20590',NULL, 1),
				('Rivian','Rivian','RIV','8892','123 Any Street','Upper','My City','MI','14042','7165551212', 1),
				('Foxtron','Fox','FOX','7345','456 My Street',NULL,'Your City',NULL,'222222','5555555555', 1),
				('Vinfast','Vin','VIN','9210','99 No Street',NULL,'Black',NULL,'9999999','2224560987', 1);
GO

USE [CALSPAN_SLED]
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

USE [CALSPAN_SLED]
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

USE [CALSPAN_SLED]
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

INSERT INTO ImpactorTestType ([TestName], [Description])
                 VALUES 
					('Adult Headform','Adult Headform'),
					('Child Headform','Child Headform'),
					('Small Guided (Upper Legform)',	'Small Guided (Upper Legform)'),
					('Small Guided (Other)',	'Small Guided (Other)'),
					('Large Guided','Large Guided'),
					('FlexPLI','FlexPLI'),
					('Other','Other'),
					('WS Rib Impactor', 'WS Rib'),
					('Knee Impactor','Knee Impactor');
GO
USE [CALSPAN_SLED]
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

INSERT INTO ImpactorType ([ImpactorTestTypeId], [SerialNumber], [Owner])
			VALUES
			(1,'7236','DTS'),
			(1,'4489','NHTSA'),
			(2,'7026', 'NHTSA'),
			(2,'1301','Tesla'),
			(6,'5176','Telsa'),
			(6,'8839','Lucid'),
			(6,'5461','NHTSA'),
			(3,'UL168','NHTSA'),
			(8,'CAL01',NULL),
			(9,'CAL02',NULL);

GO


USE [CALSPAN_SLED]
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

INSERT INTO Protocol ([ImpactorTypeId], [Name], [ImpactorMass], [TargetingMethod], [NormalImpactSpeed], [NormalImpactAngle])
				VALUES
				(1,'EuroNCAP',	4.50,'Aiming',	11.10,	65),
				(1,'GTR',	4.50,'PoFC',	9.70,	65),
				(2,'EuroNCAP',	3.50,'Aiming',	11.10,	50),
				(2,'GTR',	3.50,'PoFC',	9.70,	50);
GO

