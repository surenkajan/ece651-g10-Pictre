USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreGetUserByUid]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreGetUserByUid]
END

GO


CREATE PROCEDURE [pictre].[CoreGetUserByUid] 
	@Uid int
AS
SELECT * FROM [pictre].[User] WHERE ID = @Uid
GO

--EXEC [pictre].[CoreGetUserByEmailIDtemp] @EmailAddress= 'surenkajan@gmail.com'