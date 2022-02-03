using Microsoft.VisualBasic;

//Assignment1();
//Assignment2();
//Assignment3();
Assignment4();

// do, while
bool isValidAge = false;

do
{
    Console.Write("What is your age?: ");
    string ageText = Console.ReadLine();

    isValidAge = int.TryParse(ageText, out int age);

    if (!isValidAge)
    {
        Console.WriteLine("Invalid age entered, please try again...");
    }
} while (!isValidAge);

// arrays 
string data = "Tim,Bob,Matt,Kevin";
var nameArray = data.Split(',');

Console.WriteLine();

void Assignment1()
{
    var usersAvailable = new string[] { "Tim Jones", "Matt Smith", "Jane Klein" };

    Console.WriteLine($"There are {usersAvailable.Length} users available. " +
                      $"Please select which user you are 1 - {usersAvailable.Length}");

    var userId = int.Parse(Console.ReadLine());

    if (userId > 0 && userId <= usersAvailable.Length)
    {
        Console.WriteLine($"You select user: {usersAvailable[userId - 1]}");
    }
    else
    {
        Console.WriteLine("Invalid user selection. This program will now exit");
        Environment.Exit(0);
    }
}

// lists 
var cars = new List<string>()
{
    "Mercedes",
    "Ford"
};

cars.Add("Ferrari");

// dictionaries
var animals = new Dictionary<string, string>();
animals["tiger"] = "Large cat and great predator";
animals["dog"] = "Domesticated by humans and man's best friend";
animals["fish"] = "King of the seas";

Console.WriteLine($"The definition of a dog is {animals["dog"]}");

void Assignment2()
{
    var users = new Dictionary<string, string>()
    {
        { "ABC001", "Tim Jones" },
        { "ABC002", "Bob Smith" },
        { "ABC003", "Jane Tinnel" },
        { "ABC004", "Mark Hacket" },
    };

    Console.WriteLine("Please enter your user ID (ex. ABC123): ");
    var userId = Console.ReadLine().ToUpper();

    if (users.ContainsKey(userId))
    {
        Console.WriteLine($"User {users[userId]} has been found and logged in.");
    }
    else
    {
        Console.WriteLine($"UserId does not exist!");
    }
}

// for

void Assignment3()
{
    Console.WriteLine("Please enter a list of comma separated names:");
    var csv = Console.ReadLine();

    var names = csv.Replace(" ", "").Split(',');

    for (int i = 0; i < names.Length; i++)
    {
        Console.WriteLine($"Welcome {names[i]}");
    }
}

// foreach
void Assignment4()
{
    var guestList = new List<string>();
    var input = "";

    do
    {
        Console.WriteLine($"There are currently {guestList.Count} names on the guest list.");
        Console.WriteLine("Please enter your name and add it to the list");
        Console.WriteLine("To exit type 'exit'");

        input = Console.ReadLine();

        if (input != "exit" && !string.IsNullOrEmpty(input))
        {
            guestList.Add(input);
        }
    }
    while (input != "exit");

    foreach (var guest in guestList)
    {
        Console.WriteLine($"Guest {guest} is attending.");
    }

}