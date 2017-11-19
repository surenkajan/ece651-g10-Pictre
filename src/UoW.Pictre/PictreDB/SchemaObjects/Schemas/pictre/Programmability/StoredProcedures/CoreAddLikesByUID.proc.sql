USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreAddLikesByUID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreAddLikesByUID]
END
GO


CREATE PROCEDURE [pictre].[CoreAddLikesByUID]
	@PhotoId							int,
	@currentUserEmailID				VARCHAR(240)	
	
AS
if @currentUserEmailID	not in( (select b.EmailAddress from (select UserID from [pictre].[Likes] where [Likes].PhotoID= @PhotoId) a,[pictre].[User] b where a.UserID=b.ID))
	INSERT INTO [pictre].[Likes]
	(UserID, PhotoID) VALUES
	(
		(Select us.ID from [pictre].[User] as us where us.EmailAddress = @currentUserEmailID),@PhotoId
	);
	else
	delete from [pictre].[Likes] where [Likes].UserID =(select ID from [pictre].[User] where [User].EmailAddress=@currentUserEmailID)  and [Likes].PhotoID =@PhotoId
GO

--exec [pictre].[CoreAddLikesByUID]  @PhotoId =1 ,@currentUserEmailID ='enlil@gmail.com'

----select * from [pictre].[Photo]
--select * from [pictre].[Likes]

