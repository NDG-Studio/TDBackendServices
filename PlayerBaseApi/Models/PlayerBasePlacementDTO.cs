namespace PlayerBaseApi.Models
{
    public class PlayerBasePlacementDTO
    {
        public int BuildingLevel { get; set; }
        public string? UpdateEndDate { get; set; } = null;
        public double CoordX { get; set; }
        public double CoordY { get; set; }
        public BuildingTypeDTO BuildingType { get; set; }
    }
}
