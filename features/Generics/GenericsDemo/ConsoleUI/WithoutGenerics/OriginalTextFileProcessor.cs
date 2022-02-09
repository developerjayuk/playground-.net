using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    public static class OriginalTextFileProcessor
    {
        public static List<Person> LoadPeople(string filePath)
        {
            List<Person> output = new List<Person>();
            Person p;
            var lines = System.IO.File.ReadAllLines(filePath).ToList();

            // Remove the header row
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var vals = line.Split(',');
                p = new Person
                {
                    FirstName = vals[0],
                    IsAlive = bool.Parse(vals[1]),
                    LastName = vals[2]
                };

                output.Add(p);
            }

            return output;
        }

        public static List<LogEntry> LoadLogs(string filePath)
        {
            List<LogEntry> output = new List<LogEntry>();
            LogEntry log;
            var lines = System.IO.File.ReadAllLines(filePath).ToList();

            // Remove the header row
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var vals = line.Split(',');
                log = new LogEntry
                {
                    ErrorCode = int.Parse(vals[0]),
                    Message = vals[1],
                    TimeOfEvent = DateTime.Parse(vals[2])
                };

                output.Add(log);
            }

            return output;
        }

        public static void SavePeople(List<Person> people, string filePath)
        {
            List<string> lines = new List<string> { "FirstName,IsAlive,LastName" };
            lines.AddRange(people.Select(p => $"{p.FirstName},{p.IsAlive},{p.LastName}"));

            System.IO.File.WriteAllLines(filePath, lines);
        }

        public static void SaveLogs(List<LogEntry> logs, string filePath)
        {
            var lines = new List<string> { "FirstName,IsAlive,LastName" };
            lines.AddRange(logs.Select(l => $"{l.ErrorCode},{l.Message},{l.TimeOfEvent}"));

            System.IO.File.WriteAllLines(filePath, lines);
        }
    }
}
