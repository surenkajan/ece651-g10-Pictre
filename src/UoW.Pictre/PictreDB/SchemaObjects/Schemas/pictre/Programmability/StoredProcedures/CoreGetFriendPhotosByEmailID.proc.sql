USE [Pictre]
GO
/****** Object:  StoredProcedure [pictre].[CoreGetFriendPhotosByEmailID]    Script Date: 17-Nov-17 5:12:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [pictre].[CoreGetFriendPhotosByEmailID] @EmailAddress VARCHAR(240)
As
Begin
 DECLARE @temp TABLE
    (
	UserId int,
    FirstName varchar(150),
	LastName varchar(150),
	EmailAddress varchar(240),
    ProfilePhoto image,
	PhotoDescription text,
	UploadTimeStamp datetime,
	ActualPhoto image,
	Tags text,
	CheckinLocation varchar(45) , 
	PhotoID int
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
   insert into @temp   select u.ID,u.FirstName,u.LastName, u.EmailAddress, u.ProfilePhoto, p.PhotoDescription, p.UploadTimeStamp, p.ActualPhoto,
   stuff(
        (select ', ' + CONCAT(u1.FirstName, ' ', u1.LastName) from [pictre].[Tags] t inner join [pictre].[User] u1 on t.UserID = u1.ID
         where p.ID = t.PhotoID for xml path('')),
        1, 2, ''
    ) Tags, c.Location,p.ID
     from ([pictre].[Photo] p inner join [pictre].[User] u on u.ID = p.UserID) left outer join [Pictre].[Checkin] c on c.PhotoID = p.ID where u.ID=  @name

       FETCH NEXT FROM db_cursor INTO @name   
END   
select * from @temp order by UploadTimeStamp desc;
CLOSE db_cursor   
DEALLOCATE db_cursor
END

