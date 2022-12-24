namespace MapApi.Models
{
    public class MapInfoDto
    {
        public int Id { get; set; }
        public bool IsApe { get; set; }
        public int MapItemTypeId { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public string UserName { get; set; }
        public long UserId { get; set; }
        public int AreaId { get; set; }
        public int BaseLevel { get; set; }
        public bool ActiveShield { get; set; } = false;
    }
}
