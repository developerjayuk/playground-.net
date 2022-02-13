namespace BattleShipLibrary.Models
{
    public class GridSpotModel
    {
        public string Letter { get; set; }
        public int Number { get; set; }
        public GridSpotStatus Status { get; set; } = GridSpotStatus.Empty;
    }

    public enum GridSpotStatus
    {
        Empty, Ship, Hit, Miss
    }
}
