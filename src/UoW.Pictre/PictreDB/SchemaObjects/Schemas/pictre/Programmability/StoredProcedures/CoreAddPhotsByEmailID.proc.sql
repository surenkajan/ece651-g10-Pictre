USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreAddPhotsByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreAddPhotsByEmailID]
END
GO


CREATE PROCEDURE [pictre].[CoreAddPhotsByEmailID]
	@PhotoDescription       text				,
	@UploadTimeStamp		datetime,
	@Location				VARCHAR(45),
	@Tags				   VARCHAR(400),
	@EmailAddress			VARCHAR(240)
	
AS

	INSERT INTO [pictre].[Photo]
(UserID, PhotoDescription, UploadTimeStamp) VALUES
	(
		(select ID  from [pictre].[User] where EmailAddress =@EmailAddress), @PhotoDescription,@UploadTimeStamp 
	);
	Insert into [pictre].[Checkin] (UserID,PhotoID,Location) values(
	(select ID  from [pictre].[User] where EmailAddress =@EmailAddress),(select TOP 1 ID from [pictre].[Photo] ORDER BY ID DESC),@Location);
	insert into [pictre].[Tags] select (Select TOP 1 u.ID from [pictre].[User] u  where u.FullName = Items),(select TOP 1 ID from [pictre].[Photo] ORDER BY ID DESC) FROM  [Pictre].[Split](@Tags, ',') ;



RETURN 0




--exec [pictre].[CoreAddPhotsByEmailID] @PhotoDescription ='hgsd', @Location ='newYork',@Tags='Kajaruban Surendran,Brindha G',@EmailAddress='enlil@gmail.com',@UploadTimeStamp='2017-10-11'
--	select * from [pictre].[Photo]
--	select * from [pictre].[Checkin]
--	select * from [pictre].[Tags]

--select * from [pictre].[User]