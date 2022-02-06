namespace StaticClasses
{
    static class UserMessages
    {
        public static void ApplicationStartMessage(string name)
        {
            Console.WriteLine("Welcome to the static class demo app");

            var hourOfDay = DateTime.Now.Hour;

            switch (hourOfDay)
            {
                case < 12:
                    Console.WriteLine($"Good Morning {name}");
                    break;
                case < 19:
                    Console.WriteLine($"Good Afternoon {name}");
                    break;
                default:
                    Console.WriteLine($"Good Evening {name}");
                    break;
            }
        }

        public static void PrintResultsMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void ShowMenuMessage()
        {
            Console.WriteLine("Please select an option from the following:");
            Console.WriteLine("1. Add number 1 to number 2");
            Console.WriteLine("2. Subtract number 1 by number 2");
            Console.WriteLine("3. Multiply number 1 by number 2");
            Console.WriteLine("4. Divide number 1 by number 2");
        }
    }
}
