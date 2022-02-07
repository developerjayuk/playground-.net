using GuestBookLibrary.Models;

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

        private List<GuestModel> FullList = new();

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
            var firstName = "";
            var lastName = "";
            var partySize = 0;
            var messageToHost = "";

            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" * Add New Guest");

            do
            {
                Console.Write("Please enter your first name: ");
                firstName = Console.ReadLine();

            } while (!ValidName(firstName));

            do
            {
                Console.Write("Please enter your last name: ");
                lastName = Console.ReadLine();

            } while (!ValidName(lastName));

            do
            {
                Console.WriteLine("Please enter the size of your party as a number: ");
                Console.WriteLine("- maximum size is 20");
                var partySizeInput = Console.ReadLine();

                int.TryParse(partySizeInput, out partySize);

            } while (!ValidPartySize(partySize));

            Console.WriteLine("Please enter any special requirements you may have (optional): ");
            messageToHost = Console.ReadLine();
            
            FullList.Add(new GuestModel() {FirstName = firstName, LastName = lastName, PartySize = partySize, MessageToHost = messageToHost});
            Console.WriteLine("** User successfully added to the guest list");

            DisplayMenu();
        }

        private void DisplayFullGuestList()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($" Total number of groups: {FullList.Count}");
            Console.WriteLine($" Total number of guests: {TotalNumberOfPeople(FullList)}");

            if (FullList.Count > 0)
            {
                Console.WriteLine("\nFull Guest List is below:");

                foreach (var guest in FullList)
                {
                    Console.WriteLine($"Guest: {guest.LastName} as a party of {guest.PartySize}.");
                    if (string.IsNullOrEmpty(guest.MessageToHost) == false)
                    {
                        Console.WriteLine($" - Additional Info: {guest.MessageToHost}");
                    }
                }
            }

            DisplayMenu();
        }

        private void ExitApplication()
        {
            Console.WriteLine("Thank you for using our application. Have a good day :)");
            Environment.Exit(0);
        }

        private static int TotalNumberOfPeople(List<GuestModel> guests)
        {
            return guests.Select(g => g.PartySize).Sum();
        }

        private static bool ValidName(string input)
        {
            return input.Length > 0;
        }

        private static bool ValidPartySize(int input)
        {
            return input is > 0 and <= 20;
        }

    }
}
