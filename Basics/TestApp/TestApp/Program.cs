
// Welcome the user to the app
Console.WriteLine("Hello there stranger and welcome to this application!");
Console.WriteLine("-----------------------------------\n");

// Ask for the firstname
var firstName = "";

while (firstName == "")
{
    Console.Write("What is your name friend?: ");
    firstName = Console.ReadLine();
}

// Greet user by name
Console.WriteLine($"Hi {firstName}, let's get to know each other !");