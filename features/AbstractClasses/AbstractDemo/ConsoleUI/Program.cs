using DemoLibrary;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var databases = new List<DataAccess>()
            {
                new SqlDataAccess(),
                new SqliteDataAccess()
            };

            foreach (var db in databases)
            {
                db.LoadConnectionString("demo");
                db.LoadData("select * from table");
                db.SaveData("insert into table");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
