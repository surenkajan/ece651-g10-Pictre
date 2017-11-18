USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreGetSecurityQuestions]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreGetSecurityQuestions]
END

GO

CREATE PROCEDURE [pictre].[CoreGetSecurityQuestions]
	@UserTablePreFix varchar(10)
AS
SELECT * FROM [pictre].[SecurityQuestion]
GO

--USE Pictre

--INSERT INTO [pictre].[SecurityQuestion] (Question)
--VALUES ('What is your Dog Name?')

--INSERT INTO [pictre].[SecurityQuestion] (Question)
--VALUES ('Where you Born?')

--EXEC [pictre].[CoreGetSecurityQuestions] @UserTablePreFix= 'AU'