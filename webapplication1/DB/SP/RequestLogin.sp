CREATE PROCEDURE [dbo].[RequestLogin] 
(
	--Input Parameter
	@Email nvarchar(255),
	@Password nvarchar(255)
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;  
	SET LOCK_TIMEOUT 20000;  

	BEGIN TRY  
		--Output Parameter
		DECLARE @Result int;
		DECLARE @Description nvarchar(255);
		BEGIN TRAN   
		
		--Check Users is available
		DECLARE @Userid nvarchar(255);
		DECLARE @Status int;
		SET @Userid = (SELECT UserId FROM Jira.dbo.Users WHERE Email = @Email);

		IF @Userid IS NULL
		BEGIN
			SET @Result = -1;
			SET @Description = '사용자가 없습니다.';
		END
		--CHECK Password is correct
		ELSE IF NOT EXISTS (SELECT TOP 1 * FROM Jira.dbo.Users WHERE Email = @Email AND Password = @Password)
		BEGIN
			SET @Result = -2;
			SET @Description = '비밀번호가 일치 하지 않습니다.';
			INSERT INTO Jira.dbo.LoginHistory (UserId, Status) Values(@Userid, @Result);
		END
		ELSE
		--Login Success
		BEGIN
			SET @Result = 0;
			SET @Description = '로그인 성공';
			INSERT INTO Jira.dbo.LoginHistory (UserId, Status) Values(@Userid, @Result);
		END
		COMMIT TRAN;     
		SELECT @Result AS 'RESULT', @Description AS 'DESC';
	END TRY
	BEGIN CATCH
	END CATCH
END