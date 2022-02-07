using System;

namespace PropertyTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonModel person = new()
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 78,
                SSN = "123-45-6789"
            };

            Console.WriteLine($"{person.FullName} ({person.SSN})");

            Console.ReadLine();
        }
    }
}
