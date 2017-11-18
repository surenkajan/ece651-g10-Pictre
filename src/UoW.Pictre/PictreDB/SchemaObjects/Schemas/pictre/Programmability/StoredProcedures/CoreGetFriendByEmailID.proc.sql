USE [Pictre]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[pictre].[CoreGetFriendByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [pictre].[CoreGetFriendByEmailID]
END
GO


CREATE PROCEDURE [pictre].[CoreGetFriendByEmailID] @EmailAddress VARCHAR(240)
As
Begin
 DECLARE @temp TABLE
    (
	ID int,
    FirstName varchar(150),
	LastName varchar(150),
	EmailAddress varchar(240),
    ProfilePhoto image
	
    
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
   insert into @temp   select ID, FirstName,LastName, EmailAddress, ProfilePhoto from [pictre].[User] where ID=  @name

       FETCH NEXT FROM db_cursor INTO @name   
END   
select * from @temp ;
CLOSE db_cursor   
DEALLOCATE db_cursor
END
GO
