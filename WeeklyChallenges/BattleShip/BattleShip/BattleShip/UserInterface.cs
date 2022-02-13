using BattleShipLibrary;
using BattleShipLibrary.Models;

namespace BattleShip
{
    public static class UserInterface
    {
        public static void ShowWelcomeMessage()
        {
            Console.WriteLine("Welcome to Battleship. Let the games begin!!!");
            Console.WriteLine(" -- Create by Jason James");
            Console.WriteLine(" -- number of ships = 5");
            Console.WriteLine(" -- board height = 5");
            Console.WriteLine(" -- board width = 5");
        }

        public static PlayerInfoModel CreatePlayer()
        {
            var output = new PlayerInfoModel
            {
                Name = GetPlayerName(),
                ShipLocations = UserInterface.GetShipPlacements(5, 5, 5),
                AttackGrid = GameLogic.InitializeGrid(5, 5)
            };

            return output;
        }


        public static string GetPlayerName()
        {
            var name = "";

            do
            {
                Console.Write("Please enter your name: ");
                name = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(name));

            return name;
        }
        public static List<GridSpotModel> GetShipPlacements(int numberOfShips, int boardHeight, int boardWidth)
        {
            string maxLetter = ((char)(boardHeight + 64)).ToString();
            var shipsPlacements = new List<GridSpotModel>();
            var letter = "";
            var number = "";


            for (var i = 1; i <= numberOfShips; i++)
            {
                var validationErrorMessage = "";

                do
                {
                    Console.WriteLine($"Please enter your location for ship #{i}: ");
                    Console.WriteLine($"A-{maxLetter}: ");
                    letter = Console.ReadLine();
                    Console.WriteLine($"1-{boardWidth}: ");
                    number = Console.ReadLine();

                    validationErrorMessage = GameLogic.GridLocationValidation(letter, number);

                    if (string.IsNullOrEmpty(validationErrorMessage) == false)
                    {
                        Console.WriteLine(validationErrorMessage);
                    }

                }
                while (string.IsNullOrEmpty(validationErrorMessage) == false);
            }

            return shipsPlacements;
        }



        public static string DisplayGrid(List<GridSpotModel> attackGrid)
        {
            var grid = "";

            return grid;
        }

    }
}
