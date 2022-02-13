using BattleShip;
using BattleShipLibrary.Models;

// config to be moved
int numberOfPlayers = 2;
int numberOfShips = 5;
int boardHeight = 5; // max of 25 
int boardWidth = 5; // max of 25

UserInterface.ShowWelcomeMessage();

// Get player information
List<PlayerInfoModel> players = new();

for (var i = 1; i <= numberOfPlayers; i++)
{
    var player = new PlayerInfoModel();

    Console.WriteLine($"==== Player {i} ====");
    player = UserInterface.CreatePlayer();

    players.Add(player);
}

