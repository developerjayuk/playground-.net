//BasicIf();

//MoreAdvancedIf();

Switch();


void Basic()
{
    bool isComplete = false;

    if (isComplete)
    {
        Console.WriteLine($"The statement is {isComplete}");
    }
    else
    {
        Console.WriteLine($"The statement is {isComplete}");
    }

    Console.WriteLine("Please enter your dog's name?");
    var dogName = Console.ReadLine();

    if (dogName.ToLower() == "jerry")
    {
        Console.WriteLine("Welcome we have confirmed you are the correct owner!!");
    }
}

void MoreAdvancedIf()
{
    Console.Write("What is your first name: ");
    string firstName = Console.ReadLine();

    Console.Write("What is your last name: ");
    string lastName = Console.ReadLine();

    if (firstName.ToLower() == "jimbo" && lastName.ToLower() == "jones")
    {
        Console.WriteLine("Welcome Mr Admin!");
    }
    else if (lastName.ToLower() == "jones")
    {
        Console.WriteLine("are you related to the Admin? y/n");
        bool related = Console.ReadLine() == "y" ? true : false;

        if (!related)
        {
            Console.WriteLine("Sorry only family members are allowed access to this app.");
        }
    }
}

void Switch()
{
    var firstName = "Jason";
    var greeting = "";

    switch (firstName.ToLower())
    {
        case "jason":
            greeting = "admin";
            break;
        case "bob":
            greeting = "moderator";
            break;
        default:
            greeting = "basic";
            break;
    }

    Console.WriteLine($"Welcome {greeting} user");
}

Console.WriteLine("this is the end of the app");
