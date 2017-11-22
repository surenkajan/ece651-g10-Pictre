
USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreDeletePhotoByPhotoID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreDeletePhotoByPhotoID]
END
GO


CREATE PROCEDURE [pictre].[CoreDeletePhotoByPhotoID]
	@PhotoID int
AS
	DELETE FROM [pictre].[Likes]
	WHERE [Likes].PhotoID = @PhotoID;
	DELETE FROM [pictre].[Comments]
	WHERE [Comments].PhotoID = @PhotoID;
	DELETE FROM [pictre].[Tags]
	WHERE [Tags].PhotoID = @PhotoID;
	DELETE FROM [pictre].[Checkin]
	WHERE [Checkin].PhotoID = @PhotoID;
	DELETE FROM [pictre].[Photo]
	WHERE [Photo].ID = @PhotoID;
RETURN 0


--EXEC [pictre].[CoreDeletePhotoByPhotoID] @PhotoID= 1
--select * from [pictre].[Photo]