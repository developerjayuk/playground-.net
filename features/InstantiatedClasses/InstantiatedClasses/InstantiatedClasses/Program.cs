using System;
using System.Collections.Generic;

namespace InstantiatedClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PersonModel> people = new()
            {
                new PersonModel("Tom", "Jones"),
                new PersonModel("Bob", "Smith"),
                new PersonModel("Jane", "Foome"),
            };

            foreach (var person in people)
            {
                Console.WriteLine($"Firstname: {person.FirstName}; Lastname: {person.LastName}; Email: {person.EmailAddress}");   
            }

            Console.ReadLine();
        }
    }
}
