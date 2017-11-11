USE Pictre
GO

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Friends'
                          AND TABLE_SCHEMA = 'pictre')

BEGIN

CREATE TABLE [pictre].[Friends]
(
	ID						int,
	FriendID				int
	
CONSTRAINT FK_USER_ID FOREIGN KEY (ID) REFERENCES [pictre].[User] (ID) ON DELETE CASCADE,
CONSTRAINT FK_FRIEND_ID FOREIGN KEY (FriendID) REFERENCES [pictre].[User] (ID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Photo'
                          AND TABLE_SCHEMA = 'pictre')

BEGIN

CREATE TABLE [pictre].[Photo]
(
	ID						int IDENTITY(1,1),
	UserID				int,
	PhotoDescription     text,
	UploadTimeStamp    datetime,
	ActualPhoto    image,
	
CONSTRAINT FK_USER_PHOTO FOREIGN KEY (UserID) REFERENCES [pictre].[User] (ID) ON DELETE CASCADE,
CONSTRAINT PK_PHOTO_ID PRIMARY KEY CLUSTERED (ID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Tags'
                          AND TABLE_SCHEMA = 'pictre')

BEGIN

CREATE TABLE [pictre].[Tags]
(
	UserID						int,
	PhotoID				int
	
CONSTRAINT FK_USER_TAGS FOREIGN KEY (UserID) REFERENCES [pictre].[User] (ID) ON DELETE CASCADE,
CONSTRAINT FK_PHOTO_TAGS FOREIGN KEY (PhotoID) REFERENCES [pictre].[Photo] (ID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'SecurityQuestion'
                          AND TABLE_SCHEMA = 'pictre')

BEGIN

CREATE TABLE [pictre].[SecurityQuestion]
(
	ID						int IDENTITY(1,1),
	Question				VARCHAR(45),
	
CONSTRAINT PK_QUESTION_ID PRIMARY KEY CLUSTERED (ID)

)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'UserSecurity'
                          AND TABLE_SCHEMA = 'pictre')

BEGIN

CREATE TABLE [pictre].[UserSecurity]
(
	UserID						int,
	QuestionID				int,
	Answer					text,
	
CONSTRAINT FK_USER_USERSECURITY FOREIGN KEY (UserID) REFERENCES [pictre].[User] (ID) ON DELETE CASCADE,
CONSTRAINT FK_SECURITYQUESTION_USERSECURITY FOREIGN KEY (QuestionID) REFERENCES [pictre].[SecurityQuestion] (ID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Checkin'
                          AND TABLE_SCHEMA = 'pictre')

BEGIN

CREATE TABLE [pictre].[Checkin]
(
	UserID						int,
	PhotoID				int,
	Location					VARCHAR(45),
	CheckInTime             datetime,
	
CONSTRAINT FK_USER_CHECKIN FOREIGN KEY (UserID) REFERENCES [pictre].[User] (ID) ON DELETE CASCADE,
CONSTRAINT FK_PHOTO_CHECKIN FOREIGN KEY (PhotoID) REFERENCES [pictre].[Photo] (ID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Comments'
                          AND TABLE_SCHEMA = 'pictre')

BEGIN

CREATE TABLE [pictre].[Comments]
(
	UserID						int,
	PhotoID				int,
	Comment					text,
	CommentTime             datetime,

	
CONSTRAINT FK_USER_COMMENTS FOREIGN KEY (UserID) REFERENCES [pictre].[User] (ID) ON DELETE CASCADE,
CONSTRAINT FK_PHOTO_COMMENTS FOREIGN KEY (PhotoID) REFERENCES [pictre].[Photo] (ID)
)

END


IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Likes'
                          AND TABLE_SCHEMA = 'pictre')

BEGIN

CREATE TABLE [pictre].[Likes]
(
	UserID						int,
	PhotoID				int
	
CONSTRAINT FK_USER_LIKES FOREIGN KEY (UserID) REFERENCES [pictre].[User] (ID) ON DELETE CASCADE,
CONSTRAINT FK_PHOTO_LIKES FOREIGN KEY (PhotoID) REFERENCES [pictre].[Photo] (ID)
)

END