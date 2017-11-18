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
	@QuestionAndAnswers	    VARCHAR(max)
AS
	INSERT INTO [pictre].[UserSecurity]
	(UserID, QuestionID, Answer) VALUES
	(
		@UserName,@FirstName, @LastName, @FullName, @EmailAddress, @DateOfBirth, @Sex
	);
RETURN 0
	
	