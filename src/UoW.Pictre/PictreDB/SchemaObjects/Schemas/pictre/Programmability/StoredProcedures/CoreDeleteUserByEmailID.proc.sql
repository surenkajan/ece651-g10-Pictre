USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreDeleteUserByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreDeleteUserByEmailID]
END
GO


CREATE PROCEDURE [pictre].[CoreDeleteUserByEmailID]
	@EmailAddress VARCHAR(240)
AS
	DELETE FROM [pictre].[User]
	WHERE EmailAddress = @EmailAddress;
RETURN 0


--EXEC [pictre].[CoreDeleteUserByEmailID] @EmailAddress= 'user1@gmail.com'
	
	