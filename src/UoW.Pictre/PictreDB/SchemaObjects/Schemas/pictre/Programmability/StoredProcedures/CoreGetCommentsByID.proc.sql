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


	
	select a.Comment ,b.FirstName,a.CommentTime from  (select UserID,Comment,CommentTime from [pictre].[Comments] where PhotoID = @PhotoID) a,
	(select FirstName,ID from [pictre].[User])  b
	 where a.UserID=b.ID order by a.CommentTime desc
   
END
GO