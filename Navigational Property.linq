<Query Kind="Expression">
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

//List all albums by release label. Any album with no label
//should be indicated as unknown
//List Title,Label and Artist Name
//Order by ReleaseLabel

//understand the problem
// collection: albums
// selective data: anonymous data set
// label (nullable): either Unknown or Label name *****
//order by the release label field


//design
//Albums
//Select (new{})
//fields: title
//        label ???? ternary operrator (condition(s) ? true value : false value)
//        Artist.Name

//coding and testing
Albums
    .OrderBy(x => x.ReleaseLabel)
    .Select(x => new
	{
	  Title = x.Title,
	  Label = x.ReleaseLabel == null ? "Unknown" : x.ReleaseLabel,
	  Artist = x.Artist.Name
	}
	)


//List all the albums showing the title, Artist Name, YEar and decade of 
// release usung oldies, 70s, 80s, 90s, or modern.
// Order by decade.

//Hint: can you have nested ternary operators? yes

// < 1970
//     oldies
// else
//  ( <1980 then 70's
//  else
//    (< 1990 then 80's
//    else
//      (< 2000 then 90's
//        else
//         modern)))

Albums
    
    .Select(x => new
	{
	  Title = x.Title,
	  Artist = x.Artist.Name,
	  Year = x.ReleaseYear,
	  Decade = x.ReleaseYear < 1970 ? "Oldies" :
	            x.ReleaseYear < 1980 ? "70s" :
				x.ReleaseYear < 1990 ? "80s" :
				x.ReleaseYear < 2000 ? "90s" : "Modern"
	})
	.OrderBy(x => x.Year)