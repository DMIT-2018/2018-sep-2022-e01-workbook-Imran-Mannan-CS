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

//Grouping

//when you create a group it builds two (2) components
//a) Key component (deciding criteria value(s)) defining the group
// 	 reference this component using the groupname.Key[.propertyname]
//   1 value for key: groupname.Key
//   n value for key: groupname.Key.propertyname
// (property < - > field < - > attribute < - > value)
//b) data of the groupe (raw instances of the collection)

//ways to gorup
//a) by a single column (field, attribute, property) groupname.Key
//b) by a set of columns (anonymous dataset)         groupname.Key.property
//c) by use an entity (entity name/navproperty)      groupname.Key.property

//concept processing
//start with a "pile" of data (original collection prior to grouping)
//speccify the grouping property(ies)
//results of the group operatio will be to "place the data into smaller piles"

// the piles are dependanton the grouping properties values
// the gouping properties become the Key
// the entire individual instance of the original collection is place in the smaller pile
//manipulate each of the "smaller piles" using your linq commads

//grouping is different then ordering
//Ordering is the final re-sequencing of a collection for display
//grouping re-organizes a collection into separate, usually smaller
//  collections for further processing (ie aggregates)


//grouping is an excellent way to organize your data especially if 
//   you need to process dtat ona a property that is "NOT" a relative key
//   such as a foreign key which forms a "natural" group using the 
//   navigational properties


//Display albums by ReleaseYear
//  this reques tdoeas not need grouping 
//  this is an ordering of output : OrderBy
//  this ordering affect only display
Albums
   .OrderBy(a => a.ReleaseYear)
   
   
//Display albums grouped by ReleaseYear
// explicit request to breakup the display into desired "piles"
Albums
   .GroupBy(a => a.ReleaseYear)
   
//processing on the groups created by the Group command
//Display the number of Albums produced each year
//list only the years which have more than 10 albums
Albums
   .GroupBy(a => a.ReleaseYear)
   //.Where(egP => egP.Count() > 10) //fifltering against each group pile
   .Select(eachgroupPile => new
   {
   		Year = eachgroupPile.Key,
		NumofAlbums = eachgroupPile.Count()
   
   })
   .Where(x => x.NumofAlbums >10)//filtering against the oupt of the .Select() command
   
   
   
// use a multiple ser of properties to form the grop
// included a nested query to report on the small pile group

// Display the grouped by ReleaseLabel, ReleaseYear. Display the 
//ReleaseYear and number of albums. List only tge years with 10 or 
//more albums relased.For each album display the little and release Year


Albums
   .GroupBy(a => new {a.ReleaseLabel, a.ReleaseYear})
   .Where(egP => egP.Count() > 2) //fifltering against each group pile
   .ToList()
   .Select(eachgroupPile => new
   {
   		Label = eachgroupPile.Key.ReleaseLabel,
   		Year = eachgroupPile.Key.ReleaseYear,
		NumofAlbums = eachgroupPile.Count(),
		AlbumItems = eachgroupPile
						.Select(egPInstance => new 
						{
						
							title = egPInstance.Title,
							artist = egPInstance.Artist.Name,
							trackcountA = egPInstance.Tracks.Count(),
							trackcountB = egPInstance.Tracks.Select(x => x).Count(),
							YearOfAlbum = egPInstance.ReleaseYear
						
						})
		
   
   })






















