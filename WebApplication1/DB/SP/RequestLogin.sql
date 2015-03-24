CREATE PROCEDURE [dbo].[RequestLogin] 
(
	--Input Parameter
	@Email varchar(255),
	@Password varchar(255)
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;  
	SET LOCK_TIMEOUT 20000;  

	BEGIN TRY  
		--Output Parameter
		DECLARE @Result int;
		DECLARE @Description varchar(255);
		BEGIN TRAN   
		
		--Check Users is available
		DECLARE @Userid varchar(255);
		DECLARE @Status int;
		SET @Userid = (SELECT UserId FROM Jira.dbo.Users WHERE Email = @Email);

		IF @Userid IS NULL
		BEGIN
			SET @Result = -1;
			SET @Description = '����ڰ� �����ϴ�.';
		END
		--CHECK Password is correct
		ELSE IF NOT EXISTS (SELECT TOP 1 * FROM Jira.dbo.Users WHERE Email = @Email AND Password = @Password)
		BEGIN
			SET @Result = -2;
			SET @Description = '��й�ȣ�� ��ġ ���� �ʽ��ϴ�.';
			INSERT INTO Jira.dbo.LoginHistory (UserId, Status) Values(@Userid, @Result);
		END
		ELSE
		--Login Success
		BEGIN
			SET @Result = 0;
			SET @Description = '�α��� ����';
			INSERT INTO Jira.dbo.LoginHistory (UserId, Status) Values(@Userid, @Result);
		END
		COMMIT TRAN;     
		SELECT @Result AS 'RESULT', @Description AS 'DESC';
	END TRY
	BEGIN CATCH
	END CATCH
END