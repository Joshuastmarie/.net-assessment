CREATE PROCEDURE dbo.GetArtistDetails
	@artistID INT = -1
AS
BEGIN
	SELECT *
	FROM Artist
	WHERE
		@artistID = -1 OR
		artistID = @artistID
END