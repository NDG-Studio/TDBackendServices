using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class LevelChestChance
    {
        [Key]
        public int Id { get; set; }
        public int ChestId { get; set; }
        public int LevelId { get; set; }
        public int ChanceMultiplier { get; set; }
        
        [ForeignKey("ChestId")]
        public Chest Chest { get; set; } 
        
        [ForeignKey("LevelId")]
        public Level Level { get; set; }
    }
}
