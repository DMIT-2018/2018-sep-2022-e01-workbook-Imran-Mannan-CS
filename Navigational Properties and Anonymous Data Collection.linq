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

//USING nAVIGATIONAL PROPERTIES AND aNONYMOUS DATA SET (collection)

//reference: Student Notes/Demo/eRestaurant/Linq: Query and Method Syntax

//Find all albums released in the 90's (1990-1999)
//Order the albums by ascending year and then alphabetically by albumtitle
//Display the Year, Title, Artist Name and Release Label

//concerns: a) not all properties of album are to be displayed
//          b) the order of the properties are to be displayed
//              in a different sequence then the defination of the
//             properties on the entity album
//          c) the artist name is not on the Album table BUT is on the Artist Table

//solution: use an anonymous data collection

//the anonymous data instance is defined within the select by
//       declared fields (properties)
//the order of the fields on the new defined instance will be 
//        done in specifying the properties of the anonymous data collection


Albums
    .Where(x => x.ReleaseYear > 1989 && x.ReleaseYear < 2000)
//	.OrderBy(x => x.ReleaseYear)
//	.ThenBy(x => x.Title)
	.Select(x => new
	    {
		  Year = x.ReleaseYear,
		  Title = x.Title,
		  Artist = x.Artist.Name,
		  Label = x.ReleaseLabel
		})
		
	.OrderBy(x => x.Year) //Year is in the anonymous dtat type definition, ReleaseYear is does NOT exist
	.ThenBy(x => x.Title)