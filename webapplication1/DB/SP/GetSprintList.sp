CREATE PROCEDURE [dbo].[GetSprintList] 
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
			Description nvarchar(1000),
			StartTime datetime2,
			EndTime datetime2,
			Reporter nvarchar(255),
			Project nvarchar(255),
			Status nvarchar(255)
		)

		INSERT INTO @Tbl
			SELECT S.Id, S.Subject, S.Description, S.StartTime, S.EndTime, U.Name, P.Name, T.Name
				FROM [Jira].[dbo].[Sprint] S
					JOIN [Jira].[dbo].[Status] T ON S.Status = T.Id
					JOIN [Jira].[dbo].[Users] U ON S.Reporter = U.UserId
					JOIN [Jira].[dbo].[Project] P ON S.Project = P.Id
				WHERE S.CreatedTimeStamp >= @StartDate AND  S.CreatedTimeStamp <= @EndDate

		SELECT * FROM @Tbl 
		WHERE SeqNo>=((@PageNumber-1)*@PageRows)+1 AND SeqNo<=@PageNumber*@PageRows  
		ORDER BY SeqNo;  

		SELECT (SELECT COUNT(*) FROM @TBL) AS TotalCount
	END TRY

	BEGIN CATCH
	END CATCH
END