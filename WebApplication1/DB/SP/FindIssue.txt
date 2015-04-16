CREATE PROCEDURE [dbo].[FindIssue] 
(
	--Input Parameter
	@Id int
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;  
	SET LOCK_TIMEOUT 20000;  

	BEGIN TRY  
	SELECT I.Id, I.Subject, S.Name AS Status, P.Name AS Priority, I.FixVersion, U.Name AS Assignee, CONVERT(varchar(10),I.Estimate) + 'MD' AS Estimate, 
		ISNULL(CompletedTimeStamp, '') AS CompletedTimeStamp, U1.Name AS Repoter, I.CreatedTimeStamp, I.Description
	FROM [Jira].[dbo].[Issues] I 
		LEFT JOIN [Jira].[dbo].[Status] S 
			ON I.Status = S.Id
		LEFT JOIN [Jira].[dbo].[Users] U
			ON I.Assignee = U.UserId
		LEFT JOIN [Jira].[dbo].[Users] U1
			ON I.Reporter = U1.UserId
		LEFT JOIN [Jira].[dbo].[Priority] P
			ON I.Priority = P.Id
	WHERE I.Id = @Id

	END TRY

	BEGIN CATCH
	END CATCH
END
