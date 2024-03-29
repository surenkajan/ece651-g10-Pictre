USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreGetLikesByID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreGetLikesByID]
END
GO


CREATE PROCEDURE [pictre].[CoreGetLikesByID] @PhotoID int
As
Begin


	
	select b.FirstName, b.LastName, b.ID, b.ProfilePhoto, b.FullName from  (select UserID from [pictre].[Likes] where PhotoID = @PhotoID) a,
	(select * from [pictre].[User])  b
	 where a.UserID=b.ID 
   
END
GO
