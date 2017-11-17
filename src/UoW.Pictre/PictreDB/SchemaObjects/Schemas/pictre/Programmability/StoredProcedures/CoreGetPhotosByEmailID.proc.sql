USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreGetPhotosByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreGetPhotosByEmailID]
END
GO


CREATE PROCEDURE [pictre].[CoreGetPhotosByEmailID] @EmailAddress VARCHAR(240)
As
Begin
 DECLARE @temp TABLE
    (
	PhotoDescription text,
	UploadTimeStamp datetime,
	ActualPhoto image,
	Tags text  ,
	CheckinLocation varchar(45)   
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
    ) Tags,d.CheckinLocation
	 from  (Select c.Location as CheckinLocation from [pictre].[Checkin] c where c.PhotoID = @name) d,
      [pictre].[Photo] p where p.ID=  @name

       FETCH NEXT FROM db_cursor INTO @name   
END   
select * from @temp order by UploadTimeStamp desc;
CLOSE db_cursor   
DEALLOCATE db_cursor
END
GO