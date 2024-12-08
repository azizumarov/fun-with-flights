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
 CONSTRAINT [PK_flight] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO