CREATE PROCEDURE [dbo].[NewUser]
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(100),
    @Password NVARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT *
               FROM [User]
               WHERE [Email] = @Email)
        BEGIN
            RAISERROR('Email already in use', 16, 1);
            RETURN 1;
        END
    ELSE
        BEGIN
            DECLARE @Salt AS VARBINARY(100);
            SET @Salt = CAST(NEWID() AS VARBINARY(100));

            DECLARE @PasswordHash VARBINARY(100);
            SET @PasswordHash = HASHBYTES('SHA2_512', CONVERT(VARBINARY(100), @Password) + @Salt);

            INSERT INTO [User] ([FirstName], [LastName], [Salt], [Email], [Password])
            VALUES (@FirstName, @LastName, @Salt, @Email, @PasswordHash);
            
            RETURN 0;
        END
END