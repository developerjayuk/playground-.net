using System;
using DemoLibrary;
using DemoLibrary.Models;

namespace ClassLibraries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonModel person = new();

            Calculations.Add(3.4, 10);

            Console.ReadLine();
        }
    }
}
