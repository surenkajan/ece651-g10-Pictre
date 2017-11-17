USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreGetFriendPhotosByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreGetFriendPhotosByEmailID]
END
GO


CREATE PROCEDURE [pictre].[CoreGetFriendPhotosByEmailID] @EmailAddress VARCHAR(240)
As
Begin
 DECLARE @temp TABLE
    (
    FirstName varchar(150),
	LastName varchar(150),
	EmailAddress varchar(240),
    ProfilePhoto image,
	PhotoDescription text,
	UploadTimeStamp datetime,
	ActualPhoto image,
	Tags text    
    )
 DECLARE 
 @name VARCHAR(50)
	

 DECLARE db_cursor CURSOR FOR  
SELECT FriendID 
FROM [pictre].[Friends] 
WHERE ID  IN (select ID from [pictre].[User] where EmailAddress =@EmailAddress)  

OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @name   

WHILE @@FETCH_STATUS = 0   
BEGIN   
   insert into @temp   select u.FirstName,u.LastName, u.EmailAddress, u.ProfilePhoto, p.PhotoDescription, p.UploadTimeStamp, p.ActualPhoto,
   stuff(
        (select ', ' + CONCAT(u1.FirstName, ' ', u1.LastName) from [pictre].[Tags] t inner join [pictre].[User] u1 on t.UserID = u1.ID
         where p.ID = t.PhotoID for xml path('')),
        1, 2, ''
    ) Tags
     from [pictre].[Photo] p inner join [pictre].[User] u on u.ID = p.UserID where u.ID=  @name

       FETCH NEXT FROM db_cursor INTO @name   
END   
select * from @temp order by UploadTimeStamp desc;
CLOSE db_cursor   
DEALLOCATE db_cursor
END
GO

--Insert Into [pictre].[Photo](UserID, PhotoDescription,UploadTimeStamp,ActualPhoto)
--Select 3, 'very nice pic', CURRENT_TIMESTAMP, BulkColumn 
--from Openrowset (Bulk 'C:\Users\SHITIJ\Desktop\map_marker.png', Single_Blob) as Image