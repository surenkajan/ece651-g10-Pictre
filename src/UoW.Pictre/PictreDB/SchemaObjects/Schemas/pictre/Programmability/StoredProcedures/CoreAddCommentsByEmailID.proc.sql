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
	@currentUserEmailID				VARCHAR(150),
	@Comment                       text,
	@CommetsTime              date
	
AS
	INSERT INTO [pictre].[Comments]
	(UserID, PhotoID,Comment,CommentTime) VALUES
	(
		(Select us.ID from [pictre].[User] as us where [EmailAddress] = @currentUserEmailID),@PhotoId,@Comment,@CommetsTime
	);
RETURN 0