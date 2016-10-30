CREATE PROCEDURE usp_GetTownsStartingWith
  @StartingString NVARCHAR(MAX)
AS
BEGIN
SELECT t.Name
AS Town
FROM Towns t
WHERE t.Name LIKE @StartingString+'%';
END;