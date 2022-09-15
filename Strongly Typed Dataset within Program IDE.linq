<Query Kind="Program">
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

void Main()
{
    //pretend that main is a web page
	//fIND SONGS BY PARTIAL SONG NAME
	//display the album title, song, artist name
	//order by song.
	
	//assume a value was entered in to the web page
	//assume that a post button was pressed
	//assume Main() is the OnPost event
	
	string inputvalue = "dance";
	List<SongList> songCollection = SongsByPartialName(inputvalue);
	songCollection.Dump(); //assume is the web page display
}

// You can define other methods, fields, classes and namespaces here


//C# really enjoys strongly typed data fields
// whether these fields are primitive data types (int, double, ...)
//Or developer defined datatypes (class)


public class SongList
{ 
    public string Album{get;set;}
	public string Song{get;set;}
	public string Artist{get;set;}
}


//imagine the following method exists in a service in your BLL
//this method receives the web page parameter fot the query
//this method will need to return a collection

List<SongList> SongsByPartialName(string partialSongName)
{

   var songCollection = Tracks
	                        .Where(t => t.Name.Contains("dance"))
							.OrderBy(t => t.Name)
							.Select(t => new SongList
							{  
							
							   Album = t.Album.Title,
							   Song = t.Name,
							   Artist = t.Album.Artist.Name
							
							
							});
	return songCollection.ToList();

}