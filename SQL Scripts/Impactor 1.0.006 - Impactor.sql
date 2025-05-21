USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetReportsTestListByCustomerAndDate]    Script Date: 2/15/2025 3:00:08 PM ******/
DROP PROCEDURE [dbo].[GetReportsTestListByCustomerAndDate]
GO

/****** Object:  StoredProcedure [dbo].[GetReportsTestListByCustomerAndDate]    Script Date: 2/15/2025 3:00:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: January 11, 2025
-- Update date: February 15, 2025
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

    SELECT [TestRunNumber],[TestName],[Year], [Make], [Model], [VIN], [ImpactorTestId], [dbo].[ImpactorTest].[SpecimenId]
	FROM [dbo].[ImpactorTest] INNER JOIN
		 [dbo].[ImpactorClient] ON [dbo].[ImpactorClient].ImpactorClientId = [dbo].[ImpactorTest].CustomerId INNER JOIN
		 [dbo].[Specimen] ON [dbo].[Specimen].SpecimenId = [dbo].[ImpactorTest].SpecimenId INNER JOIN
		 [dbo].[ImpactorTestType] ON [dbo].[ImpactorTestType].ImpactorTestTypeId = [dbo].[ImpactorTest].TestTypeId
	WHERE [dbo].[ImpactorTest].CustomerId = @CustomerId
		AND [RunTime] BETWEEN @FromDate AND @ToDate
END
GO


/* Adding Active to the Specimen Table */

USE Impactor
ALTER TABLE [dbo].[Specimen] ADD Active bit;

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetAllSpecimens]    Script Date: 2/14/2025 2:18:44 PM ******/
DROP PROCEDURE [dbo].[GetAllSpecimens]
GO

/****** Object:  StoredProcedure [dbo].[GetAllSpecimens]    Script Date: 2/14/2025 2:18:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: January 2, 2025
-- Update date: February 14, 2025 - Added Active
-- Description:	A procedure to return all of the specimens in the specimen table
-- =============================================
CREATE PROCEDURE [dbo].[GetAllSpecimens]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT [SpecimenId], [CustomerId], [CompanyName], [Year], [Make], [Model], [VIN], [Mass], [Notes], [Active]
	FROM [dbo].[Specimen] INNER JOIN
         [dbo].[ImpactorClient] ON [dbo].[ImpactorClient].ImpactorClientId = [dbo].[Specimen].CustomerId
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetASpecimen]    Script Date: 2/14/2025 2:20:31 PM ******/
DROP PROCEDURE [dbo].[GetASpecimen]
GO

/****** Object:  StoredProcedure [dbo].[GetASpecimen]    Script Date: 2/14/2025 2:20:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: January 2, 2025
-- Update date: February 14, 2025 - Added Active
-- Description:	A procedure to return a specimen record
-- =============================================
CREATE PROCEDURE [dbo].[GetASpecimen]
	
	@SpecimenId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT [SpecimenId], [CustomerId], [CompanyName], [Year], [Make], [Model], [VIN], [Mass], [Notes], [Active]
	FROM [dbo].[Specimen] INNER JOIN
         [dbo].[ImpactorClient] ON [dbo].[ImpactorClient].ImpactorClientId = [dbo].[Specimen].CustomerId
	WHERE [SpecimenId] = @SpecimenId
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertASpecimen]    Script Date: 2/14/2025 2:39:44 PM ******/
DROP PROCEDURE [dbo].[InsertASpecimen]
GO

/****** Object:  StoredProcedure [dbo].[InsertASpecimen]    Script Date: 2/14/2025 2:39:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: January 2, 2025
-- Update date: February 14, 2025
-- Description:	A procedure to insert a specimen record in the specimen database
-- =============================================
CREATE PROCEDURE [dbo].[InsertASpecimen] 
	
	@CustomerId bigint,
	@Year int,
	@Make varchar(50),
	@Model varchar(50),
	@VIN varchar(75),
	@Mass decimal (5,1),
	@Notes varchar(MAX),
	@Active bit NULL = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[Specimen] ([CustomerId], [Year], [Make], [Model], [VIN], [Mass], [Notes], [Active])
						   VALUES(@CustomerId, @Year, @Make, @Model, @VIN, @Mass, @Notes, @Active)
	SELECT @@IDENTITY
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateASpecimen]    Script Date: 2/14/2025 3:03:44 PM ******/
DROP PROCEDURE [dbo].[UpdateASpecimen]
GO

/****** Object:  StoredProcedure [dbo].[UpdateASpecimen]    Script Date: 2/14/2025 3:03:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: January 2, 2024
-- Update date: February 14, 2025
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
	@Notes varchar(MAX),
	@Active bit
	
	AS
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
		[Notes] = @Notes,
		[Active] = @Active
	WHERE [SpecimenId] = @SpecimenId

END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetModelsforCustomer]    Script Date: 2/14/2025 3:19:56 PM ******/
DROP PROCEDURE [dbo].[GetModelsforCustomer]
GO

/****** Object:  StoredProcedure [dbo].[GetModelsforCustomer]    Script Date: 2/14/2025 3:19:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: February 9, 2025
-- Update date: February 14, 2025 - Added Active
-- Description:	A procedure to return all of the modles that belong to a customer
-- =============================================
CREATE PROCEDURE [dbo].[GetModelsforCustomer]
	
	@ImpactorClientId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [SpecimenId], [Model], [Active]
	FROM [dbo].[Specimen]
	WHERE [CustomerId] = @ImpactorClientId
END
GO

/************************Impactor Injury Time ***************************************/
USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorInjuryTime]    Script Date: 3/9/2025 3:10:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorInjuryTime](
	[ImpactorInjuryTimeId] [bigint] IDENTITY(1,1) NOT NULL,
	[ShortName] [varchar](30) NULL,
	[InjuryDefinition] [varchar](50) NULL,
	[Description] [varchar](100) NULL,
	[DefaultUnits] [varchar](10) NULL,
	[MaxValueUsed] [bit] NULL,
	[MaxTimeUsed] [bit] NULL,
	[MinValueUsed] [bit] NULL,
	[MinTimeUsed] [bit] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_InjuryType] PRIMARY KEY CLUSTERED 
(
	[ImpactorInjuryTimeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetAnInjuryTimeRecord]    Script Date: 3/9/2025 3:12:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: February 16, 2025
-- Description:	A procedure to get a InjuryTime Record
-- =============================================
CREATE PROCEDURE [dbo].[GetAnInjuryTimeRecord] 
	
	@InjuryTypeId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT [ImpactorInjuryTimeId], [ShortName], [InjuryDefinition], [Description], [DefaultUnits], [MaxValueUsed], [MaxTimeUsed], [MinValueUsed], [MinTimeUsed], [Status]
	FROM ImpactorInjuryTime
	WHERE [ImpactorInjuryTimeId] = @InjuryTypeId
END
GO


USE [Impactor]
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetAllInjuryTimeRecords]    Script Date: 3/22/2025 4:09:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: February 16, 2025
-- Description:	A procedure to get all of the Injury Time Records
-- =============================================
CREATE PROCEDURE [dbo].[GetAllInjuryTimeRecords] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [ImpactorInjuryTimeId], [ShortName], [InjuryDefinition], [Description], [DefaultUnits], [MaxValueUsed], [MaxTimeUsed], [MinValueUsed], [MinTimeUsed], [Status]
	FROM ImpactorInjuryTime
	WHERE [Status] = 1
END
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertInjuryTimeRecord]    Script Date: 3/9/2025 3:13:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: February 16, 2025
-- Description:	A pricedure to Insert an Injury Time Record
-- =============================================
CREATE PROCEDURE [dbo].[InsertInjuryTimeRecord]
	
	@ShortName varchar(30),
	@InjuryDefinition varchar(50),
	@Description varchar(100),
	@DefaultUnits varchar(10),
	@MaxValueUsed bit,
	@MaxTimeUsed bit,
	@MinValueUsed bit,
	@MinTimeUsed bit,
	@Status bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [ImpactorInjuryTime] ([ShortName], [InjuryDefinition], [Description], [DefaultUnits], [MaxValueUsed], [MaxTimeUsed], [MinValueUsed], [MinTimeUsed], [Status])
							VALUES (@ShortName, @InjuryDefinition, @Description, @DefaultUnits, @MaxValueUsed, @MaxTimeUsed, @MinValueUsed, @MinTimeUsed, @Status)
	select @@IDENTITY
END
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateInjuryTimeRecord]    Script Date: 3/9/2025 3:17:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Don Sniezak
-- Create date: February 16, 2025
-- Description:	A procedure to update an Injury Time Record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateInjuryTimeRecord]
	@ImpactorInjuryTimeId bigint,
	@ShortName varchar(30),
	@InjuryDefinition varchar(50),
	@Description varchar(100),
	@DefaultUnits varchar(10),
	@MaxValueUsed bit,
	@MaxTimeUsed bit,
	@MinValueUsed bit,
	@MinTimeUsed bit,
	@Status bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE ImpactorInjuryTime SET
		[ShortName]= @ShortName,
		[InjuryDefinition] = @InjuryDefinition,
		[Description] = @Description,
		[DefaultUnits] = @DefaultUnits,
		[MaxValueUsed] = @MaxValueUsed,
		[MaxTimeUsed] = @MaxTimeUsed,
		[MinValueUsed] = @MinValueUsed,
		[MinTimeUsed] = @MinTimeUsed,
		[Status]=  @Status
	WHERE [ImpactorInjuryTimeId] = @ImpactorInjuryTimeId

END
GO


/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~~~~~~~~~~~~~ Impactor Injury Data ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorInjuryTimeData]    Script Date: 3/9/2025 3:59:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorInjuryTimeData](
	[ImpactorInjuryTimeDataId] [bigint] IDENTITY(1,1) NOT NULL,
	[TestRunNumber] [varchar](50) NULL,
	[ImpactorInjuryTimeId] [bigint] NULL,
	[MaxValue] [float] NULL,
	[MaxTime] [float] NULL,
	[MinValue] [float] NULL,
	[MinTime] [float] NULL,
	[Units] [varchar](10) NULL,
	[TimeStamp] [datetime] NULL,
	[Notes] [varchar](250) NULL,
 CONSTRAINT [PK_ImpactorInjuryData] PRIMARY KEY CLUSTERED 
(
	[ImpactorInjuryTimeDataId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorInjuryTimeDataForATest]    Script Date: 3/9/2025 4:01:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: March 8, 2025
-- Description:	A procedure to retrieve the set of injury Time data from a run
-- =============================================
CREATE PROCEDURE [dbo].[GetImpactorInjuryTimeDataForATest]
	
	@TestRunNumber varchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT [ImpactorInjuryTimeDataId], [TestRunNumber], [dbo].[ImpactorInjuryTimeData].[ImpactorInjuryTimeId],[ShortName], [MaxValue], [MaxTime], [MinValue], [MinTime], [Units], [TimeStamp], [Notes]
	FROM [dbo].[ImpactorInjuryTimeData] INNER JOIN
		 [dbo].[ImpactorInjuryTime] ON [dbo].[ImpactorInjuryTime].ImpactorInjuryTimeId = [dbo].[ImpactorInjuryTimeData].ImpactorInjuryTimeId
	WHERE [TestRunNumber] = @TestRunNumber
END 
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertInjuryTimeDataRecord]    Script Date: 3/9/2025 4:03:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: March 8, 2025
-- Description:	A procedure to insert an Injury Time Data record
-- =============================================
CREATE PROCEDURE [dbo].[InsertInjuryTimeDataRecord]
	
	@TestRunNumber varchar(50),
	@ImpactorInjuryTimeId bigint,
	@MaxValue float,
	@MaxTime float,
	@MinValue float,
	@MinTime float,
	@Units varchar(10),
	@TimeStamp datetime,
	@Notes varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[ImpactorInjuryTimeData] ([TestRunNumber], [ImpactorInjuryTimeId],[MaxValue], [MaxTime], [MinValue], [MinTime], [Units], [TimeStamp], [Notes])
	                                VALUES (@TestRunNumber, @ImpactorInjuryTimeId, @MaxTime, @MaxValue, @MinValue, @MinTime, @Units, @TimeStamp, @Notes)
	SELECT @@IDENTITY
END
GO


USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[UpdateInjuryTimeDataRecord]    Script Date: 3/9/2025 4:05:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: March 8, 2025
-- Description:	A procedure to update an Injury Data Record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateInjuryTimeDataRecord]
	@ImpactorInjuryTimeDataId bigint,
	@TestRunNumber varchar(50),
	@ImpactorInjuryTimeId bigint,
	@MaxValue float,
	@MaxTime float,
	@MinValue float,
	@MinTime float,
	@Units varchar(10),
	@TimeStamp datetime,
	@Notes varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[ImpactorInjuryTimeData] SET
		[TestRunNumber] = @TestRunNumber,
		[ImpactorInjuryTimeId] = @ImpactorInjuryTimeId,
		[MaxValue] = @MaxValue,
		[MaxTime] = @MaxTime,
		[MinValue] = @MinValue,
		[MinTime] = @MinValue,
		[Units] = @Units,
		[TimeStamp] = @TimeStamp,
		[Notes] = @Notes
	WHERE [ImpactorInjuryTimeDataId] = @ImpactorInjuryTimeDataId

END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[DeleteInjuryTimeDataForATestRun]    Script Date: 3/23/2025 11:43:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: March 23, 2025
-- Description:	A procedure to delete th Injury Time Data for a Test Run
-- =============================================
CREATE PROCEDURE [dbo].[DeleteInjuryTimeDataForATestRun]
	
	@TestRunNumber varchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [dbo].[ImpactorInjuryTimeData] WHERE [TestRunNumber] = @TestRunNumber
	
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[DeleteAnImpactorInjuryTimeDataRecord]    Script Date: 3/23/2025 1:41:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: March 23, 2025
-- Description:	A procedure to delete a single Impactor Injury Time Data Record
-- =============================================
CREATE PROCEDURE [dbo].[DeleteAnImpactorInjuryTimeDataRecord]
	
	@ImpactorInjuryTimeDataId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DELETE FROM [dbo].[ImpactorInjuryTimeData] WHERE [ImpactorInjuryTimeDataId] = @ImpactorInjuryTimeDataId
END
GO

/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~~~~~~~~~~~~~~~~ Impactor Test Parameters ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/


USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorTestParameters]    Script Date: 4/5/2025 4:50:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorTestParameters](
	[ImpactorTestParameterId] [bigint] IDENTITY(1,1) NOT NULL,
	[TestRunNumber] [varchar](50) NULL,
	[ParameterNameId] [bigint] NULL,
	[Value] [float] NULL,
	[TimeOne] [float] NULL,
	[TimeTwo] [float] NULL,
	[Duration] [float] NULL,
 CONSTRAINT [PK_ImpactorTestParameters] PRIMARY KEY CLUSTERED 
(
	[ImpactorTestParameterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetTestParametersForATestRun]    Script Date: 4/5/2025 4:56:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: April 5, 2025
-- Description:	A procedure to return all of the Impactor Test Parameters for a Test Run
-- =============================================
CREATE PROCEDURE [dbo].[GetTestParametersForATestRun]
	
	@TestRunNumber varchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT [ImpactorTestParameterId], [TestRunNumber], [ParameterNameId], [TestParameterName], [Value], [TimeOne], [TimeTwo], [Duration]
	FROM [dbo].[ImpactorTestParameters] INNER JOIN
         [dbo].[ImpactorTestParameterNames] ON [dbo].[ImpactorTestParameterNames].ImpactorTestNameId = [dbo].[ImpactorTestParameters].ParameterNameId
	WHERE [TestRunNumber] = @TestRunNumber
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertAnImpactorTestParameter]    Script Date: 4/5/2025 5:04:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: April 5, 2025
-- Description:	A procedure to insert an Impactor Test Parameter
-- =============================================
CREATE PROCEDURE [dbo].[InsertAnImpactorTestParameter]
	
	@TestRunNumber varchar(50),
	@ParameterNameId bigint,
	@Value float,
	@TimeOne float,
	@TimeTwo float,
	@Duration float

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[ImpactorTestParameters] ([TestRunNumber], [ParameterNameId], [Value], [TimeOne], [TimeTwo], [Duration])
	                                    VALUES (@TestRunNumber, @ParameterNameId, @Value, @TimeOne, @TimeTwo, @Duration)
	SELECT @@IDENTITY
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetTestParameterNames]    Script Date: 4/6/2025 10:51:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: April 6, 2025
-- Description:	A procedure to get all of the Test Parameter Names
-- =============================================
CREATE PROCEDURE [dbo].[GetTestParameterNames]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ImpactorTestNameId], [TestParameterName], [Active]
	FROM [dbo].[ImpactorTestParameterNames]
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorTestParameter]    Script Date: 4/12/2025 4:02:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: April 12, 2025
-- Description:	A procedure to get an Impactor Test Parameter Record
-- =============================================
CREATE PROCEDURE [dbo].[GetImpactorTestParameter]
	
	@ImpactorTestNameId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT [ImpactorTestNameId], [TestParameterName], [Active]
	FROM [dbo].[ImpactorTestParameterNames]
	WHERE [ImpactorTestNameId] = @ImpactorTestNameId

END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertTestParameterRecord]    Script Date: 4/13/2025 12:15:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: April 13, 2025
-- Description:	A procedure to insert a Test Parameter Record
-- =============================================
CREATE PROCEDURE [dbo].[InsertTestParameterRecord]
	
	@TestRunNumber varchar (50),
	@ParameterNameId bigint,
	@Value float,
	@TimeOne float,
	@TimeTwo float,
	@Duration float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[ImpactorTestParameters] ([TestRunNumber], [ParameterNameId], [Value], [TimeOne], [TimeTwo], [Duration])
                                       VALUES (@TestRunNumber, @ParameterNameId, @Value, @TimeOne, @TimeTwo, @Duration)
	SELECT @@IDENTITY
END
GO



USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[DeleteTestParameterRecordForATestRun]    Script Date: 4/13/2025 12:06:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: April 13, 2025
-- Description:	A procedure to delete an IMpactor Test Parameter Record
-- =============================================
CREATE PROCEDURE [dbo].[DeleteTestParameterRecordForATestRun]
	
	@TestRunNumber varchar (50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [dbo].[ImpactorTestParameters] WHERE [TestRunNumber] = @TestRunNumber
END
GO

/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Impactor Test Parameter Names ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorTestParameterNames]    Script Date: 4/14/2025 9:11:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImpactorTestParameterNames]') AND type in (N'U'))
DROP TABLE [dbo].[ImpactorTestParameterNames]
GO

/****** Object:  Table [dbo].[ImpactorTestParameterNames]    Script Date: 4/14/2025 9:11:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorTestParameterNames](
	[ImpactorTestNameId] [bigint] IDENTITY(1,1) NOT NULL,
	[TestParameterName] [varchar](50) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_ImpactorTestParameterNames] PRIMARY KEY CLUSTERED 
(
	[ImpactorTestNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetTestParameterNames]    Script Date: 4/14/2025 9:12:55 AM ******/
DROP PROCEDURE [dbo].[GetTestParameterNames]
GO

/****** Object:  StoredProcedure [dbo].[GetTestParameterNames]    Script Date: 4/14/2025 9:12:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: April 6, 2025
-- Description:	A procedure to get all of the Test Parameter Names
-- =============================================
CREATE PROCEDURE [dbo].[GetTestParameterNames]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ImpactorTestNameId], [TestParameterName], [Active]
	FROM [dbo].[ImpactorTestParameterNames]
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[DeleteTestParameterRecord]    Script Date: 4/19/2025 10:17:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: April 19, 2025
-- Description:	A procedure to delete a Test Parameter Record
-- =============================================
CREATE PROCEDURE [dbo].[DeleteTestParameterRecord]
	
	@ImpactorTestParameterId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [dbo].[ImpactorTestParameters] WHERE [ImpactorTestParameterId] = @ImpactorTestParameterId
END
GO

/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Impactor Critical Parameter Names ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorCriticalInjuryNames]    Script Date: 4/26/2025 10:23:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorCriticalInjuryNames](
	[CriticalInjuryNamesId] [bigint] IDENTITY(1,1) NOT NULL,
	[TestParameterName] [varchar](50) NULL,
	[Channel] [varchar](50) NULL,
 CONSTRAINT [PK_CriticalInjuryNames] PRIMARY KEY CLUSTERED 
(
	[CriticalInjuryNamesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetAllImpactorCriticalParameterNames]    Script Date: 4/26/2025 10:25:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: April 26, 2025
-- Description:	A procedure to Get All of the Critical Injury Names
-- =============================================
CREATE PROCEDURE [dbo].[GetAllImpactorCriticalParameterNames]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [CriticalInjuryNamesId], [TestParameterName], [Channel]
	FROM [dbo].[ImpactorCriticalInjuryNames]
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetImpactorCriticalImpactorName]    Script Date: 4/26/2025 10:28:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak	
-- Create date: April 26, 2025
-- Description:	A procedure to Get a single Critical Injury Name
-- =============================================
CREATE PROCEDURE [dbo].[GetImpactorCriticalImpactorName]
	
	@CriticalInjuryNamesId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [CriticalInjuryNamesId], [TestParameterName], [Channel]
	FROM [dbo].[ImpactorCriticalInjuryNames]
	WHERE [CriticalInjuryNamesId] = @CriticalInjuryNamesId
END
GO

/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Impactor Critical Injury Data ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

USE [Impactor]
GO

/****** Object:  Table [dbo].[ImpactorCriticalInjuryData]    Script Date: 4/26/2025 4:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImpactorCriticalInjuryData](
	[ImpactorCriticalInjuryDataId] [bigint] IDENTITY(1,1) NOT NULL,
	[TestRun] [varchar](50) NULL,
	[ImpactorCriticalInjuryNameId] [bigint] NULL,
	[Value] [varchar](20) NULL,
	[Time] [float] NULL,
 CONSTRAINT [PK_ImpactorCriticalInjuryData] PRIMARY KEY CLUSTERED 
(
	[ImpactorCriticalInjuryDataId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[GetAllCriticalInjuryDataForaTestRun]    Script Date: 4/26/2025 4:50:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: April 27, 2025
-- Description:	A procedure to return all Critical Injury Data Records for a Test Run
-- =============================================
CREATE PROCEDURE [dbo].[GetAllCriticalInjuryDataForaTestRun]
	
	@TestRun varchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT [ImpactorCriticalInjuryDataId], [TestRun], [ImpactorCriticalInjuryNameId], [TestParameterName], [Channel], [Value], [Time]
	FROM [dbo].[ImpactorCriticalInjuryData] INNER JOIN
         [dbo].[ImpactorCriticalInjuryNames] ON [dbo].[ImpactorCriticalInjuryNames].CriticalInjuryNamesId = [dbo].[ImpactorCriticalInjuryData].ImpactorCriticalInjuryNameId
	WHERE [TestRun] = @TestRun
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorCriticalInjuryRecord]    Script Date: 4/26/2025 4:55:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: April 26, 2025
-- Description:	A procedure to insert an Impactor Critical Injury Data Record
-- =============================================
CREATE PROCEDURE [dbo].[InsertImpactorCriticalInjuryRecord]
	
	@TestRun varchar(50),
	@ImpactorCriticalInjuryNameId bigint,
	@Value varchar(20),
	@Time float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[ImpactorCriticalInjuryData] ([TestRun], [ImpactorCriticalInjuryNameId], [Value], [Time])
	                                        VALUES (@TestRun, @ImpactorCriticalInjuryNameId, @Value, @TestRun )
	SELECT @@IDENTITY
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[DeleteImpactorCriticalInjuryDataRecord]    Script Date: 4/26/2025 4:58:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak	
-- Create date: April 26, 2025
-- Description:	A procedure to delete an Impactor Critical Injury Data Record
-- =============================================
CREATE PROCEDURE [dbo].[DeleteImpactorCriticalInjuryDataRecord] 
	
	@ImpactorCriticalInjuryDataId bigint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [dbo].[ImpactorCriticalInjuryData] WHERE [ImpactorCriticalInjuryDataId] = @ImpactorCriticalInjuryDataId
END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[InsertImpactorCriticalInjuryData]    Script Date: 4/27/2025 11:32:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: April 27, 2029
-- Description:	A procedure to insert an Impactor Critical Injury Data Record
-- =============================================
CREATE PROCEDURE [dbo].[InsertImpactorCriticalInjuryData]
	
	@TestRun varchar(50),
	@ImpactorCriticalInjuryNameId bigint,
	@Value varchar(20),
	@Time float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[ImpactorCriticalInjuryData] ([TestRun], [ImpactorCriticalInjuryNameId], [Value], [Time] )
	                                        VALUES (@TestRun, @ImpactorCriticalInjuryNameId, @Value, @Time )

	SELECT @@IDENTITY

END
GO

USE [Impactor]
GO

/****** Object:  StoredProcedure [dbo].[DeleteImpactorCriticalInjuryDataForATestRun]    Script Date: 4/28/2025 8:17:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sniezak
-- Create date: April 28, 2025
-- Description:	A procedure to delete all of the Impactor Critical Injury Data Records for a Test Run
-- =============================================
CREATE PROCEDURE [dbo].[DeleteImpactorCriticalInjuryDataForATestRun]
	
	@TestRun varchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [dbo].[ImpactorCriticalInjuryData] WHERE [TestRun] = @TestRun
END
GO

