USE Pictre
GO

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'User'
                          AND TABLE_SCHEMA = 'pictre')

BEGIN

CREATE TABLE [pictre].[User]
(
	ID						int IDENTITY(1,1),
	UserName				VARCHAR(50),
	FirstName				VARCHAR(150) NOT NULL,
	LastName				VARCHAR(150),
	FullName				VARCHAR(240),
	EmailAddress			VARCHAR(240) NOT NULL,
	DateOfBirth				DATETIME NOT NULL,
	Sex						VARCHAR(30) NOT NULL,
	ProfilePhoto    image,
CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

END

--INSERT INTO [pictre].[User] (UserName, FirstName, LastName, FullName, EmailAddress, DateOfBirth, Sex)
--VALUES ('surenkajan', 'Kajaruban', 'Surendran', 'Kajaruban Surendran', 'surenkajan@gmail.com', '19931118 10:34:09 AM', 'Male');

--INSERT INTO [pictre].[User] (UserName, FirstName, LastName, FullName, EmailAddress, DateOfBirth, Sex)
--VALUES ('rindha', 'Brindha', 'G', 'Brindha G', 'brindha@gmail.com', '19931118 10:34:09 AM', 'Female');

--INSERT INTO [pictre].[User] (UserName, FirstName, LastName, FullName, EmailAddress, DateOfBirth, Sex)
--VALUES ('enlil', 'Enlil', 'Tom', 'Enlil TOm', 'Enlil@gmail.com', '19931118 10:34:09 AM', 'Female');

--INSERT INTO [pictre].[User] (UserName, FirstName, LastName, FullName, EmailAddress, DateOfBirth, Sex)
--VALUES ('shitij', 'Shitij', 'V', 'Shitij V', 'Shitij@gmail.com', '19931118 10:34:09 AM', 'Male');

--INSERT INTO [pictre].[User] (UserName, FirstName, LastName, FullName, EmailAddress, DateOfBirth, Sex)
--VALUES ('jaspreet', 'Jaspreet', 'S', 'Jaspreet S', 'jaspreet@gmail.com', '19931118 10:34:09 AM', 'Male');
