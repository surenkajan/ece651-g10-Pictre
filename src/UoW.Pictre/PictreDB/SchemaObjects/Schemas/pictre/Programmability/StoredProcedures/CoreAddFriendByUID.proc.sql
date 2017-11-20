USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreAddFriendByUID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreAddFriendByUID]
END
GO


CREATE PROCEDURE [pictre].[CoreAddFriendByUID]
	@Uid							int,
	@currentUserEmailID				VARCHAR(150)
	
AS
	INSERT INTO [pictre].[Friends]
	(ID, FriendID) VALUES
	(
		(Select us.ID from [pictre].[User] as us where [EmailAddress] = @currentUserEmailID),@Uid
		
	);
	INSERT INTO [pictre].[Friends]
	(ID, FriendID) VALUES
	(
	@Uid,(Select us.ID from [pictre].[User] as us where [EmailAddress] = @currentUserEmailID)
	);
RETURN 0
	
	