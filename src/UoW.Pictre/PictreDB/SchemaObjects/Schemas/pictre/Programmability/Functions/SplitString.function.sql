CREATE FUNCTION [pictre].[SplitString] ( @stringToSplit VARCHAR(MAX), @delimeter CHAR(1) )
RETURNS
 @returnList TABLE ([Name] [nvarchar] (500))
AS
BEGIN

 DECLARE @name NVARCHAR(255)
 DECLARE @pos INT

 WHILE CHARINDEX(@delimeter, @stringToSplit) > 0
 BEGIN
  SELECT @pos  = CHARINDEX(@delimeter, @stringToSplit)  
  SELECT @name = SUBSTRING(@stringToSplit, 1, @pos-1)

  INSERT INTO @returnList 
  SELECT @name

  SELECT @stringToSplit = SUBSTRING(@stringToSplit, @pos+1, LEN(@stringToSplit)-@pos)
 END

 INSERT INTO @returnList
 SELECT @stringToSplit

 RETURN
END


--SELECT Name FROM pictre.SplitString('A=1;B=2;C=3;D=4', ';')
--SELECT Name FROM pictre.SplitString('A=1', '=')