namespace GuestBook
{
    internal class GuestList
    {
        private readonly Dictionary<int, string> _menuOptions = new()
        {
            { 1, "Add guest to guest list" },
            { 2, "Show the guest list" },
            { 0, "Exit the program" }
        };

        private Dictionary<string, int> FullList = new();
        private int FullPartySize = 0;

        public void DisplayMenu()
        {
            Console.WriteLine($"----------------------------------------------------------");
            Console.WriteLine($"\nPlease select from one of the {_menuOptions.Count} menu options below:");

            foreach (var option in _menuOptions)
            {
                Console.WriteLine($"{option.Key} - {option.Value}");
            }

            var input = Console.ReadLine();
            ConfirmMenuSelection(input);
        }
        public void ConfirmMenuSelection(string? input)
        {
            var valid = false;
            valid = int.TryParse(input, out var option) && _menuOptions.ContainsKey(option);

            if (valid)
            {
                switch (option)
                {
                    case 1:
                        AddNewGuest();
                        break;
                    case 2:
                        DisplayFullGuestList();
                        break;
                    case 3:
                        ExitApplication();
                        break;
                }
            }
            else
            {
                Console.WriteLine("** Invalid selection please try again **");
                DisplayMenu();
            }
        }

        private void AddNewGuest()
        {
            var name = "";
            var partySize = 0;

            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" * Add New Guest");

            do
            {
                Console.Write("Please enter your name: ");
                name = Console.ReadLine();

            } while (!ValidName(name));

            do
            {
                Console.WriteLine("Please enter the size of your party as a number: ");
                Console.WriteLine("- maximum size is 20");
                var partySizeInput = Console.ReadLine();

                int.TryParse(partySizeInput, out partySize);

            } while (!ValidPartySize(partySize));

            FullList.Add(name, partySize);
            FullPartySize += partySize;
            Console.WriteLine("** User successfully added to the guest list");

            DisplayMenu();
        }

        private void DisplayFullGuestList()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($" Total number of groups: {FullList.Count}");
            Console.WriteLine($" Total number of guests: {FullPartySize}");

            if (FullList.Count > 0)
            {
                Console.WriteLine("\nFull Guest List is below:");

                foreach (var guest in FullList)
                {
                    Console.WriteLine($" - Guest {guest.Key} as a party of {guest.Value}.");
                }
            }

            DisplayMenu();
        }

        private void ExitApplication()
        {
            Console.WriteLine("Thank you for using our application. Have a good day :)");
            Environment.Exit(0);
        }

        private bool ValidName(string input)
        {
            return input.Length > 0;
        }
        private bool ValidPartySize(int input)
        {
            return input is > 0 and <= 20;
        }

    }
}
