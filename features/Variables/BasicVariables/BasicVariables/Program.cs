
// strings 

using System.Runtime.CompilerServices;

string firstName = string.Empty;
string lastName = string.Empty;
string filePath = string.Empty;

firstName = "Jason";
lastName = "James";
filePath = @"C:\Dev\MyFolder";

Console.WriteLine($"Welcome {firstName} {lastName}");
Console.WriteLine($@"Files for {firstName} are in the folder C:\Test");

// int
int age = 1;

// double - used most for decimal 
double averageAge = (double)(22 + 43 + 19) / 5;
Console.WriteLine($"Average Age: {averageAge}");

double precisionDouble = 10.0 / 3.0;
Console.WriteLine($"DoublePrecision: {precisionDouble}");

// decimal - more precise than double 
decimal accountBalance;
accountBalance = 1.4M;

decimal precisionDecimal = 10M / 3M;
Console.WriteLine($"DecimalPrecision: {precisionDecimal}");

// bool 
bool isComplete = false;
Console.WriteLine($"IsComplete: {!isComplete}");

// null - lack of value 
int? shoeSize = null;
bool? human = null;
double? shootingPercentage = null;
string? middleName = null;

// type conversions
//Console.WriteLine("What is your age?");
//bool validAge = int.TryParse(Console.ReadLine(), out int personAge);

//Console.WriteLine($"Age is {personAge}");

Assignment2();

void Assignment1()
{
    string firstName = "Bob";
    string lastName = "Jones";
    int age = 32;
    bool isAlive = true;
    string telephoneNumber = "+44 4958938493";
}

void Assignment2()
{
    bool validAge = false;
    int age = 0;

    while (!validAge)
    {
        Console.WriteLine("What is your age?");
        validAge = int.TryParse(Console.ReadLine(), out age);
    }

    if (age > 0)
    {
        var futureAge = age + 25;
        var pastAge = age > 25 ? age - 25 : 0;

        Console.WriteLine($"You are now {age} years old");
        Console.WriteLine($"In 25 years you will be {futureAge}");
        Console.WriteLine($"25 years age you were {pastAge}");
    }
}
