/****** Object:  Table [dbo].[flight_staging]    Script Date: 12/8/2024 5:23:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[flight_staging](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[airline] [nvarchar](50) NULL,
	[sourceAirport] [nvarchar](50) NULL,
	[destinationAirport] [nvarchar](50) NULL,
	[codeShare] [nvarchar](50) NULL,
	[stops] [int] NULL,
	[equipment] [nvarchar](50) NULL,
	[pipelineRunId] [uniqueidentifier] NULL,
	[provider] [nvarchar](50) NULL,
	[createdAt] [datetime] NULL,
 CONSTRAINT [PK_flight_staging] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


