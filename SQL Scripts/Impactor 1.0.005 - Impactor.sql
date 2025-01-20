USE [Impactor]
GO

/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~ Impactor Parameters
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorParameters]    Script Date: 1/5/2025 2:55:36 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImpactorParameters]') AND type in (N'U'))
DROP TABLE [dbo].[ImpactorParameters]
GO

/****** Object:  Table [dbo].[ImpactorParameters]    Script Date: 1/5/2025 2:55:36 PM ******/
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
	[CylinderSpeed] [decimal](5, 3) NULL,
	[MeasuredSpeed] [decimal](5, 3) NULL,
	[WithOutImpactorSetPoint] [decimal](5, 3) NULL,
	[AccumulatorTemperature] [decimal](5, 2) NULL,
	[TankTemperature] [decimal](5, 2) NULL,
	[Airbag1] [int] NULL,
	[Airbag2] [int] NULL,
	[Airbag3] [int] NULL,
	[DryFires] [int] NULL,
 CONSTRAINT [PK_ImpactorParameters] PRIMARY KEY CLUSTERED 
(
	[ImpactorParametersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorParameters]    Script Date: 1/5/2025 3:32:01 PM ******/
DROP PROCEDURE [dbo].[GetImpactorParameters]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorParameters]    Script Date: 1/5/2025 3:32:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Don Sniezak
-- Create date: July 23, 2024
-- Update Date: December 26, 2024 - Added Dry Fires
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
	       [Notes], [FirePressure], [CylinderSpeed], [MeasuredSpeed], [WithOutImpactorSetPoint], [AccumulatorTemperature],
		   [TankTemperature], [Airbag1], [Airbag2], [Airbag3], [DryFires]
    FROM [dbo].[ImpactorParameters]
	WHERE [ImpactorParametersId] = @ImpactorParametersId
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorParametersForAnImpactorTest]    Script Date: 1/5/2025 3:31:11 PM ******/
DROP PROCEDURE [dbo].[GetImpactorParametersForAnImpactorTest]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorParametersForAnImpactorTest]    Script Date: 1/5/2025 3:31:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: August 10, 2024
-- Update Date: December 26, 2024 - Added Dry Fires
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
	       [Notes], [FirePressure], [CylinderSpeed], [MeasuredSpeed], [WithOutImpactorSetPoint],[AccumulatorTemperature],
		   [TankTemperature], [Airbag1], [Airbag2], [Airbag3], [DryFires]
    FROM [dbo].[ImpactorParameters]
	WHERE [ImpactorTestId] = @ImpactorTestId
END
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorParameter]    Script Date: 1/5/2025 3:00:34 PM ******/
DROP PROCEDURE [dbo].[InsertImpactorParameter]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorParameter]    Script Date: 1/5/2025 3:00:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: August 5, 2024
-- Update Date: December 26, 2024 - Added Dry Fires
-- Update Date: December 28, 2024 - Changed Speed to decimal
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
	@CylinderSpeed decimal(5,3),
	@MeasuredSpeed decimal(5,3),
	@WithOutImpactorSetPoint decimal(5,3),
	@AccumulatorTemperature decimal(5,2),
	@TankTemperature decimal(5,2),
	@Airbag1 int,
	@Airbag2 int,
	@Airbag3 int,
	@DryFires int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[ImpactorParameters] ([ImpactorTestId], [ImpactorTypeId], [Temperature], [Humidity],
											   [Trigger1], [Trigger2], [Notes], [FirePressure], [CylinderSpeed], [MeasuredSpeed],
											   [WithOutImpactorSetPoint], [AccumulatorTemperature], [TankTemperature], [Airbag1], [Airbag2], [Airbag3], [DryFires] )
									   VALUES (@ImpactorTestId, @ImpactorTypeId, @Temperature, @Humidity,
											   @Trigger1, @Trigger2, @Notes, @FirePressure, @CylinderSpeed, @MeasuredSpeed,  
											   @WithOutImpactorSetPoint, @AccumulatorTemperature, @TankTemperature, @Airbag1, @Airbag2, @Airbag3, @DryFires)
	 SELECT @@IDENTITY
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateImpactorParameter]    Script Date: 1/5/2025 3:02:08 PM ******/
DROP PROCEDURE [dbo].[UpdateImpactorParameter]
GO

/****** Object:  StoredProcedure [dbo].[UpdateImpactorParameter]    Script Date: 1/5/2025 3:02:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: August 5, 2024
-- Update Date: December 26, 2024 - Added Dry Fires
-- Update Date: December 28, 2024 - Changed Speed to decimal
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
	@CylinderSpeed decimal(5,3),
	@MeasuredSpeed decimal(5,3),
	@WithOutImpactorSetPoint decimal(5,3),
	@AccumulatorTemperature decimal(5,2),
	@TankTemperature decimal(5,2),
	@Airbag1 int,
	@Airbag2 int,
	@Airbag3 int,
	@DryFires int
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
			[AccumulatorTemperature] = @AccumulatorTemperature,
			[TankTemperature] = @TankTemperature,
			[Airbag1] = @Airbag1,
			[Airbag2] = @Airbag2,
			[Airbag3] = @Airbag3,
			[DryFires] = @DryFires
    WHERE [ImpactorParametersId] = @ImpactorParametersId
END
GO


/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~ Impactor Axis
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorAxis]    Script Date: 12/28/2024 10:18:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImpactorAxis]') AND type in (N'U'))
DROP TABLE [dbo].[ImpactorAxis]
GO

/****** Object:  Table [dbo].[ImpactorAxis]    Script Date: 12/28/2024 10:18:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorAxis](
	[ImpactorAxisId] [bigint] IDENTITY(1,1) NOT NULL,
	[ImpactorTestId] [bigint] NOT NULL,
	[ImpactorParameterId] [bigint] NULL,
	[SetName] [varchar](50) NULL,
	[XAxis] [decimal](4, 1) NULL,
	[YAxis] [decimal](4, 1) NULL,
	[ZAxis] [decimal](4, 1) NULL,
	[Alpha] [decimal](3, 1) NULL,
 CONSTRAINT [PK_ImpactorAxis] PRIMARY KEY CLUSTERED 
(
	[ImpactorAxisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorAxis]    Script Date: 12/28/2024 10:21:23 AM ******/
DROP PROCEDURE [dbo].[InsertImpactorAxis]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorAxis]    Script Date: 12/28/2024 10:21:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: July 27, 2024
-- Update Date: December 28, 2024 - Changed X,Y,Z to Decimal, changed Alpha to 3,1
-- Description: A procedure to insert an Impactor Axis Record
-- =============================================
CREATE PROCEDURE [dbo].[InsertImpactorAxis]
	
	@ImpactorTestId bigint,
    @ImpactorParameterId bigint,
	@SetName varchar(50),
	@XAxis decimal(4,1),
	@YAxis decimal(4,1),
	@ZAxis decimal(4,1),
	@Alpha decimal(3,1)
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

/****** Object:  StoredProcedure [dbo].[UpdateImpactorAxisRecord]    Script Date: 12/28/2024 10:22:45 AM ******/
DROP PROCEDURE [dbo].[UpdateImpactorAxisRecord]
GO

/****** Object:  StoredProcedure [dbo].[UpdateImpactorAxisRecord]    Script Date: 12/28/2024 10:22:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: July 27, 2024
-- Update Date: December 28, 2024 - Changed X,Y,Z to Decimal, changed Alpha to 3,1
-- Description:	A procedure to update an Impactor Axis Record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateImpactorAxisRecord] 
	
	@ImpactorAxisId bigint,
	@ImpactorTestId bigint,
    @ImpactorParameterId bigint,
	@SetName varchar(50),
	@XAxis decimal(4,1),
	@YAxis decimal(4,1),
	@ZAxis decimal(4,1),
	@Alpha decimal(3,1)
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

/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~~~~~~~ Specimen 
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

USE [Impactor]
GO

/****** Object:  Table [dbo].[Specimen]    Script Date: 1/3/2025 3:01:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Specimen]') AND type in (N'U'))
DROP TABLE [dbo].[Specimen]
GO

/****** Object:  Table [dbo].[Specimen]    Script Date: 1/3/2025 3:01:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Specimen](
	[SpecimenId] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NULL,
	[Year] [int] NULL,
	[Make] [varchar](50) NULL,
	[Model] [varchar](50) NULL,
	[VIN] [varchar](75) NULL,
	[Mass] [decimal](5, 1) NULL,
	[Notes] [varchar](max) NULL,
 CONSTRAINT [PK_Specimen] PRIMARY KEY CLUSTERED 
(
	[SpecimenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetASpecimen]    Script Date: 1/3/2025 3:05:35 PM ******/
DROP PROCEDURE [dbo].[GetASpecimen]
GO

/****** Object:  StoredProcedure [dbo].[GetASpecimen]    Script Date: 1/3/2025 3:05:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: January 2, 2025
-- Description:	A procedure to return a specimen record
-- =============================================
CREATE PROCEDURE [dbo].[GetASpecimen]
	
	@SpecimenId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT [SpecimenId], [CustomerId], [CompanyName], [Year], [Make], [Model], [VIN], [Mass], [Notes]
	FROM [dbo].[Specimen] INNER JOIN
         [dbo].[ImpactorClient] ON [dbo].[ImpactorClient].ImpactorClientId = [dbo].[Specimen].CustomerId
	WHERE [SpecimenId] = @SpecimenId
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetAllSpecimens]    Script Date: 1/3/2025 3:04:50 PM ******/
DROP PROCEDURE [dbo].[GetAllSpecimens]
GO

/****** Object:  StoredProcedure [dbo].[GetAllSpecimens]    Script Date: 1/3/2025 3:04:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: January 2, 2025
-- Description:	A procedure to return all of the specimens in the specimen table
-- =============================================
CREATE PROCEDURE [dbo].[GetAllSpecimens]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT [SpecimenId], [CustomerId], [CompanyName], [Year], [Make], [Model], [VIN], [Mass], [Notes]
	FROM [dbo].[Specimen] INNER JOIN
         [dbo].[ImpactorClient] ON [dbo].[ImpactorClient].ImpactorClientId = [dbo].[Specimen].CustomerId
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertASpecimen]    Script Date: 1/3/2025 3:06:44 PM ******/
DROP PROCEDURE [dbo].[InsertASpecimen]
GO

/****** Object:  StoredProcedure [dbo].[InsertASpecimen]    Script Date: 1/3/2025 3:06:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: January 2, 2025
-- Description:	A procedure to insert a specimen record in the specimen database
-- =============================================
CREATE PROCEDURE [dbo].[InsertASpecimen] 
	
	@CustomerId bigint,
	@Year int,
	@Make varchar(50),
	@Model varchar(50),
	@VIN varchar(75),
	@Mass decimal (5,1),
	@Notes varchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[Specimen] ([CustomerId], [Year], [Make], [Model], [VIN], [Mass], [Notes])
						   VALUES(@CustomerId, @Year, @Make, @Model, @VIN, @Mass, @Notes)
	SELECT @@IDENTITY
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateASpecimen]    Script Date: 1/3/2025 3:07:42 PM ******/
DROP PROCEDURE [dbo].[UpdateASpecimen]
GO

/****** Object:  StoredProcedure [dbo].[UpdateASpecimen]    Script Date: 1/3/2025 3:07:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: January 2, 2024
-- Description:	A procedure to update a specimen record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateASpecimen]
	
	@SpecimenId bigint,
	@CustomerId bigint,
	@Year int,
	@Make varchar(50),
	@Model varchar(50),
	@VIN varchar(75),
	@Mass decimal (5,1),
	@Notes varchar(MAX)AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[Specimen] SET
		[CustomerId] = @CustomerId,
		[Year] = @Year,
		[Make] = @Make,
		[Model] = @Model,
		[VIN] = @VIN,
		[Mass] = @Mass,
		[Notes] = @Notes
	WHERE [SpecimenId] = @SpecimenId

END
GO


/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~        Changes to Impactor Test
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorTest]    Script Date: 1/2/2025 4:41:38 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImpactorTest]') AND type in (N'U'))
DROP TABLE [dbo].[ImpactorTest]
GO

/****** Object:  Table [dbo].[ImpactorTest]    Script Date: 1/2/2025 4:41:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorTest](
	[ImpactorTestId] [bigint] IDENTITY(1,1) NOT NULL,
	[TestRunNumber] [varchar](50) NULL,
	[RunTime] [datetime] NULL,
	[CustomerId] [bigint] NULL,
	[SpecimenId] [bigint] NULL,
	[Engineer] [varchar](50) NULL,
	[Operator] [varchar](50) NULL,
	[TestTypeId] [bigint] NULL,
	[ProtocolId] [bigint] NOT NULL,
	[Notes] [varchar](500) NULL,
 CONSTRAINT [PK_ImpactorTest] PRIMARY KEY CLUSTERED 
(
	[ImpactorTestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorTest]    Script Date: 1/2/2025 4:39:04 PM ******/
DROP PROCEDURE [dbo].[InsertImpactorTest]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorTest]    Script Date: 1/2/2025 4:39:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Don Sniezak
-- Create date: July 22, 2024
-- Update Date: Jamuary 2, 2025 - changed Specimen to SpecimentId and mait it bigint
-- Description:	A procedure to insert a record into the Impactor Test Table
-- =============================================
CREATE PROCEDURE [dbo].[InsertImpactorTest]
	
	@TestRunNumber varchar(50),
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

    INSERT INTO [dbo].[ImpactorTest] ([TestRunNumber], [RunTime], [CustomerId],[SpecimenId], [Engineer], [Operator], [TestTypeId], [ProtocolId], [Notes])
	                             VALUES (@TestRunNumber, @RunTime, @CustomerId, @SpecimenId, @Engineer, @Operator,@TestTypeId, @ProtocolId, @Notes)
	SELECT @@IDENTITY
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateImpactorTest]    Script Date: 1/2/2025 4:41:16 PM ******/
DROP PROCEDURE [dbo].[UpdateImpactorTest]
GO

/****** Object:  StoredProcedure [dbo].[UpdateImpactorTest]    Script Date: 1/2/2025 4:41:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Don Sniezak
-- Create date: July 22, 2024
-- Update Date: January 2, 2025 - Changed Specimen to SpecimentId from varcar to bigint
-- Description:	A procedure to update an Impactor Test record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateImpactorTest]
	
	@ImpactorTestId bigint,
	@TestRunNumber varchar(50),
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

    -- Insert statements for procedure here
	UPDATE [dbo].[ImpactorTest] SET
		[TestRunNumber] = @TestRunNumber,
		[RunTime] = @RunTime,
		[CustomerId] = @CustomerId,
		[SpecimenId] = @SpecimenId,
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

/****** Object:  StoredProcedure [dbo].[GetAllImpactorTests]    Script Date: 1/2/2025 4:59:12 PM ******/
DROP PROCEDURE [dbo].[GetAllImpactorTests]
GO

/****** Object:  StoredProcedure [dbo].[GetAllImpactorTests]    Script Date: 1/2/2025 4:59:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Don Sniezak
-- Create date: August 3, 2024
-- Update Date: January 2, 2025 - cahged specimen to specimenId
-- Description:A procedure to get All of the Impactor Tests
-- =============================================
CREATE PROCEDURE [dbo].[GetAllImpactorTests]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT [ImpactorTestId], [TestRunNumber], [RunTime], [CustomerId], [SpecimenId], [Engineer], [Operator], [TestTypeId], [ProtocolId], [Notes]
   FROM [dbo].[ImpactorTest]
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorTest]    Script Date: 1/2/2025 4:59:57 PM ******/
DROP PROCEDURE [dbo].[GetImpactorTest]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorTest]    Script Date: 1/2/2025 4:59:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Don Sniezak
-- Create date: July 22, 2024
-- Update Date: January 2, 2025 - cahged specimen to specimenId
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
	SELECT [ImpactorTestId], [TestRunNumber], [RunTime], [CustomerId], [SpecimenId], [Engineer], [Operator], [TestTypeId], [ProtocolId], [Notes]
	FROM [dbo].[ImpactorTest]
	WHERE [ImpactorTestId] = @ImpactorTestId
END
GO
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/~~~~~~~~~~~~~ Protocol
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertProtocol]    Script Date: 1/13/2025 4:33:54 PM ******/
DROP PROCEDURE [dbo].[InsertProtocol]
GO

/****** Object:  StoredProcedure [dbo].[InsertProtocol]    Script Date: 1/13/2025 4:33:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: August 24, 2024
-- Update date: January 13, 2025 - Impact angle changed to decimak
-- Description:	A procedure toInsert a Protocol
-- =============================================
CREATE PROCEDURE [dbo].[InsertProtocol] 
	
	@ImpactorTypeId bigint,
	@Name varchar(50),
	@TargetingMethod VARCHAR(50),
	@ImpactorMass decimal (5,2),
	@NormalImpactSpeed decimal (5,2),
	@NormalImpactAngle decimal (3,1)
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

/****** Object:  StoredProcedure [dbo].[UpdateProtocol]    Script Date: 1/13/2025 4:36:21 PM ******/
DROP PROCEDURE [dbo].[UpdateProtocol]
GO

/****** Object:  StoredProcedure [dbo].[UpdateProtocol]    Script Date: 1/13/2025 4:36:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: August 24, 2024
-- Update date: January 13, 2025 - changed Impact Angle to decimal
-- Description:	A Procedure to Update a Protocol Record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateProtocol]
	
	@ProtocolId bigint,
    @ImpactorTypeId bigint,
	@Name varchar(50),
	@ImpactorMass decimal(5,2),
	@TargetingMethod varchar(50),
	@NormalImpactSpeed decimal(5,2),
	@NormalImpactAngle decimal (3,1)
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




/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~~~                Tires
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

USE [Impactor]
GO

/****** Object:  Table [dbo].[Tires]    Script Date: 1/4/2025 12:10:08 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tires]') AND type in (N'U'))
DROP TABLE [dbo].[Tires]
GO

/****** Object:  Table [dbo].[Tires]    Script Date: 1/4/2025 12:10:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tires](
	[TiresId] [bigint] IDENTITY(1,1) NOT NULL,
	[ImpactorTestId] [bigint] NULL,
	[SpecimenId] [bigint] NULL,
	[SpecificationFront] [varchar](100) NULL,
	[SpecificationRear] [varchar](100) NULL,
	[PressureFL] [decimal](3, 1) NULL,
	[PressureFR] [decimal](3, 1) NULL,
	[PressureRL] [decimal](3, 1) NULL,
	[PressureRR] [decimal](3, 1) NULL,
	[HeightFL] [decimal](5, 1) NULL,
	[HeightFR] [decimal](5, 1) NULL,
	[HeightRL] [decimal](5, 1) NULL,
	[HeightRR] [decimal](5, 1) NULL,
	[Notes] [varchar](255) NULL,
 CONSTRAINT [PK_Tires] PRIMARY KEY CLUSTERED 
(
	[TiresId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetTiresRecord]    Script Date: 1/4/2025 12:16:49 PM ******/
DROP PROCEDURE [dbo].[GetTiresRecord]
GO

/****** Object:  StoredProcedure [dbo].[GetTiresRecord]    Script Date: 1/4/2025 12:16:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: January 5, 2025
-- Description:	A procedure to retrieve a Tires Record
-- =============================================
CREATE PROCEDURE [dbo].[GetTiresRecord]
	
	@ImpactorTestId bigint, 
	@SpecimenId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT [TiresId], [ImpactorTestId], [SpecimenId],[SpecificationFront], [SpecificationRear],
           [PressureFL], [PressureFR], [PressureRL], [PressureRR],
		   [HeightFL], [HeightFR], [HeightRL], [HeightRR], 
		   [Notes]
	FROM [dbo].[Tires]
	WHERE [SpecimenId] = @SpecimenId
	     AND [ImpactorTestId] = @ImpactorTestId
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertTireRecord]    Script Date: 1/4/2025 12:24:43 PM ******/
DROP PROCEDURE [dbo].[InsertTireRecord]
GO

/****** Object:  StoredProcedure [dbo].[InsertTireRecord]    Script Date: 1/4/2025 12:24:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: January 4, 2025
-- Description:	A procedure to insert a Tires Record
-- =============================================
CREATE PROCEDURE [dbo].[InsertTireRecord] 
	
	@ImpactorTestId bigint,
	@SpecimenId bigint,
	@SpecificationFront varchar(100),
	@SpecificationRear varchar(100),
	@PressureFL decimal (3,1),
	@PressureFR decimal (3,1),
	@PressureRL decimal (3,1),
	@PressureRR decimal (3,1),
	@HeightFL decimal(5,1),
	@HeightFR decimal(5,1),
	@HeightRL decimal(5,1),
	@HeightRR decimal(5,1),
	@Notes varchar(255)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[Tires] ([ImpactorTestId], [SpecimenId], [SpecificationFront], [SpecificationRear], 
	                           [PressureFL], [PressureFR], [PressureRL], [PressureRR], 
							   [HeightFL], [HeightFR], [HeightRL], [HeightRR], 
							   [Notes])
						VALUES (@ImpactorTestId, @SpecimenId, @SpecificationFront, @SpecificationRear, 
						       @PressureFL, @PressureFR, @PressureRL, @PressureRR, 
							   @HeightFL, @HeightFR, @HeightRL, @HeightRR,
							   @Notes)
	SELECT @@IDENTITY

END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateTireRecord]    Script Date: 1/4/2025 12:31:29 PM ******/
DROP PROCEDURE [dbo].[UpdateTireRecord]
GO

/****** Object:  StoredProcedure [dbo].[UpdateTireRecord]    Script Date: 1/4/2025 12:31:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: January 4, 2025
-- Description:	A procedure to update aTire Record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateTireRecord]
	@TiresId bigint,
	@ImpactorTestId bigint,
	@SpecimenId bigint,
	@SpecificationFront varchar(100),
	@SpecificationRear varchar(100),
	@PressureFL decimal (3,1),
	@PressureFR decimal (3,1),
	@PressureRL decimal (3,1),
	@PressureRR decimal (3,1),
	@HeightFL decimal(5,1),
	@HeightFR decimal(5,1),
	@HeightRL decimal(5,1),
	@HeightRR decimal(5,1),
	@Notes varchar(255)AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[Tires] SET
		[ImpactorTestId] = @ImpactorTestId,
		[SpecimenId] = @SpecimenId,
		[SpecificationFront] = @SpecificationFront,
		[SpecificationRear] = @SpecificationRear,
		[PressureFL] = @PressureFL,
		[PressureFR] = @PressureFR,
		[PressureRL] = @PressureRL,
		[PressureRR] = @PressureRR,
		[HeightFL] = @HeightFL,
		[HeightFR] = @HeightFR,
		[HeightRL] = @HeightRL,
		[HeightRR] = @HeightRR,
		[Notes] = @Notes
	WHERE [TiresId] = @TiresId

END
GO

/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/~~~~~~~~~~~~~~~~~~~~~~ Reports
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetReportsTestListByCustomerAndDate]    Script Date: 1/12/2025 1:46:45 PM ******/
DROP PROCEDURE [dbo].[GetReportsTestListByCustomerAndDate]
GO

/****** Object:  StoredProcedure [dbo].[GetReportsTestListByCustomerAndDate]    Script Date: 1/12/2025 1:46:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: January 11, 2025
-- Description:	A procedure to return the list of tests for a specific time and date
-- =============================================
CREATE PROCEDURE [dbo].[GetReportsTestListByCustomerAndDate]
	
	@CustomerId bigint,
	@FromDate datetime,
	@ToDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [TestRunNumber],[TestName],  [Year], [Make], [Model], [VIN], [ImpactorTestId]
FROM [dbo].[ImpactorTest] INNER JOIN
     [dbo].[ImpactorClient] ON [dbo].[ImpactorClient].ImpactorClientId = [dbo].[ImpactorTest].CustomerId INNER JOIN
     [dbo].[Specimen] ON [dbo].[Specimen].SpecimenId = [dbo].[ImpactorTest].SpecimenId INNER JOIN
     [dbo].[ImpactorTestType] ON [dbo].[ImpactorTestType].ImpactorTestTypeId = [dbo].[ImpactorTest].TestTypeId
WHERE [dbo].[ImpactorTest].CustomerId = @CustomerId
      AND [RunTime] BETWEEN @FromDate AND @ToDate
END
GO


