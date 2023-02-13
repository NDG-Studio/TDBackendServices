using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class Level
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderId { get; set; }
        public int ChapterId { get; set; }
        public int LevelStarCondition { get; set; }
        public int Coin { get; set; }
        public int BarrierHealth { get; set; }
        
        [ForeignKey("ChapterId")]
        public Chapter Chapter { get; set; }
        
        public virtual List<Wave> Waves { get; set; }
        public virtual List<LevelChestChance> LevelChestChances { get; set; }
        public virtual List<LevelGift> LevelGifts { get; set; }

    }
}
