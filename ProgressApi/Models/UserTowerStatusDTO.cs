namespace ProgressApi.Models
{
    public class UserTowerStatusDTO
    {
        public string Name { get; set; }
        public int TowerId { get; set; }
        public int TowerLevelId { get; set; }
        public int PlaceId { get; set; }
        public int Level { get; set; }
        public double Damage { get; set; }
        public double FireRate { get; set; }
        public int Range { get; set; }
    }
}
