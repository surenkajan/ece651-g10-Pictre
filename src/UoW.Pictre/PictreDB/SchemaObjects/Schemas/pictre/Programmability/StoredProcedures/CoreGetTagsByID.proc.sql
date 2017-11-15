USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreGetTagsByID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreGetTagsByID]
END
GO


CREATE PROCEDURE [pictre].[CoreGetTagsByID] @PhotoID int
As
Begin


	
	select b.FirstName,b.LastName from  (select UserID from [pictre].[Tags] where PhotoID = @PhotoID) a,
	(select FirstName,ID,LastName from [pictre].[User])  b
	 where a.UserID=b.ID 
   
END
GO