<Query Kind="Expression">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c12aaaaa</ID>
    <NamingService>2</NamingService>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\ChinookDemoDb.sqlite</AttachFileName>
    <DisplayName>Demo database (SQLite)</DisplayName>
    <DriverData>
      <PreserveNumeric1>true</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.Sqlite</EFProvider>
      <MapSQLiteDateTimes>true</MapSQLiteDateTimes>
      <MapSQLiteBooleans>true</MapSQLiteBooleans>
    </DriverData>
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