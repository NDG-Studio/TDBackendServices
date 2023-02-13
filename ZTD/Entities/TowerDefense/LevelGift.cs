using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTD.Entities
{
    public class LevelGift
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int LevelId { get; set; }
        public int Count { get; set; }
        
        [ForeignKey("ItemId")]
        public Item Item { get; set; } 
        
        [ForeignKey("LevelId")]
        public Level Level { get; set; }
    }
}
