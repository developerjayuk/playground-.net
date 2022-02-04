using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public static class SampleMethods
    {   
        // tuple 
        public static (string firstName, string lastName) GetFullName()
        {
            Console.Write("Please enter your first name: ");
            var firstName = Console.ReadLine();

            Console.Write("Please enter your last name: ");
            var lastName = Console.ReadLine();

            return (firstName, lastName);
        }

        public static string GetUserName()
        {
            Console.Write("Please enter your user name: ");
            return Console.ReadLine();
        }

        public static void ShowWelcomeMessage()
        {
            Console.WriteLine($"Welcome to my app, let's get started....");
        }

        public static void SayHi(string name = "User")
        {
            Console.WriteLine($"Hi {name}!");
        }

        public static void SayGoodbye()
        {
            Console.WriteLine("Goodbye... thanks for using the application :)");
        }
    }
}
