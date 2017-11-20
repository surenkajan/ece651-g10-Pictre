USE [Pictre]
GO
/****** Object:  StoredProcedure [pictre].[CoreGetPhotosByEmailID]    Script Date: 17-Nov-17 4:59:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [pictre].[CoreGetPhotosByEmailID] @EmailAddress VARCHAR(240)
As
Begin
 DECLARE @temp TABLE
    (
	PhotoDescription text,
	UploadTimeStamp datetime,
	ActualPhoto image,
	Tags text  ,
	CheckinLocation varchar(45) ,
	FirstName varchar(50),
	ProfilePhoto image,
	photoId int
    )
 DECLARE 
 @name VARCHAR(50)
	

 DECLARE db_cursor CURSOR FOR  
SELECT ID  
FROM [pictre].[Photo] 
WHERE UserID  IN (select ID from [pictre].[User] where EmailAddress =@EmailAddress)  

OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @name   

WHILE @@FETCH_STATUS = 0   
BEGIN   
   insert into @temp   select p.PhotoDescription, p.UploadTimeStamp, p.ActualPhoto,
   stuff(
        (select ', ' + CONCAT(u1.FirstName, ' ', u1.LastName) from [pictre].[Tags] t inner join [pictre].[User] u1 on t.UserID = u1.ID
         where p.ID = t.PhotoID for xml path('')),
        1, 2, ''
    ) Tags, c.Location,a.FirstName,a.ProfilePhoto,p.ID from (select FirstName,ProfilePhoto from [pictre].[User] where EmailAddress =@EmailAddress) a,
      [pictre].[Photo] p left outer join [Pictre].Checkin c on c.PhotoID = p.ID where p.ID=  @name

       FETCH NEXT FROM db_cursor INTO @name   
END   
select * from @temp order by UploadTimeStamp desc;
CLOSE db_cursor   
DEALLOCATE db_cursor
END


--exec [pictre].[CoreGetPhotosByEmailID] @EmailAddress ='enlil@gmail.com'
--select * from [pictre].[Photo]