USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorLauncher]    Script Date: 8/9/2025 12:51:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorLauncher](
	[IdLauncher] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_ImpactorLauncher] PRIMARY KEY CLUSTERED 
(
	[IdLauncher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertLauncher]    Script Date: 8/9/2025 12:52:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 9, 2025
-- Description:	A procedure to insert a Launcher Record
-- =============================================
CREATE PROCEDURE [dbo].[InsertLauncher]
	
	@Name varchar(50),
    @Active bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[ImpactorLauncher] ([Name], [Active])
								  VALUES ( @Name, @Active)
	SELECT @@IDENTITY
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateLauncher]    Script Date: 8/23/2025 4:00:16 PM ******/
DROP PROCEDURE [dbo].[UpdateLauncher]
GO

/****** Object:  StoredProcedure [dbo].[UpdateLauncher]    Script Date: 8/23/2025 4:00:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 9, 2025
-- Description:	A procedure to update a Launcher record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateLauncher]
	
	@LauncherId bigint,
	@Name varchar(50),
	@Active bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	UPDATE [dbo].[ImpactorLauncher] SET
		[Name]=@Name,
		[Active] = @Active
	WHERE [LauncherId] = @LauncherId
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetLauncher]    Script Date: 8/23/2025 4:00:37 PM ******/
DROP PROCEDURE [dbo].[GetLauncher]
GO

/****** Object:  StoredProcedure [dbo].[GetLauncher]    Script Date: 8/23/2025 4:00:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 9, 2025
-- Description:	A procedure to get a ;auncher record
-- =============================================
CREATE PROCEDURE [dbo].[GetLauncher]
	
	@LauncherId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [LauncherId], [Name], [Active]
	FROM [dbo].[ImpactorLauncher]
	WHERE [LauncherId] = @LauncherId
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetAllLaunchers]    Script Date: 8/23/2025 4:02:04 PM ******/
DROP PROCEDURE [dbo].[GetAllLaunchers]
GO

/****** Object:  StoredProcedure [dbo].[GetAllLaunchers]    Script Date: 8/23/2025 4:02:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 9, 2025
-- Description:	A procedure to get all launchers
-- =============================================
CREATE PROCEDURE [dbo].[GetAllLaunchers]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [LauncherId], [Name], [Active]
	FROM [dbo].[ImpactorLauncher]
END
GO


/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Impactor Test ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorTest]    Script Date: 8/9/2025 2:04:40 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImpactorTest]') AND type in (N'U'))
DROP TABLE [dbo].[ImpactorTest]
GO

/****** Object:  Table [dbo].[ImpactorTest]    Script Date: 8/9/2025 2:04:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorTest](
	[ImpactorTestId] [bigint] IDENTITY(1,1) NOT NULL,
	[TestRunNumber] [varchar](50) NULL,
	[LauncherId] [bigint] NULL,
	[RunTime] [datetime] NULL,
	[CustomerId] [bigint] NULL,
	[SpecimenId] [bigint] NULL,
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

/****** Object:  StoredProcedure [dbo].[GetImpactorTest]    Script Date: 8/23/2025 4:07:56 PM ******/
DROP PROCEDURE [dbo].[GetImpactorTest]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorTest]    Script Date: 8/23/2025 4:07:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Don Sniezak
-- Create date: July 22, 2024
-- Update Date: January 2, 2025 - cahged specimen to specimenId
-- Update Date: August 9, 2025 - Add Launcher
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
	SELECT [ImpactorTestId], [TestRunNumber], [LauncherId], [RunTime], [CustomerId], [SpecimenId], [Engineer], [Operator], [TestTypeId], [ProtocolId], [Notes]
	FROM [dbo].[ImpactorTest]
	WHERE [ImpactorTestId] = @ImpactorTestId
END
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetAllImpactorTests]    Script Date: 8/23/2025 4:06:38 PM ******/
DROP PROCEDURE [dbo].[GetAllImpactorTests]
GO

/****** Object:  StoredProcedure [dbo].[GetAllImpactorTests]    Script Date: 8/23/2025 4:06:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Don Sniezak
-- Create date: August 3, 2024
-- Description:A procedure to get All of the Impactor Tests
-- Update Date: August 9, 2025 - Add Launcher
-- =============================================
CREATE PROCEDURE [dbo].[GetAllImpactorTests]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT [ImpactorTestId], [TestRunNumber],[LauncherId], [RunTime], [CustomerId], [SpecimenId], [Engineer], [Operator], [TestTypeId], [ProtocolId], [Notes]
   FROM [dbo].[ImpactorTest]
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorTest]    Script Date: 8/23/2025 4:23:30 PM ******/
DROP PROCEDURE [dbo].[InsertImpactorTest]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorTest]    Script Date: 8/23/2025 4:23:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Don Sniezak
-- Create date: July 22, 2024
-- Update Date: Jamuary 2, 2025 - changed Specimen to SpecimentId and made it bigint
-- Update Date: August 9, 2025 - Add Launcher
-- Description:	A procedure to insert a record into the Impactor Test Table
-- =============================================
CREATE PROCEDURE [dbo].[InsertImpactorTest]
	
	@TestRunNumber varchar(50),
	@LauncherId bigint,
	@RunTime datetime,
	@CustomerId bigint,
	@SpecimenId bigint,
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

    INSERT INTO [dbo].[ImpactorTest] ([TestRunNumber], [LauncherId], [RunTime], [CustomerId],[SpecimenId], [Engineer], [Operator], [TestTypeId], [ProtocolId], [Notes])
	                             VALUES (@TestRunNumber, @LauncherId, @RunTime, @CustomerId, @SpecimenId, @Engineer, @Operator,@TestTypeId, @ProtocolId, @Notes)
	SELECT @@IDENTITY
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateLauncher]    Script Date: 8/23/2025 4:10:12 PM ******/
DROP PROCEDURE [dbo].[UpdateLauncher]
GO

/****** Object:  StoredProcedure [dbo].[UpdateLauncher]    Script Date: 8/23/2025 4:10:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 9, 2025
-- Description:	A procedure to update a Launcher record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateLauncher]
	
	@LauncherId bigint,
	@Name varchar(50),
	@Active bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	UPDATE [dbo].[ImpactorLauncher] SET
		[Name] = @Name,
		[Active] = @Active
	WHERE [LauncherId] = @LauncherId
END
GO


/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Parameters ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorParameters]    Script Date: 8/31/2025 11:10:36 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImpactorParameters]') AND type in (N'U'))
DROP TABLE [dbo].[ImpactorParameters]
GO

/****** Object:  Table [dbo].[ImpactorParameters]    Script Date: 8/31/2025 11:10:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorParameters](
	[ImpactorParametersId] [bigint] IDENTITY(1,1) NOT NULL,
	[ImpactorTestId] [bigint] NULL,
	[ImpactorTypeId] [bigint] NULL,
	[LauncherId] [bigint] NULL,
	[Temperature] [decimal](5, 2) NULL,
	[Humidity] [decimal](5, 2) NULL,
	[Trigger1] [int] NULL,
	[Trigger2] [int] NULL,
	[ASCMaxSpeed] [decimal](5, 3) NULL,
	[SetSpeed] [decimal](5, 3) NULL,
	[ParmsId] [bigint] NULL,
	[Notes] [varchar](500) NULL,
	[FirePressure] [decimal](5, 1) NULL,
	[CylinderSpeed] [decimal](5, 3) NULL,
	[MeasuredSpeed] [decimal](5, 3) NULL,
	[WithOutImpactorSetPoint] [decimal](5, 3) NULL,
	[AccumulatorTemperature] [decimal](5, 2) NULL,
	[TankTemperature] [decimal](5, 2) NULL,
	[Airbag1] [int] NULL,
	[Airbag2] [int] NULL,
	[Airbag3] [int] NULL,
	[HeadImpactTime] [int] NULL,
	[DryFires] [int] NULL,
 CONSTRAINT [PK_ImpactorParameters] PRIMARY KEY CLUSTERED 
(
	[ImpactorParametersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorParameters]    Script Date: 8/31/2025 11:11:54 AM ******/
DROP PROCEDURE [dbo].[GetImpactorParameters]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorParameters]    Script Date: 8/31/2025 11:11:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Don Sniezak
-- Create date: July 23, 2024
-- Update Date: December 26, 2024 - Added Dry Fires
-- Update Date: August 17, 2025 - Added ASCMaxSpeed and Set Speed
-- Update Date: August 23, 2025 - Added LauncherId
-- Update Date: August 31, 2025 - Added Head Impact Time
-- Description:	A procedure to get an Impactor Parameter Record
-- =============================================
CREATE PROCEDURE [dbo].[GetImpactorParameters]
	
	@ImpactorParametersId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  	SELECT [ImpactorParametersId], [ImpactorTestId], [ImpactorTypeId], [LauncherId], [Temperature], [Humidity], [Trigger1], [Trigger2], 
	      [ASCMaxSpeed], [SetSpeed], [Notes], [FirePressure], [CylinderSpeed], [MeasuredSpeed], [WithOutImpactorSetPoint], 
		  [AccumulatorTemperature], [TankTemperature], [Airbag1], [Airbag2], [Airbag3], [HeadImpactTime], [DryFires]
    FROM [dbo].[ImpactorParameters]
	WHERE [ImpactorParametersId] = @ImpactorParametersId
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorParametersForAnImpactorTest]    Script Date: 8/31/2025 11:13:32 AM ******/
DROP PROCEDURE [dbo].[GetImpactorParametersForAnImpactorTest]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorParametersForAnImpactorTest]    Script Date: 8/31/2025 11:13:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Don Sniezak
-- Create date: August 10, 2024
-- Update Date: December 26, 2024 - Added Dry Fires
-- Update Date: August 17, 2025 - Added ASCMaxSpeed and Set Speed
-- Update Date: August 23, 2025 - Add LauncherId
-- Update Date: Aigist 31, 2025 - Added Head Impact Time
-- Description:	A procedure to get the Impactor Parameters for an Impactor Test
-- =============================================
CREATE PROCEDURE [dbo].[GetImpactorParametersForAnImpactorTest] 
	@ImpactorTestId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  	SELECT [ImpactorParametersId], [ImpactorTestId], [ImpactorTypeId], [LauncherId], [Temperature], [Humidity], [Trigger1], [Trigger2], 
	       [ASCMaxSpeed],[SetSpeed], [Notes], [FirePressure], [CylinderSpeed], [MeasuredSpeed], [WithOutImpactorSetPoint],
		   [AccumulatorTemperature], [TankTemperature], [Airbag1], [Airbag2], [Airbag3], [HeadImpactTime], [DryFires]
    FROM [dbo].[ImpactorParameters]
	WHERE [ImpactorTestId] = @ImpactorTestId
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorParameter]    Script Date: 8/31/2025 11:16:07 AM ******/
DROP PROCEDURE [dbo].[InsertImpactorParameter]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorParameter]    Script Date: 8/31/2025 11:16:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: August 5, 2024
-- Update Date: December 26, 2024 - Added Dry Fires
-- Update Date: December 28, 2024 - Changed Speed to decimal
-- Update Date: August 17, 2025 - Added ASCMaxSpeed and Set Speed
-- Update Date: August 23, 2025 - Added LauncherId
-- Update Date: August 31, 2025 - Added Head Impact Time
-- Description:	A procedure to Insert an Impactor Parameter Record
-- =============================================
CREATE PROCEDURE [dbo].[InsertImpactorParameter] 
	
	@ImpactorTestId bigint,
	@ImpactorTypeId bigint,
	@LauncherId bigint,
	@Temperature decimal(5,2),
	@Humidity decimal (5,2),
	@Trigger1 int,
	@Trigger2 int,
	@ASCMaxSpeed decimal (5,3),
	@SetSpeed decimal (5,3),
	@Notes varchar(500),
	@FirePressure decimal(5,1),
	@CylinderSpeed decimal(5,3),
	@MeasuredSpeed decimal(5,3),
	@WithOutImpactorSetPoint decimal(5,3),
	@AccumulatorTemperature decimal(5,2),
	@TankTemperature decimal(5,2),
	@Airbag1 int,
	@Airbag2 int,
	@Airbag3 int,
	@HeadImpactTime int,
	@DryFires int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[ImpactorParameters] ([ImpactorTestId], [ImpactorTypeId],[LauncherId], [Temperature], [Humidity], [ASCMaxSpeed],[SetSpeed], 
											[Trigger1], [Trigger2], [Notes], [FirePressure], [CylinderSpeed], [MeasuredSpeed],
											[WithOutImpactorSetPoint], [AccumulatorTemperature], [TankTemperature], [Airbag1], [Airbag2], [Airbag3], [HeadImpactTime], [DryFires] )
									   VALUES (@ImpactorTestId, @ImpactorTypeId, @LauncherId, @Temperature, @Humidity, @ASCMaxSpeed, @SetSpeed,
											   @Trigger1, @Trigger2, @Notes, @FirePressure, @CylinderSpeed, @MeasuredSpeed,  
											   @WithOutImpactorSetPoint, @AccumulatorTemperature, @TankTemperature, @Airbag1, @Airbag2, @Airbag3, @HeadImpactTime, @DryFires)
	 SELECT @@IDENTITY
END
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateImpactorParameter]    Script Date: 8/31/2025 11:18:18 AM ******/
DROP PROCEDURE [dbo].[UpdateImpactorParameter]
GO

/****** Object:  StoredProcedure [dbo].[UpdateImpactorParameter]    Script Date: 8/31/2025 11:18:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Don Sniezak
-- Create date: August 5, 2024
-- Update Date: December 26, 2024 - Added Dry Fires
-- Update Date: December 28, 2024 - Changed Speed to decimal
-- Update Date: August 17, 2025 - Added ASCMaxSpeed and Set Speed
-- Update Date: August 23, 2025 - Added LauncherId
-- Update Date: August 31, 2025 - Added Head Impact time
-- Description:	A procedure to Update an Impactor Parameter Record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateImpactorParameter]
	
	@ImpactorParametersId bigint,
	@ImpactorTestId bigint,
	@ImpactorTypeId bigint,
	@LauncherId bigint,
	@Temperature decimal(5,2),
	@Humidity decimal (5,2),
	@Trigger1 int,
	@Trigger2 int,
	@ASCMaxSpeed decimal (5,3),
	@SetSpeed decimal (5,3),
	@Notes varchar(500),
	@FirePressure decimal(5,1),
	@CylinderSpeed decimal(5,3),
	@MeasuredSpeed decimal(5,3),
	@WithOutImpactorSetPoint decimal(5,3),
	@AccumulatorTemperature decimal(5,2),
	@TankTemperature decimal(5,2),
	@Airbag1 int,
	@Airbag2 int,
	@Airbag3 int,
	@HeadImpactTime int,
	@DryFires int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[ImpactorParameters] SET
			[ImpactorTestId] = @ImpactorTestId,
			[ImpactorTypeId] = @ImpactorTypeId,
			[LauncherId] = @LauncherId,
			[Temperature] = @Temperature,
			[Humidity] = @Humidity,
			[Trigger1] = @Trigger1,
			[Trigger2] = @Trigger2,
			[ASCMaxSpeed] = @ASCMaxSpeed,
			[SetSpeed] = @SetSpeed,
			[Notes]= @Notes,
			[FirePressure] = @FirePressure,
			[CylinderSpeed] = @CylinderSpeed,
			[MeasuredSpeed] = @MeasuredSpeed,
			[WithOutImpactorSetPoint] = @WithOutImpactorSetPoint,
			[AccumulatorTemperature] = @AccumulatorTemperature,
			[TankTemperature] = @TankTemperature,
			[Airbag1] = @Airbag1,
			[Airbag2] = @Airbag2,
			[Airbag3] = @Airbag3,
			[HeadImpactTime] = @HeadImpactTime,
			[DryFires] = @DryFires
    WHERE [ImpactorParametersId] = @ImpactorParametersId
END
GO

/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Vehicle Damage ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorVehicleDamage]    Script Date: 8/29/2025 3:19:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorVehicleDamage](
	[VehicleDamageId] [bigint] IDENTITY(1,1) NOT NULL,
	[TestRunId] [bigint] NULL,
	[VehicleDamage] [varchar](500) NULL,
 CONSTRAINT [PK_ImpactorVehicleDamage] PRIMARY KEY CLUSTERED 
(
	[VehicleDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetVehicleDamageRecord]    Script Date: 8/29/2025 3:23:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 29, 2025
-- Description:	A procedure to get a Vehicle Damage Record
-- =============================================
CREATE PROCEDURE [dbo].[GetVehicleDamageRecord]
	
	@TestRunId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT [VehicleDamageId], [TestRunId], [VehicleDamage]
	FROM [dbo].[ImpactorVehicleDamage]
	WHERE [TestRunId] = @TestRunId

END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertVehicleDamageRecord]    Script Date: 8/29/2025 3:27:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 29, 2025
-- Description:	A procedure to insert a Vehicle Damage Record
-- =============================================
CREATE PROCEDURE [dbo].[InsertVehicleDamageRecord]
	
	@TestRunId bigint,
	@VehicleDamage varchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[ImpactorVehicleDamage] ([TestRunId], [VehicleDamage])
	                                   VALUES (@TestRunId, @VehicleDamage)
	SELECT @@IDENTITY

END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateVehicleDamageRecord]    Script Date: 8/29/2025 3:42:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 29, 2025
-- Description:	A procedure to update a Vehicle Damage record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateVehicleDamageRecord]
	
	@VehicleDamageId bigint,
	@TestRunId bigint,
	@VehicleDamage varchar (500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[ImpactorVehicleDamage] SET
		[VehicleDamage] = @VehicleDamage,
		[TestRunId] = @TestRunId
	WHERE [VehicleDamageId] = @VehicleDamageId

END
GO

