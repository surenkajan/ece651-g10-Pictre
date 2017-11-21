USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[GetCoreSecurityAnswersEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[GetCoreSecurityAnswersEmailID]
END
GO


CREATE PROCEDURE [pictre].[GetCoreSecurityAnswersEmailID]
	@EmailAddress			VARCHAR(240),
	@Question			VARCHAR(max)

AS
	-- Answers to the 1st Questions
	SELECT * FROM [pictre].[UserSecurity] 
	WHERE 
	UserID = (SELECT ID FROM [Pictre].[pictre].[User] WHERE EmailAddress = @EmailAddress) 
	AND 
	QuestionID = (SELECT [ID] FROM [Pictre].[pictre].[SecurityQuestion] WHERE Question = @Question)

	GO
	

	
	