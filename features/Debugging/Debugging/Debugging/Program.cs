// See https://aka.ms/new-console-template for more information

var total = 0;
var test = 0;

//for (var i = 0; i < 100; i++)
//{
//    total += 5;
//}

for (int i = -100; i < 100; i++)
{
    total += 5;
    test = total / i;

    Console.WriteLine(total);

}
