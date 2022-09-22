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
	//Conversions
	//collection we will look at are Iqueryable, Ienumerable and List
	
	//Display all albums their tracks. Display the album title
	//artists name and album tracks. For each track show the song name
	//and play time. Show only albums with 25 or more tracks.
	
	
	List<AlbumTracks> albumlist = Albums
					.Where (a => a.Tracks.Count >= 25)
					.Select( a => new AlbumTracks
					{
						Title = a.Title,
						Artist = a.Artist.Name,
						Songs = a.Tracks
								.Select(tr => new SongItem
								{
									Song = tr.Name,
									Playtime = tr.Milliseconds/1000.0
								
								})
								.ToList()
					
					
					})
					.ToList()
					.Dump()
					;
					
					
//Using .FirstorDefault()
//first saw in CPSC1517 when check to see if a record existed in a Bll Service Method

//Find the first album by deep Purple
var artistparam = "Deep Purpple";
var resultsFOD = Albums
				.Where(a => a.Artist.Name.Equals(artistparam))
				.Select(a => a)
				.OrderBy(a => a.ReleaseYear)
				.FirstOrDefault()
				//.Dump()
				;
if (resultsFOD != null)
{
	resultsFOD.Dump();
}
else
{
	Console.WriteLine($"No albums found for artist {artistparam}");

}

//Distinct()
//remove duplicate reported lines
//Get a list of customer countries
var resultsDistinct = Customers
						.OrderBy(c => c.Country)
						.Select(c => c.Country)
						.Distinct()
						.Dump()
						;
//.Take() and .Skip()
//in CPSC1517 when you wanted to use the supplied Paginator
//the query method was to return ONLY the need 
//records for the display NOT the entire collection
//a) the query was executed returning a collection of size x
//b) obtained the total count (x) of return records
//c) clculated the number of records to skip (pagenumber - 1) * pagesize
//d) on the return method statement you used
//    return variablename.Skip(rowsSkipped).Take(pagesize).ToList()

//Union
//rules in linq are the same as sql
//result is the same as sql, combine separate collections into one.
//syntax (queryA).Union(queryB)[.Union(query....)]
//rules:
//number of columns the same
//columns datatypes must be the same
//ordering should be done as a method after
var resultsunionA =( Albums
					.Where(x => x.Tracks.Count() == 0)
					.Select(x => new 
					{
						title = x.Title,
						totalTracks = 0,
						totalCost = 0.00m,
						averageLength = 0.00
					})
					)
					.OrderBy(x => x.totalTracks)
					
					
			.Union( Albums
					.Where(x => x.Tracks.Count() > 0)
					.Select(x => new 
					{
						title = x.Title,
						totalTracks = x.Tracks.Count(),
						totalCost = x.Tracks.Sum(tr => tr.UnitPrice),
						averageLength = x.Tracks.Average(tr => tr.Milliseconds)
					})
			
					.OrderBy(x => x.totalTracks)
					.Dump())
					;
}

public class SongItem
{
	public string Song{get;set;}
	public double Playtime{get;set;}
	 
}

public class AlbumTracks
{
	public string Title{get;set;}
	public string Artist{get;set;}
	public List<SongItem> Songs{get;set;}
}

// You can define other methods, fields, classes and namespaces here