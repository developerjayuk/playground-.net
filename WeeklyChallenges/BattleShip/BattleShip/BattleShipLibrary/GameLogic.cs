using BattleShipLibrary.Models;

namespace BattleShipLibrary
{
    public static class GameLogic
    {
        public static List<GridSpotModel> InitializeGrid(int boardHeight, int boardWidth)
        {
            var grid = new List<GridSpotModel>();

            for (var i = 1; i <= boardHeight; i++)
            {
                for (var j = 1; j <= boardWidth; j++)
                {
                    var gridSpot = new GridSpotModel
                    {
                        Letter = ((char)(i + 64)).ToString(),
                        Number = j
                    };

                    grid.Add(gridSpot);
                }
            }

            return grid;
        }

        public static string GridLocationValidation(PlayerInfoModel model, string letter, string number)
        {
            var validationErrorMessage = "";



            return validationErrorMessage;
        }
    }
}
