
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

void GetPersonDetails()
{
    string firstName = "Bob";
    string lastName = "Jones";
    int age = 32;
    bool isAlive = true;
    string telephoneNumber = "+44 4958938493";
} 