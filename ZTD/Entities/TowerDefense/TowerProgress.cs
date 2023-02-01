using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class TowerProgress
    {
        [Key]
        public long Id { get; set; }
        public int TowerId { get; set; }
        public long UserProgressHistoryId { get; set; }
        public int TowerCount { get; set; }
        public int TowerUpgradeNumber { get; set; }
        public int TowerFireCount { get; set; }
        public double TowerDamage { get; set; }
        public double TowerDotDamage { get; set; }
        public double TowerArmorDamage { get; set; }

        [ForeignKey("TowerId")]
        public Tower Tower { get; set;}

        [ForeignKey("UserProgressHistoryId")]
        public UserProgressHistory UserProgressHistory { get; set; }
    }
}
