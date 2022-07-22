using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgressApi.Entities
{
    public class TowerProgress
    {
        [Key]
        public long Id { get; set; }
        public long TowerId { get; set; }
        public long UserProgressId { get; set; }
        public long TowerName { get; set; }
        public int TowerCount { get; set; }
        public int TowerUpgradeNumber { get; set; }
        public int TowerFireCount { get; set; }
        public double TowerDamage { get; set; }
        public double TowerDotDamage { get; set; }
        public double TowerArmorDamage { get; set; }

        [ForeignKey("TowerId")]
        public Tower Tower { get; set;}

        [ForeignKey("UserProgressId")]
        public UserProgress UserProgress { get; set; }
    }
}
