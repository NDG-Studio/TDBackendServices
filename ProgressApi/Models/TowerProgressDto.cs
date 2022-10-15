namespace ProgressApi.Models
{
    public class TowerProgressDTO
    {
        public int TowerId { get; set; }
        public int TowerCount { get; set; }
        public int TowerUpgradeNumber { get; set; }
        public int TowerFireCount { get; set; }
        public double TowerDamage { get; set; }
        public double TowerDotDamage { get; set; }
        public double TowerArmorDamage { get; set; }
    }
}
