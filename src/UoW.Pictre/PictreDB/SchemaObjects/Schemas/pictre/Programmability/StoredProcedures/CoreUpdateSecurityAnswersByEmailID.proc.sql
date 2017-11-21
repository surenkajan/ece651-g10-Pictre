USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreUpdateSecurityAnswersEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreUpdateSecurityAnswersEmailID]
END

GO


CREATE PROCEDURE [pictre].[CoreUpdateSecurityAnswersEmailID]
	@EmailAddress			VARCHAR(240),
	@Question1			VARCHAR(max),
	@Question1Answer    VARCHAR(max),
	@Question2			VARCHAR(max),
	@Question2Answer    VARCHAR(max)
AS
    -- Answers to the 1st Questions
	UPDATE  [pictre].[UserSecurity]
	SET 
	Answer = @Question1Answer 
	WHERE (UserID = (SELECT ID FROM [Pictre].[pictre].[User] where EmailAddress = @EmailAddress))
	AND 
	(QuestionID = (SELECT ID FROM [Pictre].[pictre].[SecurityQuestion] where Question = @Question1));

	-- Answers to the 2nd Questions
	UPDATE  [pictre].[UserSecurity]
	SET
	Answer = @Question2Answer 
	WHERE (UserID = (SELECT ID FROM [Pictre].[pictre].[User] where EmailAddress = @EmailAddress)) 
	AND
	(QuestionID = (SELECT ID FROM [Pictre].[pictre].[SecurityQuestion] where Question = @Question2));
RETURN 0


--EXEC [pictre].[CoreUpdateUserByEmailID] @UserName = "FooBooFoo1", @FirstName = "Foo1",@LastName = "Boo1", @FullName = "Foo Boo1", @EmailAddress= 'fooboo1@gmail.com', @DateOfBirth = '1993-11-18 10:34:09.000'  , @Sex="Male";