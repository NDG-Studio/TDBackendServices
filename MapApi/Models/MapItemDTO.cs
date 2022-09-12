namespace MapApi.Models
{
    public class MapItemDTO
    {
        public bool IsApe { get; set; }
        public int? MapItemTypeId { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public int BaseLevel { get; set; }
    }
}
