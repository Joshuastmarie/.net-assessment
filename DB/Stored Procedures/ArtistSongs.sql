CREATE PROCEDURE [dbo].[ArtistSongs]
	@artistId int = -1
AS
select imageURL, song.title, Album.title, song.bpm, song.dateCreation 
	FROM Song
	INNER JOIN Album ON Song.albumID = Album.albumID
	WHERE song.artistID = @artistID
	OR @artistId = -1
RETURN 0
