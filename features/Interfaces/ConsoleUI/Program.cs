using DemoLibrary;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IProductModel> cart = AddSampleData();
            CustomerModel customer = GetCustomer();

            foreach (IProductModel prod in cart)
            {
                prod.ShipItem(customer);

                if (prod is DigitalProductModel digitalProduct)
                {
                    Console.WriteLine($" - {prod.Title} has {digitalProduct.TotalDownloadsLeft} downloads left");
                }
            }

            Console.ReadLine();
        }

        private static CustomerModel GetCustomer()
        {
            return new CustomerModel
            {
                FirstName = "Tim",
                LastName = "Jones",
                City = "London",
                EmailAddress = "tim@email.com",
                PhoneNumber = "123-1212"
            };
        }

        private static List<IProductModel> AddSampleData()
        {
            List<IProductModel> output = new List<IProductModel>();

            // send physical
            output.Add(new PhysicalProductModel { Title = "Nerf Football" });
            output.Add(new PhysicalProductModel { Title = "T-Shirt" });
            output.Add(new PhysicalProductModel { Title = "Hard Drive" });

            // send digital
            output.Add(new DigitalProductModel() { Title = "Game demo"});

            return output;
        }
    }
}
