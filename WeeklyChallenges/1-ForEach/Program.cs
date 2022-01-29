//var names = new List<string>
//{
//    "Dave Smith",
//    "Judith Graham"
//};

var guestList = new List<Person>()
{
    new Person
    {
        FirstName = "Dave",
        LastName = "Jones"
    },
    new Person
    {
        FirstName = "Chris",
        LastName = "Smith"
    },
};

guestList.Add(new Person { FirstName = "Sylvester", LastName = "James" });

foreach (var person in guestList)
{
    Console.WriteLine($"FirstName: {person.FirstName}");
    Console.WriteLine($"LastName: {person.LastName}");
    Console.WriteLine("------------------------------");
}