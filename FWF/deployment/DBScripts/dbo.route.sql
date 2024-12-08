SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[route](
	[airline] [nvarchar](50) NOT NULL,
	[sourceAirport] [nvarchar](50) NOT NULL,
	[destinationAirport] [nvarchar](50) NOT NULL,
	[codeShare] [nvarchar](50) NOT NULL,
	[stops] [int] NOT NULL,
	[equipment] [nvarchar](50) NULL,
	[sourceName] [nvarchar](50) null,
	[createdAt] [datetime] not null,
CONSTRAINT [PK_route] PRIMARY KEY CLUSTERED 
(
	[airline] 
	,[sourceAirport]
	,[destinationAirport]
	,[codeShare]
	,[stops]
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

