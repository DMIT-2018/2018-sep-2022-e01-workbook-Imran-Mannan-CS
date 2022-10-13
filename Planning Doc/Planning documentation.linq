<Query Kind="Program">
  <Connection>
    <ID>0578df4e-ab61-418b-8908-6017e5059862</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>.\SQLEXPRESS</Server>
    <Database>Chinook</Database>
    <DisplayName>Chinook-Entity</DisplayName>
    <DriverData>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	#region CQRS Queries
	string searching = "Deep";
	   string searchby = "Artist";
	   List<TrackSelection> tracklist = Track_FetchTracksBy(searcharg, searchby);
	   tracklist.Dump();
	#endregion
	
	
	#region TrackServices class
	
	public List<TrackSelection>Track_FetchTracksBy(string searcharg, string searchby)
	{
		if (string.IsNullOrWhiteSpace(searcharg))
		{
		   throw new ArgumentNullException("No search value submitted");
		
		}
		if (string.IsNullOrWhiteSpace(searchby))
		{
		   throw new ArgumentNullException("No search style submitted");
		
		}
		IEnumerable<TrackSelection> results = Tracks
		                           .Where(x => (x.Album.Artist.Name.Contains(searcharg) &&
								               searchby.Equals("Artist")) ||
											   (x.Album.Title.Contains(searcharg) &&
								               searchby.Equals("Artist")))
									.Select(x => new TrackSelection
									       {
										   		TrackId = x.TrackId,
												SongName = x.Name,
												AlbumTitle = x.Album.Title,
												ArtistName = x.Album.Artist.Name,
												
										   
										   
										   }
	
	}
}

public class TrackSelection
{
    public int TrackId {get; set;}
    public string SongName {get; set;}
    public string AlbumTitle{get; set;}
    public string ArtistName{get; set;}
    public int Milliseconds {get; set;}
    public decimal Price {get; set;}
}
public class PlaylistTrackInfo 
{
    public int TrackId {get; set;}
    public int TrackNumber {get; set;}
    public string SongName {get; set;}
    public int Milliseconds {get; set;}
}
#endregion
