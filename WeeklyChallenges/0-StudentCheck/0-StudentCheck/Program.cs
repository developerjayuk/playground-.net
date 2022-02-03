

Console.WriteLine("Hello there please confirm your identity below:");


// ask use for their first name and age
Console.Write("Please enter your Firstname: ");
var firstName = Console.ReadLine();

Console.Write("Please enter your Age: ");
if (int.TryParse(Console.ReadLine(), out var age) == false)
{
    Console.WriteLine("Invalid age provided, please start the app again.");
    return;
}

var greeting = firstName;

// if name is bob or sue address them as professor
if (firstName?.ToLower() == "bob" || firstName?.ToLower() == "sue")
{
    greeting = $"Professor {firstName}";
}

// if the person is under 21 recommend they wait x years to start class
if (age < 21)
{
    Console.WriteLine($"{greeting}, we see that you are under 21, " +
                      $"we recommend that you wait {21 - age} years before you start classes.");
}
else
{
    Console.WriteLine($"Welcome {greeting}, let's get started.");
}
