USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreGetFriendsByID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].CoreGetFriendsByID
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



CREATE PROCEDURE [pictre].[CoreGetFriendsByID] 
	@ID int

AS
SELECT * FROM [pictre].[Friends] WHERE ID = @ID
GO
