USE [master]
GO
/****** Object:  Database [Impactor]    Script Date: 11/2/2024 3:45:52 PM ******/
CREATE DATABASE [Impactor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Impactor', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Impactor.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Impactor_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Impactor_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Impactor] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Impactor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Impactor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Impactor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Impactor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Impactor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Impactor] SET ARITHABORT OFF 
GO
ALTER DATABASE [Impactor] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Impactor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Impactor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Impactor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Impactor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Impactor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Impactor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Impactor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Impactor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Impactor] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Impactor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Impactor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Impactor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Impactor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Impactor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Impactor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Impactor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Impactor] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Impactor] SET  MULTI_USER 
GO
ALTER DATABASE [Impactor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Impactor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Impactor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Impactor] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Impactor] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Impactor] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Impactor] SET QUERY_STORE = OFF
GO

USE [Impactor]
GO


/****** Object:  Table [dbo].[ImpactorTest]    Script Date: 10/1/2024 10:57:24 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorTest]    Script Date: 10/1/2024 11:07:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: July 22, 2024
-- Description:	A procedure to insert a record into the Impactor Test Table
-- =============================================
CREATE PROCEDURE [dbo].[InsertImpactorTest]
	
	@TestRunNumber varchar(50),
	@RunTime datetime,
	@CustomerId bigint,
	@Specimen varchar(50),
	@Engineer varchar(50),
	@Operator varchar(50),
	@TestTypeId bigint,
	@ProtocolId bigint,
	@Notes varchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[ImpactorTest] ([TestRunNumber], [RunTime], [CustomerId],[Specimen], [Engineer], [Operator], [TestTypeId], [ProtocolId], [Notes])
	                             VALUES (@TestRunNumber, @RunTime, @CustomerId, @Specimen, @Engineer, @Operator,@TestTypeId, @ProtocolId, @Notes)
	SELECT @@IDENTITY
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorTest]    Script Date: 10/1/2024 11:06:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: July 22, 2024
-- Description:	A stored procedure to get an Impactor Test Record
-- =============================================
CREATE PROCEDURE [dbo].[GetImpactorTest] 
	
		@ImpactorTestId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ImpactorTestId], [TestRunNumber], [RunTime], [CustomerId], [Specimen], [Engineer], [Operator], [TestTypeId], [ProtocolId], [Notes]
	FROM [dbo].[ImpactorTest]
	WHERE [ImpactorTestId] = @ImpactorTestId
END
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetAllImpactorTests]    Script Date: 10/1/2024 11:05:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: August 3, 2024
-- Description:A procedure to get All of the Impactor Tests
-- =============================================
CREATE PROCEDURE [dbo].[GetAllImpactorTests]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT [ImpactorTestId], [TestRunNumber], [RunTime], [CustomerId], [Specimen], [Engineer], [Operator], [TestTypeId], [ProtocolId], [Notes]
   FROM [dbo].[ImpactorTest]
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateImpactorTest]    Script Date: 10/1/2024 11:09:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: July 22, 2024
-- Description:	A procedure to update an Impactor Test record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateImpactorTest]
	
	@ImpactorTestId bigint,
	@TestRunNumber varchar(50),
	@RunTime datetime,
	@CustomerId bigint,
	@Specimen varchar(50),
	@Engineer varchar(50),
	@Operator varchar(50),
	@TestTypeId bigint,
	@ProtocolId bigint,
	@Notes varchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[ImpactorTest] SET
		[TestRunNumber] = @TestRunNumber,
		[RunTime] = @RunTime,
		[CustomerId] = @CustomerId,
		[Specimen] = @Specimen,
		[Engineer] = @Engineer,
		[Operator] = @Operator,
		[TestTypeId] = @TestTypeId,
		[ProtocolId] = @ProtocolId,
		[Notes] = @Notes
	WHERE [ImpactorTestId] = @ImpactorTestId
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetLastRunNumber]    Script Date: 7/22/2024 3:02:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: July 22, 2024
-- Description:	A procedure to get the last Impactor Test Number for a Customer in a given year
-- =============================================
CREATE PROCEDURE [dbo].[GetLastRunNumber]
	
	@RunNumber varchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Search varchar(50)
	SET @Search = @RunNumber + '%'

	SELECT TOP 1 TestRunNumber FROM [dbo].[ImpactorTest] WHERE TestRunNumber LIKE  @Search
	ORDER BY TestRunNumber DESC
END
GO


-- Impactor Parameters

USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorParameters]    Script Date: 10/6/2024 1:56:03 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorParameters]    Script Date: 10/6/2024 1:57:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: July 23, 2024
-- Description:	A procedure to get an Impactor Parameter Record
-- =============================================
CREATE PROCEDURE [dbo].[GetImpactorParameters]
	
	@ImpactorParametersId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  	SELECT [ImpactorParametersId], [ImpactorTestId], [ImpactorTypeId], [Temperature], [Humidity], [Trigger1], [Trigger2], 
	       [Notes], [FirePressure], [CylinderSpeed], [MeasuredSpeed], [WithOutImpactorSetPoint], [AcceleratorTemperature], 
		   [TankTemperature], [Airbag1], [Airbag2], [Airbag3]
    FROM [dbo].[ImpactorParameters]
	WHERE [ImpactorParametersId] = @ImpactorParametersId
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorParametersForAnImpactorTest]    Script Date: 10/6/2024 1:58:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: August 10, 2024
-- Description:	A procedure to get the Impactor Parameters for an Impactor Test
-- =============================================
CREATE PROCEDURE [dbo].[GetImpactorParametersForAnImpactorTest] 
	@ImpactorTestId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  	SELECT [ImpactorParametersId], [ImpactorTestId], [ImpactorTypeId], [Temperature], [Humidity], [Trigger1], [Trigger2], 
	       [Notes], [FirePressure], [CylinderSpeed], [MeasuredSpeed], [WithOutImpactorSetPoint], [AcceleratorTemperature], 
		   [TankTemperature], [Airbag1], [Airbag2], [Airbag3]
    FROM [dbo].[ImpactorParameters]
	WHERE [ImpactorTestId] = @ImpactorTestId
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorParameter]    Script Date: 10/6/2024 2:01:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: August 5, 2024
-- Description:	A procedure to Insert an Impactor Parameter Record
-- =============================================
CREATE PROCEDURE [dbo].[InsertImpactorParameter] 
	
	@ImpactorTestId bigint,
	@ImpactorTypeId bigint,
	@Temperature decimal(5,2),
	@Humidity decimal (5,2),
	@Trigger1 int,
	@Trigger2 int,
	@Notes varchar(500),
	@FirePressure decimal(5,1),
	@CylinderSpeed int,
	@MeasuredSpeed int,
	@WithOutImpactorSetPoint int,
	@AcceleratorTemperature decimal(5,2),
	@TankTemperature decimal(5,2),
	@Airbag1 int,
	@Airbag2 int,
	@Airbag3 int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[ImpactorParameters] ([ImpactorTestId], [ImpactorTypeId], [Temperature], [Humidity],
											   [Trigger1], [Trigger2], [Notes], [FirePressure], [CylinderSpeed], [MeasuredSpeed],
											   [WithOutImpactorSetPoint], [AcceleratorTemperature], [TankTemperature], [Airbag1], [Airbag2], [Airbag3])
									   VALUES (@ImpactorTestId, @ImpactorTypeId, @Temperature, @Humidity,
											   @Trigger1, @Trigger2, @Notes, @FirePressure, @CylinderSpeed, @MeasuredSpeed,  
											   @WithOutImpactorSetPoint, @AcceleratorTemperature, @TankTemperature, @Airbag1, @Airbag2, @Airbag3)
	 SELECT @@IDENTITY
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateImpactorParameter]    Script Date: 10/6/2024 2:02:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: August 5, 2024
-- Description:	A procedure to Update an Impactor Parameter Record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateImpactorParameter]
	
	@ImpactorParametersId bigint,
	@ImpactorTestId bigint,
	@ImpactorTypeId bigint,
	@Temperature decimal(5,2),
	@Humidity decimal (5,2),
	@Trigger1 int,
	@Trigger2 int,
	@Notes varchar(500),
	@FirePressure decimal(5,1),
	@CylinderSpeed int,
	@MeasuredSpeed int,
	@WithOutImpactorSetPoint int,
	@AcceleratorTemperature decimal(5,2),
	@TankTemperature decimal(5,2),
	@Airbag1 int,
	@Airbag2 int,
	@Airbag3 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[ImpactorParameters] SET
			[ImpactorTestId] = @ImpactorTestId,
			[ImpactorTypeId] = @ImpactorTypeId,
			[Temperature] = @Temperature,
			[Humidity] = @Humidity,
			[Trigger1] = @Trigger1,
			[Trigger2] = @Trigger2,
			[Notes]= @Notes,
			[FirePressure] = @FirePressure,
			[CylinderSpeed] = @CylinderSpeed,
			[MeasuredSpeed] = @MeasuredSpeed,
			[WithOutImpactorSetPoint] = @WithOutImpactorSetPoint,
			[AcceleratorTemperature] = @AcceleratorTemperature,
			[TankTemperature] = @TankTemperature,
			[Airbag1] = @Airbag1,
			[Airbag2] = @Airbag2,
			[Airbag3] = @Airbag3
    WHERE [ImpactorParametersId] = @ImpactorParametersId
END
GO

--Impactor Axis
USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorAxis]    Script Date: 8/5/2024 3:33:34 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetAnImpactorAxis]    Script Date: 8/5/2024 3:34:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: July 27, 2024
-- Description:	A routine to get an Impactor Axis Record
-- =============================================
CREATE PROCEDURE [dbo].[GetAnImpactorAxis]
	
	@ImpactorAxisId bigint,
	@SetName varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ImpactorAxisId], [ImpactorTestId], [ImpactorParameterId], [SetName], [XAxis], [YAxis], [ZAxis], [Alpha]
	FROM [dbo].[ImpactorAxis]
	WHERE [ImpactorAxisId] = @ImpactorAxisId
	     AND [SetName] = @SetName
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetAxisForImpactorTest]    Script Date: 8/5/2024 3:35:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: July 27, 2024
-- Description:	A procedure to get all of the Impactor Axis for an Impactor Test
-- =============================================
CREATE PROCEDURE [dbo].[GetAxisForImpactorTest]
	@ImpactorTestId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

     -- Insert statements for procedure here
	SELECT [ImpactorAxisId], [ImpactorTestId], [ImpactorParameterId], [SetName], [XAxis], [YAxis], [ZAxis], [Alpha]
	FROM [dbo].[ImpactorAxis]
	WHERE [ImpactorTestId] = @ImpactorTestId
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorAxis]    Script Date: 8/5/2024 3:38:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: July 27, 2024
-- Description: A procedure to insert an Impactor Axis Record
-- =============================================
CREATE PROCEDURE [dbo].[InsertImpactorAxis]
	
	@ImpactorTestId bigint,
    @ImpactorParameterId bigint,
	@SetName varchar(50),
	@XAxis int,
	@YAxis int,
	@ZAxis int,
	@Alpha decimal(5,2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[ImpactorAxis] ([ImpactorTestId], [ImpactorParameterId], [SetName], [XAxis], [YAxis], [ZAxis], [Alpha])
	                             VALUES (@ImpactorTestId, @ImpactorParameterId, @SetName, @XAxis, @YAxis, @ZAxis, @Alpha)
	SELECT @@IDENTITY

END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateImpactorAxisRecord]    Script Date: 8/5/2024 3:42:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: July 27, 2024
-- Description:	A procedure to update an Impactor Axis Record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateImpactorAxisRecord] 
	
	@ImpactorAxisId bigint,
	@ImpactorTestId bigint,
    @ImpactorParameterId bigint,
	@SetName varchar(50),
	@XAxis int,
	@YAxis int,
	@ZAxis int,
	@Alpha decimal(5,2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[ImpactorAxis] SET
		[ImpactorTestId] = @ImpactorTestId,
		[ImpactorParameterId] = @ImpactorParameterId,
		[SetName] = @SetName,
		[XAxis] = @XAxis,
		[YAxis] = @YAxis,
		[ZAxis] = @ZAxis,
		[Alpha] = @Alpha
	WHERE [ImpactorAxisId] = @ImpactorAxisId
END
GO



--Impactor Client
USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorClient]    Script Date: 8/3/2024 12:44:40 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorClient]    Script Date: 8/3/2024 12:49:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 2, 2024
-- Description:	A procedure to get an Impactor Client Record
-- =============================================
CREATE PROCEDURE [dbo].[GetImpactorClient] 
	
	@ImpactorClientId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ImpactorClientId], [CompanyName], [ShortName], [ClientPrefix], [ClientCode], [Address1], [Address2],
		   [City], [State], [Zip], [PhoneNumber], [Status]
	FROM [dbo].[ImpactorClient]
	WHERE [ImpactorClientId] = @ImpactorClientId
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetAllImpactorClients]    Script Date: 8/3/2024 12:51:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 3, 2024
-- Description:	A procedure to get all of the Impactor Clients
-- =============================================
CREATE PROCEDURE [dbo].[GetAllImpactorClients] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 -- Insert statements for procedure here
	SELECT [ImpactorClientId], [CompanyName], [ShortName], [ClientPrefix], [ClientCode], [Address1], [Address2],
		   [City], [State], [Zip], [PhoneNumber], [Status]
	FROM [dbo].[ImpactorClient]
	
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorClient]    Script Date: 8/3/2024 1:02:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 3, 2024
-- Description:	A procedure to Insert an Impactor Client
-- =============================================
CREATE PROCEDURE [dbo].[InsertImpactorClient]
	
	@CompanyName varchar(50),
	@ShortName varchar(50),
	@ClientPrefix varchar(3),
	@ClientCode varchar(8),
	@Address1 varchar(50),
	@Address2 varchar(50),
	@City varchar(50),
	@State varchar(2),
	@Zip varchar(7),
	@PhoneNumber varchar(20),
	@Status bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[ImpactorClient] ([CompanyName], [ShortName], [ClientPrefix], [ClientCode], [Address1],
										    [Address2], [City], [State], [Zip], [PhoneNumber], [Status])
								   VALUES (@CompanyName, @ShortName, @ClientPrefix, @ClientCode, @Address1,
								           @Address2, @City, @State, @PhoneNumber, @Zip, @Status)
	SELECT @@IDENTITY
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateImpactorClient]    Script Date: 8/3/2024 1:11:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 3, 2024
-- Description:	A procedure to update an Impactor Client Record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateImpactorClient] 
	
	 @ImpactorClientId bigint,
	 @CompanyName varchar(50),
	 @ShortName varchar(50),
	 @ClientPrefix varchar(3),
	 @ClientCode varchar(8),
	 @Address1 varchar(50),
	 @Address2 varchar(50),
	 @City varchar(50),
	 @State varchar(2),
	 @Zip varchar(7),
	 @PhoneNumber varchar(20),
	 @Status bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[ImpactorClient] SET
				 [CompanyName] = @CompanyName,
				 [ShortName] = @ShortName,
				 [ClientPrefix] = @ClientPrefix,
				 [ClientCode] = @ClientCode,
				 [Address1] = @Address1,
				 [Address2] = @Address2,
				 [City] = @City,
			     [Zip] = @Zip,
				 [PhoneNumber] = @PhoneNumber,
				 [Status] = @Status
	WHERE [ImpactorClientId] = @ImpactorClientId
END
GO

INSERT INTO ImpactorClient ([CompanyName], [ShortName], [ClientPrefix], [ClientCode], [Address1], [Address2], [City], [State], [Zip], [PhoneNumber], [Status])
				VALUES 
				('National Highway Traffic Safety Admisitration','NHTSA','FM','1','1200 New Jersey Ave. SE',NULL,'Washington','DC','20590',NULL, 1),
				('Rivian','Rivian','RIV','8892','123 Any Street','Upper','My City','MI','14042','7165551212', 1),
				('Foxtron','Fox','FOX','7345','456 My Street',NULL,'Your City',NULL,'222222','5555555555', 1),
				('Vinfast','Vin','VIN','9210','99 No Street',NULL,'Black',NULL,'9999999','2224560987', 1);
GO


--Impactor Test Type

USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorTestType]    Script Date: 8/3/2024 4:11:33 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorTestType]    Script Date: 8/3/2024 4:12:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 3, 2024
-- Description:	A procedure to get a Impactor Test Type Record
-- =============================================
CREATE PROCEDURE [dbo].[GetImpactorTestType] 
	
	@ImpactorTestTypeId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ImpactorTestTypeId], [TestName], [Description]
	FROM [dbo].[ImpactorTestType]
	WHERE [ImpactorTestTypeId] = @ImpactorTestTypeId
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetAllImpactorTestTypes]    Script Date: 8/3/2024 4:14:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 3, 2024
-- Description:	A procedure to get all of the Impactor Test Types
-- =============================================
CREATE PROCEDURE [dbo].[GetAllImpactorTestTypes]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   	SELECT [ImpactorTestTypeId], [TestName], [Description]
	FROM [dbo].[ImpactorTestType]
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorTestType]    Script Date: 8/3/2024 4:18:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 3, 2024
-- Description:	A procedure to insert an Impactor Test Type
-- =============================================
CREATE PROCEDURE [dbo].[InsertImpactorTestType]
	
	@TestName varchar(50),
	@Description varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[ImpactorTestType] ([TestName], [Description])
	                                 VALUES (@TestName, @Description)
	SELECT @@IDENTITY
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[usp_UpdateImpactorTestType]    Script Date: 8/3/2024 4:22:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 3, 2024
-- Description:	A procedure to update an Impactor Test Type record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateImpactorTestType]
	
	@ImpactorTestTypeId bigint,
	@TestName varchar(50),
	@Description varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[ImpactorTestType] SET
			[TestName] = @TestName,
			[Description] = @Description
	WHERE [ImpactorTestTypeId] = @ImpactorTestTypeId
END
GO

USE [Impactor]
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

--Impactor Type

USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorType]    Script Date: 8/23/2024 1:25:49 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorType]    Script Date: 8/23/2024 2:12:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: August 9, 2024
-- Description:	A procedure to get an Impactor Type Record
-- =============================================
CREATE PROCEDURE [dbo].[GetImpactorType]
	
	@ImpactorTypeId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT [ImpactorTypeId], [ImpactorTestTypeId], [SerialNumber], [Owner]
	FROM [dbo].[ImpactorType]
	WHERE [ImpactorTypeId] = @ImpactorTypeId
END
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetAllImpactorTypes]    Script Date: 8/23/2024 2:11:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: August 9, 2024
-- Description:	A procedure to Get All of the Imnpactor Type Records
-- =============================================
CREATE PROCEDURE [dbo].[GetAllImpactorTypes] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [ImpactorTypeId], [ImpactorTestTypeId], [SerialNumber], [Owner]
	FROM [dbo].[ImpactorType]
	
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorType]    Script Date: 8/23/2024 2:15:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: August 9, 2024
-- Description:	A procedure to Insert an Impactor Type Record
-- =============================================
CREATE PROCEDURE [dbo].[InsertImpactorType]
	
	@ImpactorTestTypeId bigint,
	@SerialNumber varchar(50),
	@Owner varchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[ImpactorType] ([ImpactorTestTypeId], [SerialNumber], [Owner])
	                             VALUES (@ImpactorTestTypeId, @SerialNumber, @Owner)
	SELECT @@IDENTITY
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateImpactorType]    Script Date: 8/23/2024 2:29:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: August 9, 2024
-- Description:	A procedure to update an ImpactorType Record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateImpactorType]
	
	@ImpactorTypeId bigint,
	@ImpactorTestTypeId bigint,
    @SerialNumber varchar(50),
	@Owner varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[ImpactorType] SET
			[ImpactorTestTypeId]= @ImpactorTestTypeId,
		    [SerialNumber] = @SerialNumber,
			[Owner] = @Owner
	WHERE [ImpactorTypeId] = @ImpactorTypeId

END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorTypeForATestType]    Script Date: 8/23/2024 3:02:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 23, 2024
-- Description:	A procedure to get the Impactor Types for a specific Impactor Test Type
-- =============================================
CREATE PROCEDURE [dbo].[GetImpactorTypeForATestType]
	
	@ImpactorTestTypeId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT [ImpactorTypeId], [ImpactorTestTypeId], [SerialNumber], [Owner]
	FROM [dbo].[ImpactorType]
	WHERE [ImpactorTestTypeId] = @ImpactorTestTypeId
END
GO

USE [Impactor]
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


--Protocol
USE [Impactor]
GO

/****** Object:  Table [dbo].[Protocol]    Script Date: 9/16/2024 9:19:02 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetRecordforProtocolAndImpatcorType]    Script Date: 9/16/2024 2:41:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 24 2024
-- Description:	A procedure to get the record for a Protocol and Impactor Type
-- =============================================
CREATE PROCEDURE [dbo].[GetRecordforProtocolAndImpatcorType] 
	
	@ImpactorTypeId bigint,
	@ProtocolName varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [ProtocolId], [ImpactorTypeId], [Name], [ImpactorMass], [TargetingMethod], [NormalImpactSpeed],[NormalImpactAngle]
	FROM [dbo].[Protocol]
	WHERE [ImpactorTypeId] = @ImpactorTypeId
	    AND [Name] = @ProtocolName
END
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetProtocol]    Script Date: 9/16/2024 9:19:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 24, 2024
-- Description:	A procedure to get a Protocol Record
-- =============================================
CREATE PROCEDURE [dbo].[GetProtocol] 
	
	@ProtocolId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT [ProtocolId], [ImpactorTypeId], [Name], [ImpactorMass], [TargetingMethod], [NormalImpactSpeed], [NormalImpactAngle]
	FROM [dbo].[Protocol] 
	WHERE [ProtocolId] = @ProtocolId
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertProtocol]    Script Date: 9/16/2024 9:20:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 24, 2024
-- Description:	A procedure toInsert a Protocol
-- =============================================
CREATE PROCEDURE [dbo].[InsertProtocol] 
	
	@ImpactorTypeId bigint,
	@Name varchar(50),
	@TargetingMethod VARCHAR(50),
	@ImpactorMass decimal (5,2),
	@NormalImpactSpeed decimal (5,2),
	@NormalImpactAngle int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[Protocol] ([ImpactorTypeId], [Name], [ImpactorMass], [TargetingMethod], [NormalImpactSpeed], [NormalImpactAngle])
	                      VALUES (@ImpactorTypeId, @Name, @ImpactorMass, @TargetingMethod, @NormalImpactSpeed, @NormalImpactAngle)
	SELECT @@IDENTITY
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateProtocol]    Script Date: 9/16/2024 9:20:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 24, 2024
-- Description:	A Procedure to Update a Protocol Record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateProtocol]
	
	@ProtocolId bigint,
    @ImpactorTypeId bigint,
	@Name varchar(50),
	@ImpactorMass decimal(5,2),
	@TargetingMethod varchar(50),
	@NormalImpactSpeed decimal(5,2),
	@NormalImpactAngle int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[Protocol] SET
		[ImpactorTypeId] = @ImpactorTypeId,
	    [Name] = @Name,
		[ImpactorMass] = @ImpactorMass,
		[TargetingMethod] = @TargetingMethod,
        [NormalImpactSpeed] = @NormalImpactSpeed,
		[NormalImpactAngle] = @NormalImpactAngle
	WHERE [ProtocolId] = @ProtocolId
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetAllProtocols]    Script Date: 9/16/2024 11:52:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: September 16, 2024
-- Description:	A procedure to get all of the Protocols
-- =============================================
CREATE PROCEDURE [dbo].[GetAllProtocols]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ProtocolId], [ImpactorTypeId], [Name], [ImpactorMass],[TargetingMethod], [NormalImpactSpeed],[NormalImpactAngle]
	FROM [dbo].[Protocol]
END
GO

USE [Impactor]
INSERT INTO Protocol ([ImpactorTypeId], [Name], [ImpactorMass], [TargetingMethod], [NormalImpactSpeed], [NormalImpactAngle])
				VALUES
				(1,'EuroNCAP',	4.50,'Aiming',	11.10,	65),
				(1,'GTR',	4.50,'PoFC',	9.70,	65),
				(2,'EuroNCAP',	3.50,'Aiming',	11.10,	50),
				(2,'GTR',	3.50,'PoFC',	9.70,	50);
GO








