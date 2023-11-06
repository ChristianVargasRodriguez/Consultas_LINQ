List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}


Console.WriteLine("-----------------------");
Console.WriteLine("-----------------------");
Console.WriteLine("------------1-----------");
Console.WriteLine("---Use LINQ to find the first eruption that is in Chile and print the result.---");

Eruption firstEruptionInChile = eruptions.FirstOrDefault(e => e.Location == "Chile");

if (firstEruptionInChile != null){
    Console.WriteLine("First eruption in Chile:");
    Console.WriteLine(firstEruptionInChile.ToString());
} else {
    Console.WriteLine("No eruption in Chile.");
}


Console.WriteLine("------------2-----------");
Console.WriteLine("---Find the first eruption from the 'Hawaiian Is' location and print it. If none is found, print 'No Hawaiian Is Eruption found.'---");

Eruption firstEruptionInHawaiianIs = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");

if (firstEruptionInHawaiianIs != null){
    Console.WriteLine("First eruption in 'Hawaiian Is':");
    Console.WriteLine(firstEruptionInHawaiianIs.ToString());
} else {
    Console.WriteLine("No 'Hawaiian Is' Eruption found.");
}

Console.WriteLine("------------3-----------");
Console.WriteLine("---Find the first eruption that is after the year 1900 AND in 'New Zealand', then print it.---");

Eruption firstEruptionInNewZealandAfter1900 = eruptions.FirstOrDefault(e => e.Year > 1900 && e.Location == "New Zealand");

if (firstEruptionInNewZealandAfter1900 != null){
    Console.WriteLine("First eruption in New Zealand after 1900:");
    Console.WriteLine(firstEruptionInNewZealandAfter1900.ToString());
} else {
    Console.WriteLine("No eruption in New Zealand after 1900 was found.");
}

Console.WriteLine("------------4-----------");
Console.WriteLine("---Find all eruptions where the volcano's elevation is over 2000m and print them.---");

IEnumerable<Eruption> highElevationEruptions = eruptions.Where(e => e.ElevationInMeters > 2000);

if (highElevationEruptions.Any()){
    Console.WriteLine("Eruptions with elevation over 2000 meters:");
    PrintEach(highElevationEruptions);
} else {
    Console.WriteLine("No eruptions with elevation over 2000 meters were found.");
}

Console.WriteLine("------------5-----------");
Console.WriteLine("---Find all eruptions where the volcano's name starts with 'L' and print them. Also print the number of eruptions found.---");

IEnumerable<Eruption> eruptionsStartingWithL = eruptions.Where(e => e.Volcano.StartsWith("L"));
int count = eruptionsStartingWithL.Count();

if (count > 0){
    Console.WriteLine($"Eruptions with volcano names starting with 'L' (Count: {count}):");
    PrintEach(eruptionsStartingWithL);
} else {
    Console.WriteLine("No eruptions with volcano names starting with 'L' were found.");
}


Console.WriteLine("------------6-----------");
Console.WriteLine("---Find the highest elevation, and print only that integer---");

int highestElevation = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine("Highest elevation: " + highestElevation);


Console.WriteLine("------------7-----------");
Console.WriteLine("---Use the highest elevation variable to find and print the name of the Volcano with that elevation.---");

var highestElevationEruptions = eruptions.Where(e => e.ElevationInMeters == highestElevation);

if (highestElevationEruptions.Any()){
    Console.WriteLine("Volcanoes with the highest elevation:");
    foreach (var eruption in highestElevationEruptions){
        Console.WriteLine(eruption.Volcano);
    }
} else {
    Console.WriteLine("No eruptions with the highest elevation were found.");
}

Console.WriteLine("------------8-----------");
Console.WriteLine("---Print all Volcano names alphabetically.---");

var eruptionsOrderedByName = eruptions.OrderBy(e => e.Volcano);

Console.WriteLine("Volcano names alphabetically:");
foreach (var eruption in eruptionsOrderedByName){
    Console.WriteLine(eruption.Volcano);
}

Console.WriteLine("------------9-----------");
Console.WriteLine("---Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.---");

var eruptionsBefore1000CE = eruptions.Where(e => e.Year < 1000);
var eruptionsOrderedByNameBefore1000CE = eruptionsBefore1000CE.OrderBy(e => e.Volcano);

Console.WriteLine("Eruptions that happened before 1000 CE, ordered alphabetically by Volcano name:");
foreach (var eruption in eruptionsOrderedByNameBefore1000CE){
    Console.WriteLine(eruption.ToString());
}

Console.WriteLine("------------10-----------");
Console.WriteLine("---Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.---");

var volcanoNamesBefore1000CE = eruptionsBefore1000CE.Select(e => e.Volcano);
var sortedVolcanoNames = volcanoNamesBefore1000CE.OrderBy(name => name);

Console.WriteLine("Volcano names of eruptions that happened before 1000 CE, ordered alphabetically:");
foreach (var volcanoName in sortedVolcanoNames){
    Console.WriteLine(volcanoName);
}
