CREATE OR ALTER PROCEDURE spaUser
(
@Flag							NVARCHAR(250)	=	NULL
,@UserId						VARCHAR(250)	=	NULL
,@UserName						VARCHAR(250)	=	NULL
,@FullName						VARCHAR(250)	=	NULL
,@OldPassword					NVARCHAR(MAX)	=	NULL
,@Password						NVARCHAR(MAX)	=	NULL
,@ConfirmPassword				NVARCHAR(MAX)	=	NULL
,@Email							VARCHAR(250)	=	NULL
,@MobileNumber					VARCHAR(250)	=	NULL
,@User							VARCHAR(250)	=	NULL
)
AS
BEGIN
BEGIN TRY

	IF(@Flag = 'GetUserDetailById')
	BEGIN
		IF NOT EXISTS(SELECT 'X' FROM DtaUserDetail WITH(NOLOCK) WHERE Id = @UserId AND IsActive = 1 AND IsDeleted = 0)
		BEGIN
			SELECT '1' AS ErrorCode, 'USER NOT FOUND!' AS [Message]
			RETURN;
		END
		ELSE
		BEGIN
			SELECT '0' AS ErrorCode, 'SUCCESS!' AS [Message]

			SELECT Id,UserName,FullName,Email,MobileNumber 
			FROM DtaUserDetail WITH(NOLOCK)
			WHERE Id = @UserId AND IsActive = 1 AND IsDeleted = 0
		END
	END

	ELSE IF (@Flag = 'ChangePassword')
	BEGIN
		IF NOT EXISTS(SELECT 'X' FROM DtaUserDetail WITH(NOLOCK) WHERE Id = @UserId AND IsActive = 1 AND IsDeleted = 0)
		BEGIN
			SELECT '1' AS ErrorCode, 'USER NOT FOUND!' AS [Message]
			RETURN;
		END
		ELSE IF EXISTS(SELECT 'X' FROM DtaUserDetail WITH(NOLOCK) WHERE Id = @UserId AND PWDCOMPARE(@OldPassword,Password) = 0)
		BEGIN
			SELECT '1' AS ErrorCode, 'OLD PASSWORD DOES NOT MATCH!' As [Message]
			RETURN;
		END
		ELSE IF EXISTS(SELECT 'X' FROM DtaUserDetail WITH(NOLOCK) WHERE Id = @UserId AND PWDCOMPARE(@Password,Password) = 1)
		BEGIN
			SELECT '1' AS ErrorCode, 'NEW PASSWORD IS SAME AS OLD PASSWORD!' As [Message]
			RETURN;
		END
		ELSE IF(@Password <> @ConfirmPassword)
		BEGIN
			SELECT '1' AS ErrorCode, 'PASSWORD AND CONFIRM PASSWORD DOES NOT MATCH!' As [Message]
			RETURN;
		END
		ELSE
		BEGIN
			UPDATE DtaUserDetail
			SET Password = PWDENCRYPT(@Password)
			WHERE Id = @UserId
			SELECT '0' AS ErrorCode, 'PASSWORD CHANGED SUCCESSFULLY!' As [Message]
			RETURN;
		END
	END

END TRY
BEGIN CATCH
	IF (@@ERROR > 0 AND @@TRANCOUNT > 0)
	BEGIN
		ROLLBACK TRANSACTION
		SELECT '1' AS ErrorCode, ERROR_MESSAGE() AS [Message]
		RETURN;
	END
END CATCH
END