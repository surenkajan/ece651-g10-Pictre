USE [Pictre]
GO

IF NOT EXISTS (
SELECT  schema_name
FROM    information_schema.schemata
WHERE   schema_name = 'pictre' ) 

BEGIN
EXEC sp_executesql N'CREATE SCHEMA pictre'
END

GO