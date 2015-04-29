ALTER PROCEDURE [dbo].[GetProjectList] 
(
	--Input Parameter
	@StartDate datetime2,
	@EndDate datetime2,
	@PageNumber int,
	@PageRows int
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;  
	SET LOCK_TIMEOUT 20000;  

	BEGIN TRY  
		DECLARE @Tbl Table(
			SeqNo int IDENTITY(1,1) PRIMARY KEY,
			Id int, 
			Subject nvarchar(255),
			Status nvarchar(255),
			StartTime datetime2,
			EndTime datetime2
		)

		INSERT INTO @Tbl
			SELECT P.Id, P.Subject, T.Name, P.StartTime, P.EndTime
				FROM [Jira].[dbo].[Project] P
					JOIN [Jira].[dbo].[Status] T ON P.Status = T.Id
				WHERE P.CreatedTimeStamp >= @StartDate AND  P.CreatedTimeStamp <= @EndDate

		SELECT * FROM @Tbl 
			WHERE SeqNo>=((@PageNumber-1)*@PageRows)+1 AND SeqNo<=@PageNumber*@PageRows  
			ORDER BY SeqNo

		SELECT (SELECT COUNT(*) FROM @TBL) AS TotalCount
	END TRY

	BEGIN CATCH
	END CATCH
END