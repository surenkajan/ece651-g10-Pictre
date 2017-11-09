USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreGetUserByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreGetUserByEmailID]
END

GO

--TODO : Enable the Prefix data retrieve here  Later
--CREATE PROCEDURE [pictre].[CoreGetUserByEmailID]
--	@EmailAddress VARCHAR(240),
--	@UserTablePreFix varchar(10)
--AS
--	DECLARE @UsrTableColumns nvarchar(MAX)
--	DECLARE @GetUserQuery nvarchar(MAX)

--	EXEC [pictre].[CoreGetUserTableColumns] @TablePreFix=@UserTablePreFix, @UserTableColumns=@UsrTableColumns OUTPUT
	
--	SET @GetUserQuery = '
--		SELECT ''DummyValue'' AS ''DummyCol'''
--	   + @UsrTableColumns + 
--		'FROM pictre.User' + @UserTablePreFix + 'WHERE EmailAddress=@EAddress'

--	EXEC sp_executesql
--        @GetUserQuery,
--        N'@EAddress VARCHAR(240)',
--        @EAddress = @EmailAddress



CREATE PROCEDURE [pictre].[CoreGetUserByEmailID] 
	@EmailAddress VARCHAR(240), 
	@UserTablePreFix varchar(10)
AS
SELECT * FROM [pictre].[User] WHERE EmailAddress = @EmailAddress
GO

--EXEC [pictre].[CoreGetUserByEmailIDtemp] @EmailAddress= 'surenkajan@gmail.com'