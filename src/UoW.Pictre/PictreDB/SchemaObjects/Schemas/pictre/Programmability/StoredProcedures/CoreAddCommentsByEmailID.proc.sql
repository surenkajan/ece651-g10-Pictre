USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreAddCommentsByUID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreAddCommentsByUID]
END
GO


CREATE PROCEDURE [pictre].[CoreAddCommentsByEmailID]
	@PhotoId							int,
	@currentUserEmailID				VARCHAR(240),
	@Comment                       text,
	@CommentsTime              datetime
	
AS
	INSERT INTO [pictre].[Comments]
	(UserID, PhotoID,Comment,CommentTime) VALUES
	(
		(Select us.ID from [pictre].[User] as us where us.EmailAddress = @currentUserEmailID),@PhotoId,@Comment,@CommentsTime
	);
RETURN 0