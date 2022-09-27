<Query Kind="Statements">
  <Connection>
    <ID>f41a4251-63ff-4e66-bdc1-d9a028ef2933</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>WC320-04\SQLEXPRESS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Any and All
//these filter tests return a true or false condition
//they work at the complete connection level

//Genres.Count().Dump();
//25

//show genres that have tracks which are not on any playlist
Genres
	.Where(g => g.Tracks.Any(tr => tr.PlaylistTracks.Count() == 0))
	.Select(g => g)
	//.Dump()
	;
	
//show genres that have all their track appearing at least once
// on a playlist
Genres
	.Where(g => g.Tracks.All(tr => tr.PlaylistTracks.Count() > 0))
	.Select(g => g)
	.Dump()
	;
	
//there maybe times that using a !Any() -> All(!relationship
//      and !All -> Any(!relationship)

//Using All and Any in comparing 2 collections
//if your collection is NOT a complex record there is a linq method
//  called .Except that can be used to solve your query


// Compare the track collection of two people using all and any
// roberto almeida and Michelle Brooks


var almeida = PlaylistTracks
						.Where(x => x.Playlist.UserName.Contains("AlmeidaR"))
						.Select(x => new
						{
							song = x.Track.Name,
							genre = x.Track.Genre.Name,
							id = x.TrackId,
							artist = x.Track.Album.Artist.Name
						
						})
						.Distinct()
						.OrderBy(x => x.song)
						//.Dump() //110
						;
						
						
var brooks = PlaylistTracks
						.Where(x => x.Playlist.UserName.Contains("BrooksM"))
						.Select(x => new
						{
							song = x.Track.Name,
							genre = x.Track.Genre.Name,
							id = x.TrackId,
							artist = x.Track.Album.Artist.Name
						
						})
						.Distinct()
						.OrderBy(x => x.song)
						//.Dump() //110
						;
						
//List the tracks that BOTH Roberto and Michelle like.
//Compare 3 datasets together, data in listA that is also in listB
//Assume list a is roberto and list b is Michele
//listA is what you wish to report from
//listB is what you wish to compare to 

//What songs doeas Roberto like but not Michelle
var c1 = almeida
		.Where(rob => !brooks.Any(mic => mic.id == rob.id))
		.OrderBy(rob => rob.song)
		//.Dump()
		;
var c2 = almeida
		.Where(rob => brooks.All(mic => mic.id != rob.id))
		.OrderBy(rob => rob.song)
		//.Dump()
		;
var c3 = brooks
		 .Where(mic => almeida.All(rob => rob.id != mic.id))
		 .OrderBy(mic => mic.song)
		// .Dump()
		 ;
		
//What songs does not michelle roberto like
var c4 = brooks
			.Where(mic => almeida.Any(rob => rob.id == mic.id))
			.OrderBy(mic => mic.song)
			.Dump()
			;
		
		
		
		
		