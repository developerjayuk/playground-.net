namespace BattleShipLibrary.Models
{
    public class PlayerInfoModel
    {
        public string Name { get; set; }
        public List<GridSpotModel> ShipLocations { get; set; }
        public List<GridSpotModel> AttackGrid { get; set; }
    }
}
