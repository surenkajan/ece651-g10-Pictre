USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[AddSecurityAnswersEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[AddSecurityAnswersEmailID]
END
GO


CREATE PROCEDURE [pictre].[AddSecurityAnswersEmailID]
	@EmailAddress			VARCHAR(240),
	--@QuestionAndAnswers	    VARCHAR(max),
	@Question1			VARCHAR(max),
	@Question1Answer    VARCHAR(max),
	@Question2			VARCHAR(max),
	@Question2Answer    VARCHAR(max)

AS
	-- Answers to the 1st Questions
	INSERT INTO [pictre].[UserSecurity]
	(UserID, QuestionID, Answer) VALUES
	(
		(SELECT ID FROM [Pictre].[pictre].[User] where EmailAddress = @EmailAddress),
		(SELECT ID FROM [Pictre].[pictre].[SecurityQuestion] where Question = @Question1),
		@Question1Answer
	);
	-- Answers to the 2nd Questions
	INSERT INTO [pictre].[UserSecurity]
	(UserID, QuestionID, Answer) VALUES
	(
		(SELECT ID FROM [Pictre].[pictre].[User] where EmailAddress = @EmailAddress),
		(SELECT ID FROM [Pictre].[pictre].[SecurityQuestion] where Question = @Question2),
		@Question2Answer
	);
RETURN 0
	
	