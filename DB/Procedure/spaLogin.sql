CREATE OR ALTER PROCEDURE spaLogin
(
@Flag							NVARCHAR(250)	=	NULL
,@UserName						VARCHAR(250)	=	NULL
,@FullName						VARCHAR(250)	=	NULL
,@Password						NVARCHAR(MAX)	=	NULL
,@ConfirmPassword				NVARCHAR(MAX)	=	NULL
,@Email							VARCHAR(250)	=	NULL
,@MobileNumber					VARCHAR(250)	=	NULL
,@User							VARCHAR(250)	=	NULL
)
AS
BEGIN
BEGIN TRY

	IF(@Flag = 'Login')
	BEGIN
		IF NOT EXISTS(SELECT 'X' FROM DtaUserDetail WITH(NOLOCK) WHERE UserName = @UserName AND IsActive = 1 AND IsDeleted = 0)
		BEGIN
			SELECT '1' AS ErrorCode, 'USERNAME NOT FOUND!' AS [Message]
			RETURN;
		END
		ELSE IF EXISTS(SELECT 'X' FROM DtaUserDetail WITH(NOLOCK) WHERE UserName = @UserName AND PWDCOMPARE(@Password,[Password]) = 0 AND IsActive = 1 AND IsDeleted = 0)
		BEGIN
			UPDATE DtaUserDetail
			SET LoginAttempts += 1
			WHERE UserName = @UserName

			IF EXISTS(SELECT 'X' FROM DtaUserDetail WITH(NOLOCK) WHERE UserName = @UserName AND LoginAttempts > 3 AND IsActive = 1 AND IsDeleted = 0)
			BEGIN
				SELECT '1' AS ErrorCode, 'YOUR LOGIN ATTEMPS IS MAXIMUM THAN 3. PLEASE CONTACT OUR SUPPORT TEAM!' AS [Message]
				RETURN;
			END
			SELECT '1' AS ErrorCode, 'INVALID PASSWORD!' AS [Message]
			RETURN;
		END
		ELSE
		BEGIN
			IF EXISTS(SELECT 'X' FROM DtaUserDetail WITH(NOLOCK) WHERE UserName = @UserName AND PWDCOMPARE(@Password,[Password]) = 1 AND IsActive = 1 AND IsDeleted = 0)
			BEGIN
				SELECT '0' AS ErrorCode, 'SUCCESS!' AS [Message]
				SELECT Id,UserName,FullName,Email,MobileNumber 
				FROM DtaUserDetail WITH(NOLOCK)
				WHERE UserName = @UserName AND IsActive = 1 AND IsDeleted = 0
				UPDATE DtaUserDetail
				SET LoginAttempts = 0
				WHERE UserName = @UserName
			END
			ELSE
			BEGIN
				SELECT '1' AS ErrorCode, 'USERNAME AND PASSWORD DOES NOT MATCHED!' AS [Message]
				RETURN;
			END
		END
	END

	ELSE IF (@Flag = 'SignUp')
	BEGIN
		IF EXISTS(SELECT 'X' FROM DtaUserDetail WITH(NOLOCK) WHERE UserName = @UserName AND IsActive = 1 AND IsDeleted = 0)
		BEGIN
			SELECT '1' AS ErrorCode, 'USERNAME ALREADY EXISTS!' AS [Message]
			RETURN;
		END
		ELSE IF EXISTS(SELECT 'X' FROM DtaUserDetail WITH(NOLOCK) WHERE Email = @Email AND IsActive = 1 AND IsDeleted = 0)
		BEGIN
			SELECT '1' AS ErrorCode, 'EMAIL ADDRESS ALREADY EXISTS!' AS [Message]
			RETURN;
		END
		ELSE IF EXISTS(SELECT 'X' FROM DtaUserDetail WITH(NOLOCK) WHERE MobileNumber = @MobileNumber AND IsActive = 1 AND IsDeleted = 0)
		BEGIN
			SELECT '1' AS ErrorCode, 'MOBILE NUMBER ALREADY EXISTS!' AS [Message]
			RETURN;
		END
		ELSE IF(@Password <> @ConfirmPassword)
		BEGIN
			SELECT '1' AS ErrorCode, 'PASSWORD AND CONFIRM PASSWORD DOES NOT MATCH!' As [Message]
			RETURN;
		END
		ELSE
		BEGIN
			INSERT INTO DtaUserDetail(UserName,FullName,Password,Email,MobileNumber,LoginAttempts,CreatedBy)
			VALUES (@UserName,@FullName,PWDENCRYPT(@Password),@Email,@MobileNumber,0,@User)
			SELECT '0' AS ErrorCode, 'USER CREATED SUCCESSFULLY!' As [Message]
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