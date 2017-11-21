USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreGetCommentsByID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreGetCommentsByID]
END
GO


CREATE PROCEDURE [pictre].[CoreGetCommentsByID] @PhotoID int
As
Begin


	
	select c.Comment ,c.CommentTime, u.FirstName, u.LastName, c.PhotoID, c.UserID, u.FullName,u.ProfilePhoto from [Pictre].[Comments] c inner join [Pictre].[User] u on c.UserID = u.ID where PhotoID = @PhotoID
	order by c.CommentTime desc
   
END
GO
--exec  [pictre].[CoreGetCommentsByID] @PhotoID =3

--select * from [pictre].[Comments]