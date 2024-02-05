CREATE PROCEDURE [dbo].[Login]


@Email NVARCHAR(100),
@Password NVARCHAR(100)
AS
	
BEGIN
	IF EXISTS (SELECT * FROM [User] WHERE [Email] = @Email)
		BEGIN
			DECLARE @Salt NVARCHAR(100)
			SET @Salt = (SELECT [Salt] FROM [User] WHERE [Email] = @Email)
			SET @Password = HASHBYTES('SHA2_512', @Password + @Salt)
			IF EXISTS (SELECT * FROM [User] WHERE [Email] = @Email AND [Password] = @Password)
				BEGIN
					RETURN 0
				END
			ELSE
				BEGIN
					RETURN 1
				END
		END
END

GO
