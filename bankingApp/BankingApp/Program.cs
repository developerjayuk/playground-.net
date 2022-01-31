Console.WriteLine("***** WELCOME TO THIS BANKING APP *****");
Console.WriteLine("::Login Page::");

var authenticated = false;
var logInAttemptsRemaining = 3;

while (!authenticated && logInAttemptsRemaining > 0)
{
    authenticated = UserLogin();

    if (!authenticated)
    {
        logInAttemptsRemaining--;
        Console.WriteLine($"Invalid username or password! You have {logInAttemptsRemaining} attempts left ");
    }
}

if (authenticated)
{
    MainMenu();
}

// exit code 
ExitApp();

#region Authentication

bool UserLogin()
{
    // variables for credentials
    var userName = "";
    var password = "";

    // get username
    Console.Write("Username:");
    userName = Console.ReadLine();

    if (!string.IsNullOrEmpty(userName))
    {
        // get password
        Console.Write("Password:");
        password = Console.ReadLine();
    }

    return (userName == "system" && password == "123");
}
#endregion

#region Menuoptions

void MainMenu()
{
    int menuChoice = -1;

    do
    {
        Console.WriteLine(":::Main Menu:::");
        Console.WriteLine("1. Customers");
        Console.WriteLine("2. Accounts");
        Console.WriteLine("3. Funds Transfer");
        Console.WriteLine("4. Funds Transfer Statement");
        Console.WriteLine("5. Account Statement");
        Console.WriteLine("0. Exit");

        Console.WriteLine($"Enter your required service");
        menuChoice = Convert.ToInt32(Console.ReadLine());

        switch (menuChoice)
        {
            case 1:
                CustomersMenu();
                break;
            case 2:
                AccountsMenu();
                break;
            case 3:
                FundsTransfer();
                break;
            case 4:
                FundsTransferStatement();
                break;
            case 5:
                AccountStatement();
                break;
        }
    } while (menuChoice != 0);
}

void CustomersMenu()
{
    var menuChoice = -1;

    do
    {
        Console.WriteLine("::::Customer's Menu::::");
        Console.WriteLine("1. Add Customer");
        Console.WriteLine("2. Delete Customer");
        Console.WriteLine("3. Update Customer");
        Console.WriteLine("4. View Customer");
        Console.WriteLine("0. Exit");

        Console.WriteLine($"Enter your required service");
        menuChoice = Convert.ToInt32(Console.ReadLine());

        switch (menuChoice)
        {
            case 1:
                
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;

        }
    } while (menuChoice != 0);
}

void AccountsMenu()
{
    var menuChoice = -1;

    do
    {
        Console.WriteLine("::::Accounts Menu::::");
        Console.WriteLine("1. Add Account");
        Console.WriteLine("2. Delete Account");
        Console.WriteLine("3. Update Account");
        Console.WriteLine("4. View Account");
        Console.WriteLine("0. Exit");

        Console.WriteLine($"Enter your required service");
        menuChoice = Convert.ToInt32(Console.ReadLine());

        switch (menuChoice)
        {
            case 1:

                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;

        }
    } while (menuChoice != 0);
}

void FundsTransfer()
{

}

void FundsTransferStatement()
{

}

void AccountStatement()
{

}
#endregion


// function to close app when finished
void ExitApp(int timeOut = 3)
{
    Console.WriteLine($"Your session will end in {timeOut} seconds");

    for (var i = timeOut; i > 0; i--)
    {
        Thread.Sleep(1000);
        Console.Write($"{i}...");
    }
}