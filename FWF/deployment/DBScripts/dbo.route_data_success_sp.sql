-- =======================================================
-- Create Stored Procedure Template for Azure SQL Database
-- =======================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Aziz Umarov
-- Create Date: 12/08-2024
-- Description: Merge Data after loading
-- =============================================
CREATE PROCEDURE route_data_success_sp
(
    @runId uniqueidentifier
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
	-- proceed here any logic for processing data
    insert into [dbo].[route]
	(
		[airline],
		[sourceAirport],
		[destinationAirport],
		[codeShare],
		[stops],
		[equipment],	
		[sourceName],
		[createdAt]
	)
	SELECT 
		[fs].[airline],
		[fs].[sourceAirport],
		[fs].[destinationAirport],
		[fs].[codeShare],
		[fs].[stops],
		[fs].[equipment],	
		[fs].[provider],
		[fs].[createdAt]
	FROM [dbo].[route_staging] [fs] (nolock)
	LEFT JOIN [dbo].[route] [f] (nolock) ON
		[fs].[airline] = [f].[airline]
		AND [fs].[sourceAirport] = [f].[sourceAirport]
		AND [fs].[destinationAirport] = [f].[destinationAirport]
		AND [fs].[codeShare] = [f].[codeShare]
		AND [fs].[stops] = [f].[stops]
	WHERE 
		[fs].[pipelineRunId] = @runId
		AND [f].[airline] IS NULL

	DELETE [f]
	FROM [dbo].[route_staging] [fs] (nolock)
	RIGHT JOIN [dbo].[route] [f] (nolock) ON
		[fs].[airline] = [f].[airline]
		AND [fs].[sourceAirport] = [f].[sourceAirport]
		AND [fs].[destinationAirport] = [f].[destinationAirport]
		AND [fs].[codeShare] = [f].[codeShare]
		AND [fs].[stops] = [f].[stops]
		AND [fs].[provider] = [f].[sourceName]
	WHERE 
		[fs].[pipelineRunId] = @runId
		AND [f].[airline] IS NULL



END
GO
