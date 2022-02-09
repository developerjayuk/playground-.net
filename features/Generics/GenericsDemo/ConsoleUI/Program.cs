using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            DemonstrateTextFileStorage();
            Console.Write("Press enter to shut down...");
            Console.ReadLine();
        }

        private static void DemonstrateTextFileStorage()
        {
            var people = new List<Person>();
            var logs = new List<LogEntry>();
            var peopleFile = @"C:\WebDev\Temp\people.csv";
            var logFile = @"C:\WebDev\Temp\logs.csv";

            List<Person> newPeople;
            List<LogEntry> newLogs;

            PopulateLists(people, logs);

            // NEW WAY USING GENERICS
            GenericTextFileProcessor.SaveToTextFile<Person>(people, peopleFile);
            GenericTextFileProcessor.SaveToTextFile<LogEntry>(logs, logFile);
            newPeople = GenericTextFileProcessor.LoadFromTextFile<Person>(peopleFile);
            newLogs = GenericTextFileProcessor.LoadFromTextFile<LogEntry>(logFile);
            
            // OLD AND BAD WAY TO DO THINGS
            //OriginalTextFileProcessor.SaveLogs(logs, logFile);
            //OriginalTextFileProcessor.SavePeople(people, peopleFile);

            //newPeople = OriginalTextFileProcessor.LoadPeople(peopleFile);
            //newLogs = OriginalTextFileProcessor.LoadLogs(logFile);

            Console.WriteLine("\n== PEOPLE LOADED ==");
            foreach (var p in newPeople)
            {
                Console.WriteLine($"{ p.FirstName } { p.LastName } (IsAlive = { p.IsAlive })");
            }
            
            Console.WriteLine("\n== LOGS LOADED ==");
            foreach (var l in newLogs)
            {
                Console.WriteLine($"{ l.ErrorCode } { l.Message } (IsAlive = { l.TimeOfEvent })");
            }
        }

        private static void PopulateLists(List<Person> people, List<LogEntry> logs)
        {
            people.Add(new Person { FirstName = "Jim", LastName = "Jones" });
            people.Add(new Person { FirstName = "Sue", LastName = "Storm", IsAlive = false });
            people.Add(new Person { FirstName = "Greg", LastName = "Olsen" });

            logs.Add(new LogEntry { Message = "I blew up", ErrorCode = 9999 });
            logs.Add(new LogEntry { Message = "I'm too awesome", ErrorCode = 1337 });
            logs.Add(new LogEntry { Message = "I was tired", ErrorCode = 2222 });
        }
    }
}
