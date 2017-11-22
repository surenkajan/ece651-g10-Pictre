USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreGetUserByFullName]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreGetUserByFullName]
END

GO


CREATE PROCEDURE [pictre].[CoreGetUserByFullName] 
	@Fullname varchar(240)
AS
SELECT * FROM [pictre].[User] u WHERE u.FullName = @Fullname
GO

--EXEC [pictre].[CoreGetUserByEmailIDtemp] @EmailAddress= 'surenkajan@gmail.com'