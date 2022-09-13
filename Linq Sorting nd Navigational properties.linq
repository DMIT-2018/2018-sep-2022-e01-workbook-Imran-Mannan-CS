<Query Kind="Expression">
  <Connection>
    <ID>5b8d0434-fce5-43ce-916f-979224bb6f13</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>WB320-04\SQLEXPRESS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Sorting
// there is a siqnificant difference between query syntax and 
//method syntax

//query syntax is much like sql
// orderby field{[acending]|descending} [,field ...]


// ascending is th edefau;t option


//method syntax is a series of individual methods
// .OrderBy(x => x.field)
// .OrderByDescending(x = x.field)
// .ThenBy(x = > x.field)
// .THneByDescending(x => x.field) each following field

//Find all of the album tracks for the band queen. Order the track by the track name alphabetically



//query syntax method
from x in Tracks
where x.Album.Artist.Name.Contains("Queen")
orderby x.AlbumId, x.Name 
select x


//method syntax
//order of sorting and filter can be intercahnged
Tracks
  .OrderBy(x => x.Album.Title)
  .ThenBy(x => x.Name)
  .Where (x => x.Album.Artist.Name.Contains("Queen"))
  
  
  Tracks
  .OrderBy(x => x.Album.Title)
  .ThenBy(x => x.Name)
  .Where (x => x.Album.Artist.Name.Contains("Queen"))
  
  