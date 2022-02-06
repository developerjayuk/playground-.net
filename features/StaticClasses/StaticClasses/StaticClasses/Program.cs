
using StaticClasses;

string name = RequestData.GetAString("Hi please enter your name: ");

UserMessages.ApplicationStartMessage(name);

double x = RequestData.GetADouble("Please enter your 1st number: ");
double y = RequestData.GetADouble("Please enter your 2nd number: ");

double add = CalculateData.Add(x, y);
double multiply = CalculateData.Multiply(x, y);

UserMessages.PrintResultsMessage($"The addition of {x} and {y} is {add}");
UserMessages.PrintResultsMessage($"The multiplication of {x} and {y} is {multiply}");