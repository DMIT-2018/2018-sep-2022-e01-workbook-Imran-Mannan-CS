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

Albums

// query syntax to list all records ina an entity (Table, collection)

from arowoncollection in Albums
select arowoncollection

// method syntax to list all entiites

Albums
   .Select (arowoncollection => arowoncollection)

//Where
//filter method
//the condition as you would in c#
//beware the Linqpad my NOT like the c# syntax (DateTime)
//beware that Linq is converted to sql which may not like certain C3 syntax because sql could not convert

//syntax
//notice the method syntax makes use of the Lambda expressions
// Lambdas are common when performing Linq with tthe method syntax
//.Where(Lambda expression)
//.Where( x => condition [logical operator condition2...])
//.Where(x => Bytes > 350000)


Tracks
     .Where(x => x.Bytes > 700000000)
	 
from x in Tracks
where x.Bytes > 700000000
select x

//Find all the albums ogf the artist Queen.
//concerns: the artist name is in another table in an sql Select you would be using an inner join in Linq you do not need to specific your inner join instead use the "navigationanl properties" of your entity to generate the relationship

Albums 
     .Where(a => a.Artist.Name.Contains("Queen"))