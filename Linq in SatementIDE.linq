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

//the statement ide (development environment)
//this environment expects the use c# statement grammer
//the results of a query is NOT automatically display as in the c# expression environment
//so to display the result you need to .Dump() the variable holding the data result
//IMPORTANT
//.DUMP is a linq pad method. it is not a c# method
//Within the statement environment one can run All the queries
//in one execution

var qsyntaxlist = from arowoncollection in Albums
select arowoncollection;
//qsyntaxlist.Dump();


var msyntaxlist = Albums
   .Select (arowoncollection => arowoncollection)
   .Dump();
   //msyntaxlist.Dump();
   
 var QueenAlbums =  Albums 
     .Where(a => a.Artist.Name.Contains("Queen"))
	// .Dump()
	 ;