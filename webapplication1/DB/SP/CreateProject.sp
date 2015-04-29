CREATE PROCEDURE [dbo].[CreateProject] 
(
	--Input Parameter
	@Subject nvarchar(255),
	@Description nvarchar(1000),
	@StartTime datetime2,
	@EndTime datetime2,
	@Result int=0 OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;  
	SET LOCK_TIMEOUT 20000;  

	BEGIN TRY  
		BEGIN TRAN   
			INSERT INTO dbo.Project (Subject, Status, Description, StartTime, EndTime)
			VALUES(@Subject, 1, @Description, @StartTime, @EndTime)
		COMMIT TRAN;   
		SET @Result = 1
	END TRY

	BEGIN CATCH
		SET @Result = 0
	END CATCH

	SELECT @Result as Result
END