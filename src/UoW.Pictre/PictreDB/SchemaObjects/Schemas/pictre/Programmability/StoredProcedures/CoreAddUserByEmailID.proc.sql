USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreAddUserByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreAddUserByEmailID]
END
GO


CREATE PROCEDURE [pictre].[CoreAddUserByEmailID]
	@UserName				VARCHAR(50),
	@FirstName				VARCHAR(150),
	@LastName				VARCHAR(150),
	@FullName				VARCHAR(240),
	@EmailAddress			VARCHAR(240),
	@DateOfBirth			DATETIME,
	@Sex					VARCHAR(30),
	@ProfilePhoto			image
AS
	INSERT INTO [pictre].[User]
	(UserName, FirstName, LastName, FullName, EmailAddress, DateOfBirth, Sex,ProfilePhoto) VALUES
	(
		@UserName,@FirstName, @LastName, @FullName, @EmailAddress, @DateOfBirth, 
		@Sex, @ProfilePhoto
	);
RETURN 0
	
	