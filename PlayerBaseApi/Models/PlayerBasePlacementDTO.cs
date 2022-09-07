namespace PlayerBaseApi.Models
{
    public class PlayerBasePlacementDTO
    {
        public int BuildingLevel { get; set; }
        public string? UpdateEndDate { get; set; } = null;
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public BuildingTypeDTO BuildingType { get; set; }
    }
}
