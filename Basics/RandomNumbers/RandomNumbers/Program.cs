using RandomNumbers;

Random random = new();

for (int i = 0; i < 10; i++)
{
    MyMethods.PrintRandomNumber(random);
}

List<string> guestList = new()
{
    "Abigail",
    "Max",
    "Steve",
    "Zeus"
};

var shuffledList = MyMethods.ShuffleList(guestList, random);

foreach (var guest in shuffledList)
{
    Console.WriteLine(guest);
}