USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreAllUsers]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreAllUsers]
END

GO

CREATE PROCEDURE [pictre].[CoreAllUsers]
	@UserTablePreFix varchar(10)
AS
SELECT * FROM [pictre].[User]
GO

--EXEC [pictre].[CoreAllUsers] @UserTablePreFix= 'AU'